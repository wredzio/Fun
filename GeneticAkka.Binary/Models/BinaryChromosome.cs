﻿using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Binary.Models
{
    public class BinaryChromosome : IChromosome
    {
        private int power = 30;
        private int left = -2;
        private int right = 2;

        int gens = 0;

        public float Fitness { get; private set; }

        public BinaryChromosome()
        {
            Random rand = new Random();
            int poe = Convert.ToInt32(Math.Pow(2, power));

            gens = rand.Next(0, poe);
        }

        private double f(double x) => Math.Cos(x / (2 * Math.PI)) + Math.Sin(2 * x * (Math.PI));

        private double toLimit(int r) => left + Math.Abs(left - right) * r / (Math.Pow(2, power) - 1);

        public float CalculateFitness()
        {
            Fitness = (float)f(toLimit(gens));
            return Fitness;
        }

        public int CompareTo(IChromosome other)
        {
            if (this.Fitness > other.Fitness) return -1;
            if (this.Fitness == other.Fitness) return 0;
            return 1;
        }
    }
}
