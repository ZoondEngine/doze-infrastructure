using System.Collections.Generic;

namespace Doze.Journal.Configuration
{
    public class JournalConfigurationContainer
    {
        public string Dir { get; set; }
        public Dictionary<int, string> FileNameAssociates { get; set; }
        public string FilesExtension { get; set; }

        public JournalConfigurationContainer(bool defaults)
        {
            FileNameAssociates = new Dictionary<int, string>();

            if(defaults)
            {
                Dir = "logs";
                FilesExtension = ".djl";
                FileNameAssociates.Add(1, "trace");
                FileNameAssociates.Add(2, "debug");
                FileNameAssociates.Add(3, "warning");
                FileNameAssociates.Add(4, "error");
                FileNameAssociates.Add(5, "exception");
                FileNameAssociates.Add(6, "critical");
                FileNameAssociates.Add(7, "panic");
            }
        }
    }
}
