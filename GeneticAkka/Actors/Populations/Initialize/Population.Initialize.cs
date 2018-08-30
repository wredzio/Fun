using Akka.Actor;
using Akka.Routing;
using GeneticAkka.Actors.ChromosomeBuilders;
using GeneticAkka.Actors.ChromosomeBuilders.Messages;
using GeneticAkka.Actors.Populations.Initialize.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAkka.Actors.Populations
{
    public abstract partial class Population<T>
    {
        private void New()
        {
            Receive(OnInitializePopulation());
            Receive(OnInitSucceededBuildChromosome());
        }

        private Action<InitializePopulation> OnInitializePopulation()
        {
            return message =>
            {
                log.Info($"Initialize Population");

                _algorithm = Sender;
                _chromosomes = new T[message.NumberOfChromosomes];
                _bestChromosomes = new SortedList<T, int>();

                var creatorName = nameof(Population<T>) + nameof(ChromosomeBuilder<T>);
                _chromosomeBuilderCreator.CreateChild(creatorName);
                var creatorRouter = Context.ActorOf(_chromosomeBuilderCreator.GetChild(creatorName, Context).WithRouter(new RoundRobinPool(25)), creatorName);// TODO to config

                for (int i = 0; i < message.NumberOfChromosomes; i++)
                {
                    creatorRouter.Tell(new BuildChromosome(i));
                }
            };
        }

        private Action<SucceededBuildChromosome<T>> OnInitSucceededBuildChromosome()
        {
            return message =>
            {
                log.Info($"Succeeded Build Chromosome, Index: ${message.Index}, Fitness: ${message.Chromosome.Fitness}");

                _chromosomes[message.Index] = message.Chromosome;
                if(!_bestChromosomes.ContainsKey(message.Chromosome))
                {
                    _bestChromosomes.Add(message.Chromosome, message.Index);
                }

                if (_chromosomes.All(chromosome => chromosome != null))
                {
                    Become(() => Ready());
                    _algorithm.Tell(new InitializePopulationResponse());
                }
            };
        }
    }
}
