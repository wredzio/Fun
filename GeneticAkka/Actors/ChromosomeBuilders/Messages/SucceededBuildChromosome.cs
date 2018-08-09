using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeBuilders.Messages
{
    public class SucceededBuildChromosome<T> where T : IChromosome
    {
        public SucceededBuildChromosome(int index, T chromosome)
        {
            Index = index;
            Chromosome = chromosome;
        }

        public int Index { get; }
        public T Chromosome { get; }
    }
}
