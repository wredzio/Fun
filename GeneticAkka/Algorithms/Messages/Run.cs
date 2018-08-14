using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Messages
{
    public class Run<T> where T : IChromosome
    {
        public Run(AlgorithmConfig<T> algorithmConfig)
        {
            AlgorithmConfig = algorithmConfig;
        }

        public AlgorithmConfig<T> AlgorithmConfig { get; }
    }
}
