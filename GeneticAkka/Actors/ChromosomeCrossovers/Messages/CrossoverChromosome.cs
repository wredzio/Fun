using GeneticAkka.Algorithms.Crossovers;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeCrossovers.Messages
{
    public class CrossoverChromosome<T> where T : IChromosome
    {
        public CrossoverChromosome(Parents<T> parents, ICrossover<T> crossover, CrossoverConfig crossoverConfig)
        {
            Parents = parents;
            Crossover = crossover;
            CrossoverConfig = crossoverConfig;
        }

        public Parents<T> Parents { get; }
        public ICrossover<T> Crossover { get; }
        public CrossoverConfig CrossoverConfig { get; }
    }
}
