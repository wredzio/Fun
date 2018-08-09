﻿using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Algorithms.Messages
{
    public class Run
    {
        public Run(AlgorithmConfig algorithmConfig)
        {
            AlgorithmConfig = algorithmConfig;
        }

        public AlgorithmConfig AlgorithmConfig { get; }
    }
}
