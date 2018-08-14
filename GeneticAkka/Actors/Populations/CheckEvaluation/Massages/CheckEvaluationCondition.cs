using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Populations.CheckEvaluation.Messages
{
    public class CheckEvaluationCondition
    {
        public CheckEvaluationCondition(int trackBest)
        {
            TrackBest = trackBest;
        }

        public int TrackBest { get; }
    }
}
