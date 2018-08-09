using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Models
{
    public class Parents<T> where T : IChromosome
    {
        public Parents(T firstParent, T secondParent)
        {
            FirstParent = firstParent;
            SecondParent = secondParent;
        }

        public T FirstParent { get; }
        public T SecondParent { get; }
    }
}
