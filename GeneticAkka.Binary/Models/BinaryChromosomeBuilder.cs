using GeneticAkka.Actors.ChromosomeBuilders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Binary.Models
{
    public class BinaryChromosomeBuilder : ChromosomeBuilder<BinaryChromosome>
    {
        protected override BinaryChromosome BuildChromosome()
        {
            return new BinaryChromosome();
        }
    }
}
