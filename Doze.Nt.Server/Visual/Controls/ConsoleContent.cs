using System;
using System.Windows.Forms;
using Doze.Nt.Server.Log;
using Guna.UI2.WinForms;
using Doze.Nt.Server.Terminal;
using Doze.Nt.Windows.Interface;

namespace Doze.Nt.Server.Visual.Controls
{
    public partial class ConsoleContent : UserControl, IManagedWindow
    {
        private Form ParentControl { get; set; }
        private TerminalObject Terminal { get; set; }
        private BaseLog Log { get; set; }
        private bool Initialized { get; set; }

        public ConsoleContent(Form parent)
        {
            InitializeComponent();

            ParentControl = parent;
            ConsoleModeComboBox.SelectedIndex = 0;

            Initialized = false;
        }

        public void OnExit()
        {
            //throw new NotImplementedException();
        }

        public void OnHide()
        {
            //throw new NotImplementedException();
        }

        public void OnLoading()
        {
            //throw new NotImplementedException();
        }

        public void OnVisible()
        {
            if (!Initialized)
            {
                Terminal = Program.AppContext.GetTerminal();
                Log = Program.AppContext.GetLog();

                Log.WriteLine($"Terminal library loaded '{Terminal.GetCommands().Count}' commands", LogLevel.Info);
                Log.WriteLine($"Type '.help' for getting more information", LogLevel.Info);

                Initialized = true;
            }
        }

        Form IManagedWindow.Parent()
            => ParentControl;

        public bool IsAllowedToOut(LogLevel level)
        {
            var selectedIndex = ConsoleModeComboBox.SelectedIndex;
            if (selectedIndex == 0 || selectedIndex == -1)
                return true;

            return selectedIndex == (int)level;
        }

        private void ConsoleContent_Load(object sender, EventArgs e)
        {
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Lock();

            Log.WriteLine($"process '{ConsoleInputBox.Text}' ...", LogLevel.Info);
            SendButton.Enabled = false;

            var result = await Terminal.Process(ConsoleInputBox.Text);
            ConsoleInputBox.Text = "";

            if (result.ExecutingResult != CommandExecutingResult.Success)
            {
                Log.WriteLine($"{result.ExecutingResult}: {result.Response}", LogLevel.Error);
            }
            else
            {
                Log.WriteLine($"{result.ExecutingResult}: {result.Response}", LogLevel.Info);
            }

            Unlock();
        }

        private void Lock()
        {
            ConsoleInputBox.Enabled = false;
        }

        private void Unlock()
        {
            ConsoleInputBox.Enabled = true;
        }

        private void ConsoleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = (Guna2ComboBox)sender;
            var selectedIndex = box.SelectedIndex;

            ConsoleTextBox.Clear();

            if (selectedIndex == 0)
            {
                if(Initialized)
                    Log.WriteLine($"You set display mode to 'All'", LogLevel.Info);
            }
            else 
            {
                if (Initialized)
                    Log.WriteLine($"You set display mode to '{(LogLevel)selectedIndex}'", (LogLevel)selectedIndex);
            }
        }

        private void ConsoleContent_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(ConsoleInputBox.Text.Length > 0)
                {
                    guna2GradientButton1_Click(null, null);
                }
                else
                {
                    ConsoleInputBox.Text = "";
                    SendButton.Enabled = false;
                }
            }
        }

        private void ConsoleInputBox_TextChanged(object sender, EventArgs e)
        {
            var inputBox = (Guna2TextBox)sender;
            if(inputBox != null)
            {
                if (inputBox.Text.Length > 0)
                    SendButton.Enabled = true;
                else
                    SendButton.Enabled = false;
            }
        }

        private void ConsoleInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            ConsoleContent_KeyDown(null, e);
        }
    }
}
