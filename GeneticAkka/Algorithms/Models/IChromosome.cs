using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Models
{
    public interface IChromosome
    {
        float CalculateFitness();
    }
}
