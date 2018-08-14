using Akka.Actor;
using GeneticAkka.Actors.ChromosomeSelectors.Messages;
using GeneticAkka.Algorithms.Models;

namespace GeneticAkka.Actors.ChromosomeSelectors
{
    public abstract class ChromosomeSelector<T> : ReceiveActor where T : IChromosome
    {
        public ChromosomeSelector()
        {
            Receive<SelectChromosome<T>>(message => SelectChromosome(message));
        }

        protected virtual void SelectChromosome(SelectChromosome<T> message)
        {
            var selection = message.Selection;
            var selectedChromosome = selection.SelectParents(message.Chromosomes);
            Sender.Tell(new SucceededSelectChromosome<T>(selectedChromosome, message.Index));
        }
    }
}
