namespace WinFormsApp1
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonLogin = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ErrorLabel = new Label();
            SuspendLayout();
            // 
            // ButtonLogin
            // 
            ButtonLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonLogin.Location = new Point(233, 203);
            ButtonLogin.Margin = new Padding(3, 4, 3, 4);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(86, 31);
            ButtonLogin.TabIndex = 0;
            ButtonLogin.Text = "Login";
            ButtonLogin.UseVisualStyleBackColor = true;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(35, 95);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(286, 27);
            textBox2.TabIndex = 2;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(33, 149);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(50, 20);
            ErrorLabel.TabIndex = 3;
            ErrorLabel.Text = "label1";
            ErrorLabel.Visible = false;
            // 
            // FormLogin
            // 
            AcceptButton = ButtonLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 260);
            Controls.Add(ErrorLabel);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(ButtonLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonLogin;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label ErrorLabel;
    }
}