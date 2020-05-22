using System.Windows.Forms;

namespace Doze.Nt.Windows.Interface
{
    public interface IManagedWindow
    {
        void OnVisible();
        void OnHide();
        void OnLoading();
        void OnExit();

        Form Parent();
    }
}
