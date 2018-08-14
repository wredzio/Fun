using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace GeneticAkka.Algorithms.Selections
{
    public interface ISelection<T> where T : IChromosome
    {
        Parents<T> SelectParents(ImmutableArray<T> population);
    }
}
