using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Populations
{
    public class PopulationActorCreator<T>: ActorCreator<Population<T>> where T : IChromosome
    {
    }
}
