using GeneticAkka.Algorithms.Models;
using GeneticAkka.Algorithms.Selections;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeSelectors.Messages
{
    public class SelectChromosome<T> where T : IChromosome
    {
        public SelectChromosome(ImmutableArray<T> chromosomes, ISelection<T> selection, int index)
        {
            Chromosomes = chromosomes;
            Selection = selection;
            Index = index;
        }

        public ImmutableArray<T> Chromosomes { get; }
        public ISelection<T> Selection { get; }
        public int Index { get; }
    }
}
