using Akka.Actor;
using Akka.Event;
using GeneticAkka.Actors;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Actors.Populations.Messages;
using GeneticAkka.Algorithms.Messages;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms
{
    public abstract class Algorithm<T> : ReceiveActor where T : IChromosome
    {
        private AlgorithmConfig _algorithmConfig;
        private readonly ILoggingAdapter log = Context.GetLogger();
        private IActorRef _population;
        private ActorCreator<Population<T>> _creatorActorCreator;

        public Algorithm(ActorCreator<Population<T>> populationCreator)
        {
            _creatorActorCreator = populationCreator;

            Receive(Start());

            Receive(OnInitializePopulationResponse());

            Receive(OnCheckEvaluationConditionResponse());

            Receive(OnSelectParentsResponse());

            Receive(OnCrossoverParentsResponse());

            Receive(OnMutateResponse());
        }

        protected virtual Action<Run> Start()
        {
            return message =>
            {
                _algorithmConfig = message.AlgorithmConfig;
                _creatorActorCreator.CreateChild(nameof(Population<T>));
                _population = Context.ActorOf(_creatorActorCreator.GetChild(nameof(Population<T>), Context), nameof(Population<T>));

                _population.Tell(new InitializePopulation(_algorithmConfig.NumberOfChromosomes));
            };
        }

        protected virtual Action<InitializePopulationResponse> OnInitializePopulationResponse()
        {
            return message =>
            {
                _population.Tell(new CheckEvaluationCondition());
            };
        }

        protected virtual Action<CheckEvaluationConditionResponse<T>> OnCheckEvaluationConditionResponse()
        {
            return message =>
            {
                if (message.IsSufficient)
                {
                    Sender.Tell(new End<T>(message.Result), Self);
                }
                else
                {
                    _population.Tell(new SelectParents<T>(), Self);
                }

            };
        }

        protected virtual Action<SelectParentsResponse<T>> OnSelectParentsResponse()
        {
            return message =>
            {
                _population.Tell(new CrossoverParents<T>(), Self);
            };
        }

        protected virtual Action<CrossoverParentsResponse<T>> OnCrossoverParentsResponse()
        {
            return message =>
            {
                _population.Tell(new Mutate<T>(), Self);
            };
        }

        protected virtual Action<MutateResponse<T>> OnMutateResponse()
        {
            return message =>
            {
                _population.Tell(new CheckEvaluationCondition());
            };
        }
    }
}
