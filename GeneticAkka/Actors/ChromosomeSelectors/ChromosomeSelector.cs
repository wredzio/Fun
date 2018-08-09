using Akka.Actor;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeSelectors
{
    public abstract class ChromosomeSelector<T> : ReceiveActor where T : IChromosome
    {
        private T[] _chromosomes;

        public ChromosomeSelector()
        {
            Receive<BuildChromosome>(message => BuildChromosome(message));
        }

        protected virtual void BuildChromosome(BuildChromosome message)
        {
            var createdChromosome = BuildChromosome();
            createdChromosome.CalculateFitness();
            Sender.Tell(new SucceededBuildChromosome<T>(message.Index, createdChromosome));
        }

        protected abstract T BuildChromosome();
    }
}
