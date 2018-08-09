using Akka.Actor;
using Autofac;
using GeneticAkka.Actors;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Algorithms;
using GeneticAkka.Binary.Models;
using GeneticAkka.Configs;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GeneticAkka.Binary.IOC
{
    public class GlobalAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(GlobalAutofacModule)
              .GetTypeInfo()
              .Assembly;

            builder.InitializeGeneticAkka<BinaryChromosome>(assembly);
        }
    }
}
