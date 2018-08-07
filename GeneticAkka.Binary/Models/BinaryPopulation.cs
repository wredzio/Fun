using GeneticAkka.Actors;
using GeneticAkka.Actors.Creators;
using GeneticAkka.Actors.Populations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Binary.Models
{
    public class BinaryPopulation : Population<BinaryChromosome>
    {
        public BinaryPopulation(ActorCreator<ChromosomeCreator<BinaryChromosome>> chromosomeCreatorActorCreator) : base(chromosomeCreatorActorCreator)
        {
        }
    }
}
