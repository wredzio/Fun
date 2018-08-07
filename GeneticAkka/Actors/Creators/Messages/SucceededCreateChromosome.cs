using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Creators.Messages
{
    public class SucceededCreateChromosome<T> where T : IChromosome
    {
        public SucceededCreateChromosome(int index, T chromosome)
        {
            Index = index;
            Chromosome = chromosome;
        }

        public int Index { get; }
        public T Chromosome { get; }
    }
}
