using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Creators.Messages
{
    public class CreateChromosome
    {
        public CreateChromosome(int index)
        {
            Index = index;
        }

        public int Index { get; }
    }
}
