namespace WinFormsApp1
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            SendButton = new Button();
            ((System.ComponentModel.ISupportInitialize) dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize) bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(49, 50);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(708, 357);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.CausesValidationChanged += dataGridView1_CausesValidationChanged;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(682, 415);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 1;
            SendButton.Text = "Invia";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SendButton);
            Controls.Add(dataGridView1);
            Name = "FormMain";
            Text = "Form1";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            Shown += FormMain_Shown;
            ((System.ComponentModel.ISupportInitialize) dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize) bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private Button SendButton;
    }
}
