using Autofac;
using GeneticAkka.Actors;
using GeneticAkka.Actors.Creators;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GeneticAkka.Configs
{
    public static class DIConfig
    {
        public static void InitializeGeneticAkka<T>(this ContainerBuilder containerBuilder, Assembly assembly) where T : IChromosome
        {
            containerBuilder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IChromosome>())
                   .AsImplementedInterfaces().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<ChromosomeCreator<IChromosome>>())
                    .AsImplementedInterfaces().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<Population<IChromosome>>())
                    .AsImplementedInterfaces().SingleInstance();

            containerBuilder.RegisterType<PopulationActorCreator>()
               .As<ActorCreator<Population<IChromosome>>>()
               .SingleInstance();

            containerBuilder.RegisterType<ActorCreator<ChromosomeCreator<IChromosome>>>();
        }
    }
}
