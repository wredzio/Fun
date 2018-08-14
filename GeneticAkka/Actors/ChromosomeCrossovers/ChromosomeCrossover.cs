using Akka.Actor;
using GeneticAkka.Actors.ChromosomeSelectors.Messages;
using GeneticAkka.Algorithms.Models;

namespace GeneticAkka.Actors.ChromosomeSelectors
{
    public abstract class ChromosomeCrossover<T> : ReceiveActor where T : IChromosome
    {
        public ChromosomeCrossover()
        {
        }

    }
}
