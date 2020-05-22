using Doze.Nt.Windows.Components;
using Doze.Nt.Windows.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Doze.Nt.Windows
{
    public enum WindowVisualState
    {
        Visible,
        Loading,
        Hidden,
    }

    public class WindowsObject : DozeObject
    {
        private List<WindowWrapper> CachedVisualObjects { get; set; } = new List<WindowWrapper>();

        public WindowsObject()
        {
            AddComponent<WindowStateComponent>();
        }

        public WindowsObject(string tag) : base(tag)
        {
            AddComponent<WindowStateComponent>();
        }

        public override void Destroy()
        {
            CachedVisualObjects.Clear();
        }

        public List<WindowWrapper> GetCachedObjects()
            => CachedVisualObjects;

        public T GetOriginalObject<T>(string name) where T : IManagedWindow
        {
            var obj = GetVisualObject(name);
            if (obj != null)
                return obj.Original<T>();

            return default;
        }

        public WindowWrapper GetVisualObject(string name)
            => CachedVisualObjects.FirstOrDefault((x) => x.GetName().ToLower() == name.ToLower());

        public void CacheObject(IManagedWindow obj, string name)
            => CachedVisualObjects.Add(new WindowWrapper(name, obj));

        public void CacheObject(IManagedWindow obj, string name, WindowVisualState state)
            => CachedVisualObjects.Add(new WindowWrapper(name, obj, state));

        public void RemoveObject(WindowWrapper wrapper)
            => CachedVisualObjects.Remove(wrapper);

        public void SetState(string name, WindowVisualState state)
        {
            var @object = GetVisualObject(name);
            if (@object != null)
                @object.SetState(state);
        }

        public void SetState(WindowVisualState state)
            => CachedVisualObjects.ForEach((x) => x.SetState(state));

        public T CacheOrGetOriginalObject<T>(T obj, string name) where T : IManagedWindow
        {
            var founded = GetOriginalObject<T>(name);
            if (founded == null)
            {
                CacheObject(obj, name);
                founded = GetOriginalObject<T>(name);
            }

            return founded;
        }

        public void ExecuteCode<T>(string name, Action<T> action) where T : IManagedWindow
        {
            var original = GetOriginalObject<T>(name);
            if (original != null)
            {
                var obj = original.Parent();
                if (obj != null)
                {
                    try
                    {
                        obj.BeginInvoke((MethodInvoker)(() =>
                        {
                            action(original);
                        }));
                    }
                    catch
                    {
                        //Ingore ...
                    }
                }
            }
        }
    }
}
