using Akka.Actor;
using Akka.Routing;
using GeneticAkka.Actors.Creators;
using GeneticAkka.Actors.Creators.Messages;
using GeneticAkka.Actors.Populations.Messages;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAkka.Actors.Populations
{
    public abstract class Population<T> : ReceiveActor where T : IChromosome
    {
        private T[] chromosomes;

        public Population(ActorCreator<ChromosomeCreator<T>> chromosomeCreatorActorCreator)
        {
            Receive<InitializePopulation>(message =>
            {
                chromosomes = new T[message.NumberOfChromosomes];
                var creatorName = nameof(Population<T>) + nameof(ChromosomeCreator<T>);
                chromosomeCreatorActorCreator.CreateChild(creatorName);
                var creatorRouter = Context.ActorOf(chromosomeCreatorActorCreator.GetChild(creatorName, Context).WithRouter(new RoundRobinPool(10)), creatorName);

                for(int i = 0; i < message.NumberOfChromosomes; i++)
                {
                    creatorRouter.Tell(new CreateChromosome(i));
                }
            });

            Receive<SucceededCreateChromosome<T>>(message =>
            {
                chromosomes[message.Index] = message.Chromosome;

                if(chromosomes.All(chromosome => chromosome != null))
                {

                }
            });
        }
    }
}
