using Doze.Components;
using Doze.Nt.Server.Database.Settings;
using Doze.Nt.Server.Visual.Controls;
using Doze.Nt.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Doze.Nt.Server.Database.Components
{
    public class UpdatableControl
    {
        private Control ReflectedControl { get; set; }
        private Action<Control> ReferencedControlChangeCallback { get; set; }

        public string ControlName { get; }

        public UpdatableControl(string controlName, Action<Control> callback)
        {
            ControlName = controlName;
            ReferencedControlChangeCallback = callback;
        }

        public void Call()
            => ReferencedControlChangeCallback?.Invoke(ReflectedControl ?? throw new Exception("Invalid control inputed for changing!"));

        public void SetControl(Control control)
            => ReflectedControl = control;
    }

    public class DatabaseVisualUpdaterComponent : DozeComponent
    {
        private DatabaseSettingsPlaceholder Settings { get { return Parent?.GetSettings(); } }
        private DatabaseObject Parent { get; set; }
        private List<UpdatableControl> UpdatableControls { get; set; }

        public override void Awake()
        {
            Parent = ReinterpretObject<DatabaseObject>(ParentObject);
            UpdatableControls = new List<UpdatableControl>();
        }

        public override void Update()
        {
            if (Settings != null)
            {
                if (Settings.Read<bool>("enable", "statistics") == false)
                    return;

                if (UpdatableControls.Count == 0)
                    return;

                var windowsObject = FindObjectOfType<WindowsObject>();
                if(windowsObject != null)
                {
                    windowsObject.ExecuteCode<DatabaseStatusContent>("control-general:database_status", (databaseContent) =>
                    {
                        var fields = databaseContent.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                        foreach(var field in fields)
                        {
                            var existedUpdatableControl = UpdatableControls.FirstOrDefault((x) => x.ControlName.ToLower() == field.Name.ToLower());
                            if (existedUpdatableControl != null)
                            {
                                existedUpdatableControl.SetControl((Control)field.GetValue(databaseContent));
                                existedUpdatableControl.Call();
                            }
                        }
                    });
                }
                else
                {
                    Parent.GetLog().WriteLine($"Can't update visual state because windows object not found for getting cached window!", Log.LogLevel.Error);
                }
            }
        }

        public void AddUpdatabableControl(UpdatableControl item)
        {
            if(!UpdatableControls.Contains(item))
            {
                UpdatableControls.Add(item);
            }
        }
    }
}
