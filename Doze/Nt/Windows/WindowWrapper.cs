using Doze.Nt.Windows.Interface;

namespace Doze.Nt.Windows
{
    public class WindowWrapper
    {
        private string Name { get; set; }
        private IManagedWindow InternalObject { get; set; }
        private WindowVisualState CurrentState { get; set; }

        public WindowWrapper(string name, IManagedWindow obj) : this(name, obj, WindowVisualState.Visible)
        { }

        public WindowWrapper(string name, IManagedWindow obj, WindowVisualState state)
        {
            Name = name;
            InternalObject = obj;
            CurrentState = state;
        }

        public T Original<T>() where T : IManagedWindow
            => (T)InternalObject;
        public IManagedWindow Reserved()
            => InternalObject;
        public WindowVisualState GetState()
            => CurrentState;
        public void SetState(WindowVisualState state)
            => CurrentState = state;
        public string GetName()
            => Name;
    }
}
