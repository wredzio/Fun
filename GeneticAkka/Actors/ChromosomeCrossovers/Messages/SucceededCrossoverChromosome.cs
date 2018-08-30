using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeCrossovers.Messages
{
    public class SucceededCrossoverChromosome<T> where T : IChromosome
    {
        public SucceededCrossoverChromosome(T newChromosme)
        {
            NewChromosme = newChromosme;
        }

        public T NewChromosme { get; }
    }
}
