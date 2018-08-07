using GeneticAkka.Actors;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Binary.Models
{
    public class BinaryAlgorithm : Algorithm<BinaryChromosome>
    {
        public BinaryAlgorithm(ActorCreator<Population<BinaryChromosome>> populationCreator) : base(populationCreator)
        {
        }
    }
}
