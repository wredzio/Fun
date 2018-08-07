using Akka.Actor;
using GeneticAkka.Actors.Creators.Messages;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Creators
{
    public abstract class ChromosomeCreator<T> : ReceiveActor where T : IChromosome
    { 
        public ChromosomeCreator()
        {
            Receive<CreateChromosome>(message => CreateChromosome(message));
        }

        protected virtual void CreateChromosome(CreateChromosome message)
        {
            var createdChromosome = CreateChromosome();
            Sender.Tell(new SucceededCreateChromosome<T>(message.Index, createdChromosome));
        }

        protected abstract T CreateChromosome();
    }
}
