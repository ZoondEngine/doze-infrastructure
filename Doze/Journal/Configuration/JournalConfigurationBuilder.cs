using System.Collections.Generic;

namespace Doze.Journal.Configuration
{
    public class JournalConfigurationBuilder
    {
        private JournalConfigurationContainer Container { get; set; }

        public JournalConfigurationBuilder(bool useDefaults = true)
        {
            Container = new JournalConfigurationContainer(useDefaults);
        }

        public JournalConfigurationBuilder BuildAssoc(Dictionary<int, string> fileNames)
        {
            Container.FileNameAssociates = fileNames;

            return this;
        }

        public JournalConfigurationBuilder UseSingleAssoc(string assocFileName)
        {
            Dictionary<int, string> names = new Dictionary<int, string>()
            {
                [1] = assocFileName,
                [2] = assocFileName,
                [3] = assocFileName,
                [4] = assocFileName,
                [5] = assocFileName,
                [6] = assocFileName,
                [7] = assocFileName,
            };

            Container.FileNameAssociates = names;

            return this;
        }

        public JournalConfigurationBuilder UseExtension(string extName)
        {
            Container.FilesExtension = extName;

            return this;
        }

        public JournalConfigurationContainer GetContainer()
            => Container;
    }
}
