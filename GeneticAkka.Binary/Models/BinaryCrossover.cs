using GeneticAkka.Algorithms.Crossovers;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace GeneticAkka.Binary.Models
{
    public class BinaryCrossover : ICrossover<BinaryChromosome>
    {
        protected Random _rand;

        public BinaryCrossover()
        {
            _rand = new Random();
        }


        public BinaryChromosome CrossoverParents(Parents<BinaryChromosome> parents, CrossoverConfig crossoverConfig)
        {
            if(_rand.Next(0, 100) < crossoverConfig.CrosoverProbability)
            {
                
            }

            return parents.FirstParent;
        }
    }
}
