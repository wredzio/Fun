using Akka.Actor;
using Autofac;
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

            var _runModelActorSystem = new Lazy<ActorSystem>(() =>
            {
                return ActorSystem.Create("MySystem");
            });

            builder.Register<ActorSystem>(cont => _runModelActorSystem.Value);
        }
    }
}
