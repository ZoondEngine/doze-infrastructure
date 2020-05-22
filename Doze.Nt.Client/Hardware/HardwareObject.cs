using Doze.Nt.Client.Hardware.Components;

namespace Doze.Nt.Client.Hardware
{
    public class HardwareObject : DozeObject
    {
        public HardwareObject()
        {
            AddComponent<LocaleHardwareComponent>();
            AddComponent<HardwareCollectorComponent>();
        }

        public string GetHardwareIdentifier()
            => GetComponent<HardwareCollectorComponent>().GenerateIdentifier();

        public LocaleHardwareComponent GetLocale()
            => GetComponent<LocaleHardwareComponent>();

        /// <summary>
        /// aka <see cref="LocaleHardwareComponent.GetShortLocale"/>
        /// </summary>
        /// <returns></returns>
        public string GetTwoLetterLocaleCode()
            => GetLocale().GetShortLocale();
    }
}
