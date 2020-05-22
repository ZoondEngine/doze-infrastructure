using Doze.Components;
using System.Globalization;
using System.Threading;

namespace Doze.Nt.Client.Hardware.Components
{
    public class LocaleHardwareComponent : DozeComponent
    {
        private CultureInfo Culture;

        public override void Awake()
        {
            Culture = Thread.CurrentThread.CurrentCulture;
        }

        public CultureInfo GetCulture()
            => Culture;

        public string GetShortLocale()
            => Culture.TwoLetterISOLanguageName;

        public int GetLocaleCode()
            => Culture.LCID;
    }
}
