using Akka.Actor;
using Akka.Event;
using GeneticAkka.Actors;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Actors.Populations.CheckEvaluation.Messages;
using GeneticAkka.Actors.Populations.Crossover.Messages;
using GeneticAkka.Actors.Populations.Initialize.Messages;
using GeneticAkka.Actors.Populations.Messages;
using GeneticAkka.Actors.Populations.SelectParents.Messages;
using GeneticAkka.Algorithms.Messages;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms
{
    public abstract class Algorithm<T> : ReceiveActor where T : IChromosome
    {
        private AlgorithmConfig<T> _algorithmConfig;
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

        protected virtual Action<Run<T>> Start()
        {
            return message =>
            {
                log.Info("Start Algorithm");

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
                log.Info("Initialize Population Response");

                _population.Tell(new CheckEvaluationCondition(_algorithmConfig.TrackBest));
            };
        }

        protected virtual Action<CheckEvaluationConditionResponse<T>> OnCheckEvaluationConditionResponse()
        {
            return message =>
            {
                log.Info("Check Evaluation Condition Response");

                if (message.IsSufficient)
                {
                    var c = new End<T>(message.Result);//TODO tell  resultPublisher
                }
                else
                {
                    _population.Tell(new SelectParents<T>(_algorithmConfig.ReplaceByGeneration, _algorithmConfig.Selection), Self);
                }

            };
        }

        protected virtual Action<SelectParentsResponse<T>> OnSelectParentsResponse()
        {
            return message =>
            {
                log.Info("Select Parents Response");

                _population.Tell(new CrossoverParents<T>(_algorithmConfig.Crossover, _algorithmConfig.CrossoverConfig), Self);
            };
        }

        protected virtual Action<CrossoverParentsResponse<T>> OnCrossoverParentsResponse()
        {
            return message =>
            {
                log.Info("Crossover Parents Response");

                _population.Tell(new Mutate<T>(), Self);
            };
        }

        protected virtual Action<MutateResponse<T>> OnMutateResponse()
        {
            return message =>
            {
                log.Info("Mutate Response");

                _population.Tell(new CheckEvaluationCondition(_algorithmConfig.TrackBest));
            };
        }
    }
}
