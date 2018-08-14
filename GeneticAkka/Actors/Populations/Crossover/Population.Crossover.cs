using Akka.Actor;
using GeneticAkka.Actors.Populations.CheckEvaluation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAkka.Actors.Populations
{
    public abstract partial class Population<T>
    {
        private Action<CheckEvaluationCondition> OnCrossoverParents()
        {
            return message =>
            {
                
            };
        }
    }
}
