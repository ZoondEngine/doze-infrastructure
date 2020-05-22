using Doze.Components;
using System.Collections.Generic;
using System.Linq;

namespace Doze.Nt.Client.Core.Errors.AssertionEvents
{
    public class AssertionEventsComponent : DozeComponent
    {
        private Dictionary<AssertionDelegate, AssertionThrowHandle> AssertionDelegates { get; set; }
        private CoreErrorObject Parent { get; set; }

        public override void Awake()
        {
            AssertionDelegates = new Dictionary<AssertionDelegate, AssertionThrowHandle>();
            Parent = ParentObject.ReinterpretObject<CoreErrorObject>();
        }

        public override void Update()
        {
            foreach(var assert in AssertionDelegates.Where((x) => x.Key() == true).ToList())
            {
                assert.Value(Parent);
                AssertionDelegates.Remove(assert.Key);
            }
        }

        public void AddAssertion(AssertionDelegate @delegate, AssertionThrowHandle handle)
            => AssertionDelegates.Add(@delegate, handle);
    }
}
