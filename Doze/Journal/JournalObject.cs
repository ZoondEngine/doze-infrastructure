using Doze.Journal.Components;
using Doze.Journal.Configuration;
using Doze.Journal.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Doze.Journal
{
    public class JournalObject : DozeObject
    {
        private List<IJournalProvider> RegisteredJournalProviders { get; set; }
        private JournalConfigurationContainer Settings { get; set; }
        private JournalConfigurationBuilder SettingsBuilder { get; set; }

        public JournalObject()
            : base()
        { }

        public JournalObject(string tag)
            : base(tag)
        { }

        public void Run(bool readPlugins)
        {
            if(Settings == null)
            {
                Configure(null);
            }

            ReadAllProviders(readPlugins);
            AddComponent<JournalCacheSaverComponent>();
        }

        public void Configure(Action<JournalConfigurationBuilder> configureFunctor, bool defaults = true)
        {
            if(SettingsBuilder == null)
            {
                SettingsBuilder = new JournalConfigurationBuilder();
            }

            if (configureFunctor == null)
                return;

            configureFunctor(SettingsBuilder);
            Settings = SettingsBuilder.GetContainer();
        }

        public void AddProvider<T>() where T : IJournalProvider, new()
        {
            T obj = new T();
            obj.Load();

            RegisteredJournalProviders.Add(obj);
        }

        private void ReadAllProviders(bool readFromOnlyCurrentAssembly = false)
        {
            RegisteredJournalProviders = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(m => m.GetInterfaces().Contains(typeof(IJournalProvider)))
                .Select(m => m.GetConstructor(Type.EmptyTypes).Invoke(null) as IJournalProvider)
                .ToList();

            if(!readFromOnlyCurrentAssembly)
            {
                var files = Directory.GetFiles("plugins\\log\\providers\\", "*.dll");
                if (files.Length <= 0)
                    return;

                foreach(var file in files)
                {
                    try
                    {
                        var assembly = Assembly.LoadFile(file);
                        if(assembly != null)
                        {
                            var providers = assembly.GetTypes().Where((x) => x.GetInterfaces().Contains(typeof(IJournalProvider)))
                                .Select((x) => x.GetConstructor(Type.EmptyTypes)?.Invoke(null) as IJournalProvider)
                                .ToList();

                            foreach(var provider in providers)
                            {
                                RegisteredJournalProviders.Add(provider);
                            }
                        }
                    }
                    catch
                    { } // ignore
                }
            }

            foreach(var item in RegisteredJournalProviders)
            {
                item.Load();
            }
        }

        public List<IJournalProvider> GetProviders()
            => RegisteredJournalProviders.ToList();

        public T GetProviderByType<T>() where T : IJournalProvider
            => (T)RegisteredJournalProviders.FirstOrDefault((x) => x.GetType() == typeof(T));

        public void WriteAll(object what, JournalingLevel level)
            => RegisteredJournalProviders.ForEach((x) => x.Write(what, level));
        public void ImmediateWriteAll(object what, JournalingLevel level)
            => RegisteredJournalProviders.ForEach((x) => x.ImmediateWrite(what, level));

        public void WriteToProvider<T>(object what, JournalingLevel level) where T : IJournalProvider
        {
            var provider = GetProviderByType<T>();
            if(provider != null)
            {
                provider.Write(what, level);
            }
        }
        public void ImmediateWriteToProvider<T>(object what, JournalingLevel level) where T : IJournalProvider
        {
            var provider = GetProviderByType<T>();
            if (provider != null)
            {
                provider.ImmediateWrite(what, level);
            }
        }

        public JournalConfigurationContainer GetSettingsContainer()
            => Settings;
    }
}
