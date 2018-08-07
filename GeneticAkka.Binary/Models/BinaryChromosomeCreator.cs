using GeneticAkka.Actors.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Binary.Models
{
    public class BinaryChromosomeCreator : ChromosomeCreator<BinaryChromosome>
    {
        protected override BinaryChromosome CreateChromosome()
        {
            return new BinaryChromosome();
        }
    }
}
