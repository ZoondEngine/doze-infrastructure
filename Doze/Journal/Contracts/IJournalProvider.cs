using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Journal.Contracts
{
    public enum JournalingLevel
    {
        Trace = 1,
        Debug = 2,
        Warning = 3,
        Error = 4,
        Exception = 5,
        Critical = 6,
        Panic = 7
    }

    public interface IJournalProvider
    {
        /// <summary>
        /// Uses automatic write type immediate or cache, referenced from JournalingLevel
        /// If level > error -> used immediate writer
        /// </summary>
        /// <param name="what">What for logging, message, object, etc ...</param>
        /// <param name="level">Logging level</param>
        public void Write(object what, JournalingLevel level);

        /// <summary>
        /// Used immediate writer from write log message
        /// </summary>
        /// <param name="what">What for logging, message, object, etc ...</param>
        /// <param name="level">Logging level</param>
        public void ImmediateWrite(object what, JournalingLevel level);


        /// <summary>
        /// Load, called when provider has benn registered
        /// </summary>
        public void Load();

        /// <summary>
        /// Save, called from behaviours for saving cached messages.
        /// </summary>
        public void Save();
    }
}
