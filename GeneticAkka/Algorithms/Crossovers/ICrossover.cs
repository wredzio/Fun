using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Crossovers
{
    public interface ICrossover<T> where T : IChromosome
    {
        T CrossoverParents(Parents<T> parents);
    }
}
