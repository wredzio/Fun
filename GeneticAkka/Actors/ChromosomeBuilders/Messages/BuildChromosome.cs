using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeBuilders.Messages
{
    public class BuildChromosome
    {
        public BuildChromosome(int index)
        {
            Index = index;
        }

        public int Index { get; }
    }
}
