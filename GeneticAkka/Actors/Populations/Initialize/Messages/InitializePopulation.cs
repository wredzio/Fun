using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Populations.Initialize.Messages
{
    public class InitializePopulation
    {
        public InitializePopulation(int numberOfChromosomes)
        {
            NumberOfChromosomes = numberOfChromosomes;
        }

        public int NumberOfChromosomes { get; }
    }
}
