using Doze.Nt.Client.Core.Errors.AssertionEvents;
using Doze.Nt.Client.Core.Errors.Reports;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Core.Errors
{
    public delegate bool AssertionDelegate();
    public delegate void AssertionThrowHandle(CoreErrorObject errorCore);

    public class CoreErrorObject : DozeClientManagedObject
    {
        public CoreErrorObject() : base()
        {
            AddComponent<AssertionEventsComponent>();
        }

        public CoreErrorObject(string tag) : base(tag)
        {
            AddComponent<AssertionEventsComponent>();
        }
        public void Throw<T>(T ex) where T : BaseDozeException
        {
            //TODO: logging and set manage to 'throw'
            throw ex;
        }

        public void Crash<T>(T ex) where T : BaseDozeException
        {
            //TODO: logging, handle crash, disable visual components and go away
            Environment.Exit(ex.GetHashCode());
        }

        public void SecureReportableError<T>(T ex) where T : BaseReport
        {

        }

        public void ReportServer<T>(T ex) where T : BaseReport
        {
            //TODO: reporting server throwed local exception and go away
            using(FileStream fs = File.Create($"report_{DateTime.Now.ToFileTime()}"))
            {
                var bytes = Encoding.UTF8.GetBytes(ex.ToTextFormat());
                fs.Write(bytes, 0, bytes.Length);
            }

            Environment.Exit(ex.GetHashCode());
        }

        public async Task ReportServerAsync<T>(T ex) where T : BaseReport
        {
            //TODO: reporting server throwed local exception and go away
            using (FileStream fs = File.Create($"report_{DateTime.Now.ToFileTime()}"))
            {
                var bytes = Encoding.UTF8.GetBytes(await ex.ToTextFormatAsync());
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }

            Environment.Exit(ex.GetHashCode());
        }

        public void AddAssertion(AssertionDelegate assert, AssertionThrowHandle handle)
            => GetComponent<AssertionEventsComponent>().AddAssertion(assert, handle);
    }
}
