using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Crossovers
{
    public class CrossoverConfig
    {
        public CrossoverConfig(int crosoverProbability, int numberOfCrossoverPoints)
        {
            CrosoverProbability = crosoverProbability;
            NumberOfCrossoverPoints = numberOfCrossoverPoints;
        }

        public int CrosoverProbability { get; }
        public int NumberOfCrossoverPoints { get; }
    }
}
