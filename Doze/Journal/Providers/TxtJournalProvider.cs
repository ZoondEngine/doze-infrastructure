using Doze.Journal.Contracts;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Doze.Journal.Providers
{
    public class TxtJournalProvider : IJournalProvider
    {
        private struct TxtJournalObject
        {
            public object What { get; private set; }
            public JournalingLevel Level { get; private set; }

            public TxtJournalObject(object what, JournalingLevel level)
            {
                What = what;
                Level = level;
            }
        }

        private ConcurrentStack<TxtJournalObject> JournalObjectsCache { get; set; }

        public void ImmediateWrite(object what, JournalingLevel level)
        {
            var journal = DozeObject.FindObjectOfType<JournalObject>();
            if(journal == null)
            {
                throw new NullReferenceException($"Journal object can't be null for ImmediateWrite from TxtJournalProvider!");
            }

            var settings = journal.GetSettingsContainer();
            if(settings == null)
            {
                throw new NullReferenceException($"Journal object settings can't be null for ImmediateWrite from TxtJournalProvider!");
            }

            if(!Directory.Exists(settings.Dir))
            {
                Directory.CreateDirectory(settings.Dir);
            }

            var file = settings.Dir + "\\" + settings.FileNameAssociates[(int)level] + $".{settings.FilesExtension}";
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }

            using FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            var bytes = Encoding.UTF8.GetBytes(what.ToString());
            fs.Write(bytes, 0, bytes.Length);
        }

        public void Save()
        {
            for(var i = 0; i < JournalObjectsCache.Count; i++)
            {
                if(JournalObjectsCache.TryPop(out var result))
                {
                    ImmediateWrite(result.What, result.Level);
                }
            }

            if (!JournalObjectsCache.IsEmpty)
            {
                Save();
            }
        }

        public void Write(object what, JournalingLevel level)
        {
            if(level >= JournalingLevel.Error)
            {
                ImmediateWrite(what, level);
            }
            else
            {
                JournalObjectsCache.Push(new TxtJournalObject(what, level));
            }
        }

        public void Load()
        {
            JournalObjectsCache = new ConcurrentStack<TxtJournalObject>();
        }
    }
}
