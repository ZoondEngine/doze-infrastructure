using Doze.Nt.Client.Hardware;
using Doze.Nt.Client.Network;
using Doze.Nt.Windows;
using Doze.Nt.Windows.Interface;
using Guna.UI2.WinForms;
using Jareem.Network.Packets;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doze.Nt.Client
{
    public partial class Login : Form, IManagedWindow
    {
        private bool IsInitialized { get; set; } = false;
        private bool IsLoginAttempt { get; set; } = false;
        private bool IsLoadingNow { get; set; } = false;
        private WindowsObject WindowManager { get; set; }
        private bool IsHidden { get; set; } = false;
        private LoginContext LoginCtx { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        public void OnExit()
        {
            //throw new NotImplementedException();
        }

        public void OnHide()
        {
            if(!IsHidden)
            {
                IsHidden = true;
            }

            Hide();
        }

        public async void OnLoading()
        {
            if (IsLoadingNow)
                return;

            IsLoadingNow = true;

            LoginButton.Enabled = false;
            ShadowPanel.Visible = true;
            LoginProgressIndicator.Visible = true;
            CreateAccountLink.Enabled = false;
            ForgotAccountLink.Enabled = false;

            if (!IsInitialized && !IsLoginAttempt)
            {
                LoadingStatusText.Text = "initializing secure handshake";
                WindowManager = DozeObject.FindObjectOfType<WindowsObject>();
                LoginCtx = DozeObject.FindObjectOfType<LoginContext>();

                if(LoginCtx == null)
                {
                    LoginCtx = DozeObject.Create<LoginContext>();
                }

                if (await LoginCtx.ConnectAsync())
                {
                    DozeObject.FindObjectOfType<WindowsObject>().SetState("window-general:login", WindowVisualState.Visible);
                }
                else
                {
                    LoadingStatusText.Text = "connection timeout";
                }
            }

            if(IsLoginAttempt)
            {
                LoadingStatusText.Text = "request auhtorization";

                if(!TryGetTextBoxString(LoginTextBox, out string login, () =>
                {
                    LoginTextBox.Text = "";
                    LoginTextBox.PlaceholderText = "this field can't be empty!";
                    PasswordTextBox.Text = "";

                    SetState(WindowVisualState.Visible);
                    IsLoginAttempt = false;
                }))
                {
                    return;
                }

                if (!TryGetTextBoxString(PasswordTextBox, out string password, () =>
                {
                    LoginTextBox.Text = "";
                    PasswordTextBox.PlaceholderText = "this field can't be empty!";
                    PasswordTextBox.Text = "";

                    SetState(WindowVisualState.Visible);
                    IsLoginAttempt = false;
                }))
                {
                    return;
                }

                var loginAttemptResult = await LoginCtx.LoginAttemptAsync(login, password);
                if (loginAttemptResult.AttemptResult == LoginAttemptResult.Ok)
                {
                    var cachedWindow = WindowManager.CacheOrGetOriginalObject(new MainWindow(), "window-general:main");

                    Hide();
                    cachedWindow.FormClosed += (e, args) => { Close(); };
                    cachedWindow.Show();
                }
                else
                {
                    MessageBox.Show(loginAttemptResult.Message, "Authenticate error");
                    SetState(WindowVisualState.Visible);
                }

                IsLoginAttempt = false;
            }

            IsLoadingNow = false;
        }

        public void OnVisible()
        {
            if (IsHidden)
            {
                IsHidden = false;
                Show();
            }

            LoginButton.Enabled = true;
            ShadowPanel.Visible = false;
            LoginProgressIndicator.Visible = false;
            CreateAccountLink.Enabled = true;
            ForgotAccountLink.Enabled = true;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            IsLoginAttempt = true;
            SetState(WindowVisualState.Loading);
        }

        Form IManagedWindow.Parent()
        {
            return this;
        }

        private void SetState(WindowVisualState state)
        {
            if(WindowManager == null)
            {
                WindowManager = DozeObject.FindObjectOfType<WindowsObject>();
            }

            WindowManager.SetState("window-general:login", state);
        }

        private bool TryGetTextBoxString(Guna2TextBox box, out string result, Action failureCallback)
        {
            if (box.Text == "" || box.Text == string.Empty)
            {
                failureCallback();

                result = "";
                return false;
            }

            result = box.Text;
            return true;
        }
    }
}
