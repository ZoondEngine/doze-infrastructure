using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Components
{
    public class DozeComponent : DozeObject
    {
        public DozeObject ParentObject;
        public TimeSpan CurrentTickTime;
        public TimeSpan PreviousTickTime;

        public virtual void Awake()
        { }

        public virtual void Update()
        { }

        public virtual void BeforeDestroy()
        { }
    }
}
