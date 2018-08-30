using Akka.Actor;
using GeneticAkka.Actors.ChromosomeCrossovers.Messages;
using GeneticAkka.Actors.ChromosomeSelectors.Messages;
using GeneticAkka.Algorithms.Models;

namespace GeneticAkka.Actors.ChromosomeCrossover
{
    public abstract class ChromosomeCrossover<T> : ReceiveActor where T : IChromosome
    {
        public ChromosomeCrossover()
        {
            Receive<CrossoverChromosome<T>>(message => CrossoverChromosome(message));
        }

        protected virtual void CrossoverChromosome(CrossoverChromosome<T> message)
        {
            var crossover = message.Crossover;
            var newChromosome = crossover.CrossoverParents(message.Parents, message.CrossoverConfig);
            Sender.Tell(new SucceededCrossoverChromosome<T>(newChromosome));
        }
    }
}
