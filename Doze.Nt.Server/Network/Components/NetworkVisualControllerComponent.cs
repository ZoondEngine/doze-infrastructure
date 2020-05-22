using Doze.Components;
using Doze.Nt.Windows;

namespace Doze.Nt.Server.Network.Components
{
    public class NetworkVisualControllerComponent : DozeComponent
    {
        private NetworkObject Parent;
        private WindowsObject VisualObjectManager;

        public override void Awake()
        {
            Parent = ReinterpretObject<NetworkObject>(ParentObject);
            VisualObjectManager = FindObjectOfType<WindowsObject>();
        }

        public override void Update()
        {
            var service = Parent.GetService();
            if (service != null)
            {
                VisualObjectManager.ExecuteCode<WindowGeneralForm>("window-general:form", (window) =>
                {
                    window.SetServerIndicator(service.IsRunned());
                });
            }
        }
    }
}
