﻿using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using GeneticAkka.Algorithms.Messages;
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
            var myBinaryAlgorithmActor = system.ActorOf(system.DI().Props<BinaryAlgorithm>(), "BinaryAlgorithm");

            myBinaryAlgorithmActor.Tell(new Run());

            Console.ReadKey();
        }
    }
}