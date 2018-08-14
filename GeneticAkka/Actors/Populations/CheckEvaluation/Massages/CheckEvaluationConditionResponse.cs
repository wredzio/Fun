using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Populations.CheckEvaluation.Messages
{
    public class CheckEvaluationConditionResponse<T> where T: IChromosome
    {
        public CheckEvaluationConditionResponse(bool isSufficient, T result)
        {
            IsSufficient = isSufficient;
            Result = result;
        }

        public bool IsSufficient { get; }
        public T Result { get; }
    }
}
