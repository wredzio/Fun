using GeneticAkka.Algorithms.Models;
using GeneticAkka.Algorithms.Selections;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors.Populations.SelectParents.Messages
{
    public class SelectParents<T> where T : IChromosome
    {
        public SelectParents(int replaceByGeneration, ISelection<T> selection)
        {
            ReplaceByGeneration = replaceByGeneration;
            Selection = selection;
        }

        public int ReplaceByGeneration { get; }
        public ISelection<T> Selection { get; }
    }
}
