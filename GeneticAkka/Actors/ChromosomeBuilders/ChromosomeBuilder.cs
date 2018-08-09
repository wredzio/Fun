using Akka.Actor;
using GeneticAkka.Actors.ChromosomeBuilders.Messages;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeBuilders
{
    public abstract class ChromosomeBuilder<T> : ReceiveActor where T : IChromosome
    { 
        public ChromosomeBuilder()
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
