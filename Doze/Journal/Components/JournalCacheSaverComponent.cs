using Doze.Components;
using Doze.Journal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Journal.Components
{
    public class JournalCacheSaverComponent : DozeComponent
    {
        private JournalObject ParentJournalObject;

        public override void Awake()
        {
            ParentJournalObject = ReinterpretObject<JournalObject>(ParentObject);
        }

        public override void BeforeDestroy()
        {
            foreach(var item in ParentJournalObject.GetProviders())
            {
                item.Save();
            }
        }

        public override void Destroy()
        {
            BeforeDestroy();
        }
    }
}
