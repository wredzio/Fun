using Akka.Actor;
using Akka.Routing;
using GeneticAkka.Actors.ChromosomeCrossovers.Messages;
using GeneticAkka.Actors.Populations.CheckEvaluation.Messages;
using GeneticAkka.Actors.Populations.Crossover.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GeneticAkka.Actors.Populations
{
    public abstract partial class Population<T>
    {
        private Action<CrossoverParents<T>> OnCrossoverParents()
        {
            return message =>
            {
                log.Info($"Crossover Parents");
                
                var creatorName = nameof(Population<T>) + nameof(CrossoverParents<T>);
                _chromosomeSelectorCreator.CreateChild(creatorName);
                var creatorRouter = Context.ActorOf(_chromosomeSelectorCreator.GetChild(creatorName, Context).WithRouter(new RoundRobinPool(25)), creatorName);// TODO to config

                var immutableParents = _parents.ToImmutableArray();

                for (int i = 0; i < immutableParents.Length; i++)
                {
                    creatorRouter.Tell(new CrossoverChromosome<T>(immutableParents[i], message.Crossover, message.CrossoverConfig));
                }
            };
        }

        private Action<SucceededCrossoverChromosome<T>> OnSucceededCrossoverParents()
        {
            return message =>
            {
                log.Info($"New Chromosome Fitness ${message.NewChromosme.Fitness}");

                //_newChromosomes[] = message.Parents;

                //if (_parents.All(parent => parent != null))
                //{
                //    _algorithm.Tell(new SelectParentsResponse<T>());
                //}
            };
        }
    }
}
