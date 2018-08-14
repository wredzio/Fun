using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GeneticAkka.Algorithms.Selections
{
    public class RankingSelection<T> : ISelection<T> where T : IChromosome
    {
        protected Random _rand;

        public RankingSelection()
        {
            _rand = new Random();
        }

        public Parents<T> SelectParents(ImmutableArray<T> population)
        {
            var rankPopulation = population.OrderBy(o => o.Fitness).Reverse().Take(population.Count() / 2).ToArray();
            var firstParentIndex = _rand.Next() % rankPopulation.Length;
            var secondParentIndex = _rand.Next() % rankPopulation.Length;

            return new Parents<T>(
                rankPopulation[firstParentIndex],
                rankPopulation[secondParentIndex]
            );
        }
    }
}
