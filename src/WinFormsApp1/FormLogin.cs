using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormLogin : Form
    {
        private readonly IAuthService _authService;

        public FormLogin(IAuthService authService, IOptions<AppConfig> options)
        {
            InitializeComponent();
            _authService = authService;
        }

        public async void ButtonLogin_Click(object sender, EventArgs e)
        {

            await ExecuteAsync(async () => 
            {
                var result = await _authService.AuthenticateAsync(textBox1.Text, "");
                return result;
            },
            start: () =>
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                ErrorLabel.Visible = false;
                ErrorLabel.Text = "";
                this.ButtonLogin.Enabled = false;
            },
            success: () =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            },
            error: (msg) =>
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                ErrorLabel.Visible = true;
                ErrorLabel.Text = msg;
                this.ButtonLogin.Enabled = true;
            }); 


        } 

        private async Task ExecuteAsync(Func<Task<(bool, string)>> function, Action start, Action success, Action<string> error)
        {
            start();

            var (ok, message) = await function();

            if (ok)
            {
                success();
            } else
            {
                error(message);
            }

        }
    }
}
