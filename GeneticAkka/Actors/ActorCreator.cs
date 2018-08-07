using Akka.Actor;
using Akka.DI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAkka.Actors
{
    public abstract class ActorCreator<T> where T : ActorBase
    {
        protected Dictionary<string, Func<IUntypedActorContext, Props>> _propLookup =
           new Dictionary<string, Func<IUntypedActorContext, Props>>();

        public virtual Props GetChild(string actorNameKey, IUntypedActorContext context)
        {
            return _propLookup[actorNameKey](context);
        }

        public virtual void CreateChild(string name)
        {
            _propLookup.Add(name, (context) => context.DI().Props<T>());
        }
    }
}
