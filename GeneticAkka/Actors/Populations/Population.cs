using Akka.Actor;
using Akka.Event;
using GeneticAkka.Actors.ChromosomeBuilders;
using GeneticAkka.Actors.ChromosomeSelectors;
using GeneticAkka.Algorithms.Models;
using System.Collections.Generic;

namespace GeneticAkka.Actors.Populations
{
    public abstract partial class Population<T> : ReceiveActor where T : IChromosome
    {
        private readonly ILoggingAdapter log = Context.GetLogger();
        private T[] _chromosomes;
        private Parents<T>[] _parents;
        private ActorCreator<ChromosomeBuilder<T>> _chromosomeBuilderCreator;
        private ActorCreator<ChromosomeSelector<T>> _chromosomeSelectorCreator;
        private IActorRef _algorithm;

        protected SortedList<T, int> _bestChromosomes;
        protected T[] _newChromosomes;
        protected int _currentGeneration;

        public Population(ActorCreator<ChromosomeBuilder<T>> chromosomeBuilderCreator, ActorCreator<ChromosomeSelector<T>> chromosomeSelectorCreator)
        {
            _chromosomeBuilderCreator = chromosomeBuilderCreator;
            _chromosomeSelectorCreator = chromosomeSelectorCreator;

            New();
        }

        private void Ready()
        {
            Receive(OnCheckEvaluationCondition());
            Receive(OnSelectParents());
            Receive(OnSucceededSelectChromosome());
            Receive(OnCrossoverParents());
        }
    }
}
