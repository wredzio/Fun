using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeSelectors.Messages
{
    public class SelectChromosomes<T> where T : IChromosome
    {
        public SelectChromosomes(ImmutableArray<T> chromosomes)
        {
            Chromosomes = chromosomes;
        }

        public ImmutableArray<T> Chromosomes { get; }
    }
}
