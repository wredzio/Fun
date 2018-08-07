using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Messages
{
    public class End<T> where T : IChromosome
    {
        public End(T result)
        {
            Result = result;
        }

        public T Result { get; }
    }
}
