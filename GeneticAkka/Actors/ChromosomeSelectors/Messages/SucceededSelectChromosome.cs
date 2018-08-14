using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeSelectors.Messages
{
    public class SucceededSelectChromosome<T> where T : IChromosome
    {
        public SucceededSelectChromosome(Parents<T> parents, int index)
        {
            Parents = parents;
            Index = index;
        }

        public Parents<T> Parents { get; }
        public int Index { get; }
    }
}
