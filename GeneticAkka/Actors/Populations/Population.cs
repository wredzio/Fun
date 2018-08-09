using Akka.Actor;
using Akka.Routing;
using GeneticAkka.Actors.ChromosomeBuilders;
using GeneticAkka.Actors.ChromosomeBuilders.Messages;
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
        private T[] _chromosomes;
        private ActorCreator<ChromosomeBuilder<T>> _chromosomeBuilderCreator;
        private IActorRef _algorithm;

        protected SortedList<T, int> _bestChromosomes;
        protected int _currentGeneration;

        public Population(ActorCreator<ChromosomeBuilder<T>> chromosomeBuilderCreator)
        {
            _chromosomeBuilderCreator = chromosomeBuilderCreator;

            New();
        }

        private void New()
        {
            Receive(OnInitializePopulation());
            Receive(OnInitSucceededBuildChromosome());
        }

        private void Ready()
        {
            Receive(OnCheckEvaluationCondition());
        }

        private Action<CheckEvaluationCondition> OnCheckEvaluationCondition()
        {
            return message =>
            {
                _currentGeneration++;
                _bestChromosomes = new SortedList<T, int>(_bestChromosomes.Take(message.TrackBest).ToDictionary(o => o.Key, o => o.Value));
                _algorithm.Tell(CheckEvaluationCondition());
            };
        }

        protected abstract CheckEvaluationConditionResponse<T> CheckEvaluationCondition();


        private Action<InitializePopulation> OnInitializePopulation()
        {
            return message =>
            {
                _algorithm = Sender;
                _chromosomes = new T[message.NumberOfChromosomes];
                _bestChromosomes = new SortedList<T, int>();

                var creatorName = nameof(Population<T>) + nameof(ChromosomeBuilder<T>);
                _chromosomeBuilderCreator.CreateChild(creatorName);
                var creatorRouter = Context.ActorOf(_chromosomeBuilderCreator.GetChild(creatorName, Context).WithRouter(new RoundRobinPool(10)), creatorName);

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
                _chromosomes[message.Index] = message.Chromosome;
                _bestChromosomes.Add(message.Chromosome, message.Index);

                if (_chromosomes.All(chromosome => chromosome != null))
                {
                    Become(() => Ready());
                    _algorithm.Tell(new InitializePopulationResponse());
                }
            };
        }


    }
}
