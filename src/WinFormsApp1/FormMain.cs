namespace WinFormsApp1
{
    public partial class FormMain : Form
    {
        private readonly FormLogin formLogin;
        private readonly IAuthService _authService;
        private readonly IDataService _dataService;
        private CheckBox headerCheckBox = new CheckBox();


        public FormMain(FormLogin formLogin, IAuthService authService, IDataService dataService)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            _authService = authService;
            _dataService = dataService;
        }

        private async void FormMain_Shown(object sender, EventArgs e)
        {
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                var t = _authService.Token;


                var result = await _dataService.GetDataAsync(default);

                foreach (var item in result.Items)
                {
                    bindingSource1.Add(item);

                }

            }
            else
            {

                this.Close();
            }




        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var checkboxColumn = new DataGridViewCheckBoxColumn();

            // Configurazione della CheckBox
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.Location = new Point(5, 5); // Posizione relativa all'header
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
            headerCheckBox.BringToFront();
            // Aggiungi la CheckBox al controllo DataGridView
            dataGridView1.Controls.Add(headerCheckBox);


            headerCheckBox.AutoSize = true;
            headerCheckBox.Location = new Point(85, 10);
            var headerCell = new DataGridViewColumnHeaderCell();
            headerCell.Value = headerCheckBox;

            checkboxColumn.Name = "Select";
            checkboxColumn.HeaderCell = headerCell;
            checkboxColumn.Width = 30;
            checkboxColumn.Resizable = DataGridViewTriState.False;
            dataGridView1.Columns.Add(checkboxColumn);


            var genColum = (string name) =>
            {

                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                //column.Width 
                column.ReadOnly = true;
                column.HeaderText = name;
                column.Name = name;
                column.DataPropertyName = name;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                return column;
            };

            typeof(Item)
                .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .ToList()
                .ForEach(item =>
                {
                    dataGridView1.Columns.Add(genColum(item.Name));
                });

            dataGridView1.Columns.Add(genColum(""));

            dataGridView1.DataSource = bindingSource1;


            //DataGridViewHeaderCell header = dataGridView1.Columns[0].HeaderCell;
            //checkbox.Location = new Point(
            //    header.ContentBounds.Left + (header.ContentBounds.Right - header.ContentBounds.Left + checkbox.Size.Width) / 2,
            //    header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + checkbox.Size.Height) / 2
            //);

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authService.CancelRequest();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Rectangle rect = e.CellBounds;
                rect.X += 9;
                rect.Y += 5;
                headerCheckBox.Location = new Point(rect.X, rect.Y);
                headerCheckBox.Size = new Size(15, 15);
                e.Handled = true;
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            // Seleziona o deseleziona tutte le righe
            bool isChecked = headerCheckBox.Checked;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.BeginEdit(false);
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell) row.Cells["Select"];
                
                checkBox.Value = isChecked;
                checkBox.EditingCellValueChanged = true;

                dataGridView1.EndEdit();
            }
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var a = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Select(x =>
                {
                    var t = ((bool?) x.Cells["Select"].Value).GetValueOrDefault(false) == true;
                    return t;
                }).ToList();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica che il click sia avvenuto in una cella checkbox
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex >= 0)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CausesValidationChanged(object sender, EventArgs e)
        {
            var t = "";
        }
    }
}
