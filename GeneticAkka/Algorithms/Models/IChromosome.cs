using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Models
{
    public interface IChromosome: IComparable<IChromosome>
    {
        float Fitness { get; }
        float CalculateFitness();
    }
}
