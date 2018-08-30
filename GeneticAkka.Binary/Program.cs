using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using GeneticAkka.Algorithms.Crossovers;
using GeneticAkka.Algorithms.Messages;
using GeneticAkka.Algorithms.Models;
using GeneticAkka.Algorithms.Selections;
using GeneticAkka.Binary.IOC;
using GeneticAkka.Binary.Models;
using System;

namespace GeneticAkka.Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ContainerOperations.Instance.Container.Resolve<ActorSystem>();
            IDependencyResolver resolver = new AutoFacDependencyResolver(ContainerOperations.Instance.Container, system);
            var myBinaryAlgorithmActor = system.ActorOf(system.DI().Props<BinaryAlgorithm>(), "Algorithm");

            myBinaryAlgorithmActor.Tell(new Run<BinaryChromosome>(new AlgorithmConfig<BinaryChromosome>(2, 1, 10000, 5000, 5, new RankingSelection<BinaryChromosome>(), new BinaryCrossover(), new CrossoverConfig(80, 2))));

            Console.ReadKey();
        }
    }
}
