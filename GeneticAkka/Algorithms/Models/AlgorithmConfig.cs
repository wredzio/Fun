using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Models
{
    public class AlgorithmConfig
    {
        public int NumberOfCrossoverPoints { get; }
        public int MutationSize { get; }
        public int CrosoverProbability { get; }
        public int MutationProbability { get; }
        public int NumberOfChromosomes { get; }
        public int ReplaceByGeneration { get; }
        public int TrackBest { get; }
        //SelectionType SelectionType { get;  }
    }
}
