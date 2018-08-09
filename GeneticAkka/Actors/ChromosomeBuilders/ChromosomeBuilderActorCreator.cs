using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.ChromosomeBuilders
{
    public class ChromosomeBuilderActorCreator<T> : ActorCreator<ChromosomeBuilder<T>> where T : IChromosome
    {
    }
}
