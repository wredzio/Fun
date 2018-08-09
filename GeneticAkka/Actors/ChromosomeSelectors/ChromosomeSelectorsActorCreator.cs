using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeSelectors
{
    public class ChromosomeSelectorsActorCreator<T> : ActorCreator<ChromosomeSelector<T>> where T : IChromosome
    {
    }
}
