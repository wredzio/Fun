using Akka.Actor;
using Autofac;
using GeneticAkka.Actors;
using GeneticAkka.Actors.ChromosomeBuilders;
using GeneticAkka.Actors.Populations;
using GeneticAkka.Algorithms;
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
                .AsClosedTypesOf(typeof(Algorithm<>));

            containerBuilder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(Population<>));

            containerBuilder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ChromosomeBuilder<>));

            containerBuilder.RegisterType<PopulationActorCreator<T>>()
               .As<ActorCreator<Population<T>>>()
               .SingleInstance();

            containerBuilder.RegisterType<ChromosomeBuilderActorCreator<T>>()
               .As<ActorCreator<ChromosomeBuilder<T>>>()
               .SingleInstance();

            var _runModelActorSystem = new Lazy<ActorSystem>(() =>
            {
                return ActorSystem.Create("MySystem");
            });

            containerBuilder.Register(cont => _runModelActorSystem.Value);
        }
    }
}
