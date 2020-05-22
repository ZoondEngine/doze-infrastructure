using Doze.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Doze
{
    public static class DozeObjectManager
    {
        private static List<DozeObject> GlobalObjectsList { get; set; } = new List<DozeObject>();
        private static Thread GlobalListTickIteration { get; set; } = new Thread(Iteration, 32 * 1024 * 1024);
        private static TimeSpan OldTickTime { get; set; }

        public static void Instantiate()
        {
            GlobalListTickIteration.IsBackground = true;
            GlobalListTickIteration.Start();
        }

        public static void Stop()
        {
            try
            {
                GlobalListTickIteration.Abort();
            }
            catch
            {
                //Ingore ...
            }
        }

        private static void Iteration()
        {
            lock (GlobalObjectsList)
            {
                Thread.Sleep(100);
                Thread.EndCriticalRegion();

                var currentTickTime = TimeSpan.FromTicks(DateTime.Now.Ticks);
                if (OldTickTime == null)
                {
                    OldTickTime = currentTickTime;
                }

                for (var i = 0; i < GlobalObjectsList.Count; i++)
                {
                    var current_obj = GlobalObjectsList[i];
                    List<DozeComponent> components = current_obj.GetObjectComponents();
                    for (var j = 0; j < components.Count; j++)
                    {
                        components[j].PreviousTickTime = OldTickTime;
                        components[j].CurrentTickTime = currentTickTime;

                        components[j].Update();
                    }
                }

                Thread.EndCriticalRegion();
            }

            Iteration();
        }

        public static T Create<T>() where T : DozeObject, new()
        {
            T obj = new T();
            GlobalObjectsList.Add(obj);

            return obj;
        }

        public static T Create<T>(string tag = "") where T : DozeObject
        {

            var constructors = typeof(T).GetConstructors();
            foreach(var construct in constructors)
            {
                var parameters = construct.GetParameters();
                if(parameters.Length == 1)
                {
                    if(parameters[0].Name.ToLower() == "tag")
                    {
                        T obj = (T)construct.Invoke(new object[] { tag });
                        if(obj != null)
                        {
                            GlobalObjectsList.Add(obj);
                            return obj;
                        }
                    }
                }
            }

            throw new InvalidOperationException($"{typeof(T).FullName} not contains constructor with tag!");
        }

        public static void Destroy<T>(string tag) where T : DozeObject
        {
            var obj = GetObjectByTag<T>(tag);

            obj.Destroy();
            GlobalObjectsList.Remove(obj);
        }

        public static T GetObjectByTag<T>(string tag) where T : DozeObject
            => (T)GlobalObjectsList.FirstOrDefault((x) => x.GetTag().ToLower() == tag.ToLower() & x.GetType() == typeof(T));

        public static T GetObjectByType<T>() where T : DozeObject
            => (T)GlobalObjectsList.FirstOrDefault((x) => x.GetType() == typeof(T));

        public static T[] GetAllObjectsByType<T>() where T : DozeObject
        {
            List<T> premade = new List<T>();
            for(var i = 0; i < GlobalObjectsList.Count; i++)
            {
                if (typeof(T) == GlobalObjectsList[i].GetType())
                    premade.Add((T)GlobalObjectsList[i]);
            }

            return premade.ToArray();
        }
    }
}
