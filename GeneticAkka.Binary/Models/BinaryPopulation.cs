using GeneticAkka.Actors;
using GeneticAkka.Actors.ChromosomeBuilders;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Actors.Populations.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneticAkka.Binary.Models
{
    public class BinaryPopulation : Population<BinaryChromosome>
    {
        public BinaryPopulation(ActorCreator<ChromosomeBuilder<BinaryChromosome>> chromosomeBuilderCreator) : base(chromosomeBuilderCreator)
        {
        }

        protected override CheckEvaluationConditionResponse<BinaryChromosome> CheckEvaluationCondition()
        {
            return new CheckEvaluationConditionResponse<BinaryChromosome>(_currentGeneration > 200, _bestChromosomes.Keys.FirstOrDefault());
        }
    }
}
