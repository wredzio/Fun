using GeneticAkka.Algorithms.Crossovers;
using GeneticAkka.Algorithms.Selections;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Models
{
    public class AlgorithmConfig<T> where T : IChromosome
    {
        public AlgorithmConfig(int mutationSize, int mutationProbability, int numberOfChromosomes, int replaceByGeneration, int trackBest, ISelection<T> selection, ICrossover<T> crossover, CrossoverConfig crossoverConfig)
        {
            MutationSize = mutationSize;
            MutationProbability = mutationProbability;
            NumberOfChromosomes = numberOfChromosomes;
            ReplaceByGeneration = replaceByGeneration;
            TrackBest = trackBest;
            Selection = selection;
            Crossover = crossover;
            CrossoverConfig = crossoverConfig;
        }
        
        public int MutationSize { get; }
        public int MutationProbability { get; }
        public int NumberOfChromosomes { get; }
        public int ReplaceByGeneration { get; }
        public int TrackBest { get; }
        public ISelection<T> Selection { get; }
        public ICrossover<T> Crossover { get; }
        public CrossoverConfig CrossoverConfig { get; }
    }
}
