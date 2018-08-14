using Akka.Actor;
using GeneticAkka.Actors.Populations.CheckEvaluation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAkka.Actors.Populations
{
    public abstract partial class Population<T>
    {
        private Action<CheckEvaluationCondition> OnCheckEvaluationCondition()
        {
            return message =>
            {
                log.Info($"Check Evaluation Condition, Generation: {_currentGeneration}");

                _currentGeneration++;
                _bestChromosomes = new SortedList<T, int>(_bestChromosomes.Take(message.TrackBest).ToDictionary(o => o.Key, o => o.Value));
                _algorithm.Tell(CheckEvaluationCondition());
            };
        }

        protected abstract CheckEvaluationConditionResponse<T> CheckEvaluationCondition();
    }
}
