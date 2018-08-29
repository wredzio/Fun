using Akka.Actor;
using Akka.Routing;
using GeneticAkka.Actors.ChromosomeSelectors;
using GeneticAkka.Actors.ChromosomeSelectors.Messages;
using GeneticAkka.Actors.Populations.SelectParents.Messages;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GeneticAkka.Actors.Populations
{
    public abstract partial class Population<T>
    {
        private Action<SelectParents<T>> OnSelectParents()
        {
            return message =>
            {
                log.Info($"Select Parents");

                _parents = new Parents<T>[message.ReplaceByGeneration];
                var creatorName = nameof(Population<T>) + nameof(ChromosomeSelector<T>);
                _chromosomeSelectorCreator.CreateChild(creatorName);
                var creatorRouter = Context.ActorOf(_chromosomeSelectorCreator.GetChild(creatorName, Context).WithRouter(new RoundRobinPool(25)), creatorName);// TODO to config

                var immutableChromosome = _chromosomes.ToImmutableArray();

                for (int i = 0; i < message.ReplaceByGeneration; i++)
                {
                    creatorRouter.Tell(new SelectChromosome<T>(immutableChromosome, message.Selection, i));
                }
            };
        }

        private Action<SucceededSelectChromosome<T>> OnSucceededSelectChromosome()
        {
            return message =>
            {
                log.Info($"Succeeded Select Chromosome ${message.Index}, 1st Fitness: ${message.Parents.FirstParent.Fitness} 2nd Fitness: ${message.Parents.SecondParent.Fitness}");

                _parents[message.Index] = message.Parents;

                if (_parents.All(parent => parent != null))
                {
                    _algorithm.Tell(new SelectParentsResponse<T>());
                }
            };
        }
    }
}
