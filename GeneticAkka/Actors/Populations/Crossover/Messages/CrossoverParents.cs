using GeneticAkka.Algorithms.Crossovers;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Populations.Crossover.Messages
{
    public class CrossoverParents<T> where T : IChromosome
    {
        public CrossoverParents(ICrossover<T> crossover, CrossoverConfig crossoverConfig)
        {
            Crossover = crossover;
            CrossoverConfig = crossoverConfig;
        }

        public ICrossover<T> Crossover { get; }
        public CrossoverConfig CrossoverConfig { get; }
    }
}
