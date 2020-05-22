using Doze.Components;
using Doze.Nt.Windows.Interface;
using System.Windows.Forms;

namespace Doze.Nt.Windows.Components
{
    public class WindowStateComponent : DozeComponent
    {
        private bool ExecutingExit { get; set; } = false;

        public override void Update()
        {
            if (ExecutingExit)
            {
                var visualObjectManager = ReinterpretObject<WindowsObject>(ParentObject);
                foreach (var visualObject in visualObjectManager.GetCachedObjects())
                {
                    visualObjectManager.ExecuteCode<IManagedWindow>(visualObject.GetName(), (obj) =>
                    {
                        obj.OnExit();
                    });
                }

                Destroy();
            }
            else
            {
                var visualObjectManager = ReinterpretObject<WindowsObject>(ParentObject);
                var cachedObjects = visualObjectManager.GetCachedObjects();
                if (cachedObjects != null)
                {
                    try
                    {
                        foreach (var visualObject in cachedObjects)
                        {
                            if (visualObject.GetState() == WindowVisualState.Hidden)
                            {
                                visualObjectManager.ExecuteCode<IManagedWindow>(visualObject.GetName(), (obj) =>
                                {
                                    obj.OnHide();
                                });
                            }

                            if (visualObject.GetState() == WindowVisualState.Loading)
                            {
                                visualObjectManager.ExecuteCode<IManagedWindow>(visualObject.GetName(), (obj) =>
                                {
                                    obj.OnLoading();
                                });
                            }

                            if (visualObject.GetState() == WindowVisualState.Visible)
                            {
                                visualObjectManager.ExecuteCode<IManagedWindow>(visualObject.GetName(), (obj) =>
                                {
                                    obj.OnVisible();
                                });
                            }
                        }
                    }
                    catch
                    { 
                        return; 
                    }
                }
            }
        }

        public override void Destroy()
            => ParentObject.Destroy();

        public void ExecuteExit()
            => ExecutingExit = true;
    }
}
