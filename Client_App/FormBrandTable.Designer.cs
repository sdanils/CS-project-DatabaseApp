using System.Drawing;
using System.Windows.Forms;

namespace Lab_Three_WinAdd
{
    partial class FormBrandTable
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewBrands = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PowerEngine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCars = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Multi_wheels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume_airbags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.labelSeriolizeInfo = new System.Windows.Forms.Label();
            this.labelTitleMenu = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.labelSelection = new System.Windows.Forms.Label();
            this.textBoxSelection = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCars)).BeginInit();
            this.groupBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBrands
            // 
            this.dataGridViewBrands.AllowUserToAddRows = false;
            this.dataGridViewBrands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBrands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Brand,
            this.Model,
            this.PowerEngine,
            this.MaxSpeed});
            this.dataGridViewBrands.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBrands.Name = "dataGridViewBrands";
            this.dataGridViewBrands.RowHeadersWidth = 51;
            this.dataGridViewBrands.RowTemplate.Height = 24;
            this.dataGridViewBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBrands.Size = new System.Drawing.Size(1143, 242);
            this.dataGridViewBrands.TabIndex = 0;
            this.dataGridViewBrands.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBrands_CellValueChanged);
            this.dataGridViewBrands.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewBrands_DataError);
            this.dataGridViewBrands.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewBrands_EditingControlShowing);
            this.dataGridViewBrands.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewBrands_RowsAdded);
            this.dataGridViewBrands.SelectionChanged += new System.EventHandler(this.dataGridViewBrands_SelectionChanged);
            // 
            // Type
            // 
            this.Type.DropDownWidth = 2;
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "Car",
            "Truck"});
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.Sorted = true;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "Brand";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            // 
            // Model
            // 
            this.Model.DataPropertyName = "NameModel";
            this.Model.HeaderText = "Model";
            this.Model.MinimumWidth = 6;
            this.Model.Name = "Model";
            // 
            // PowerEngine
            // 
            this.PowerEngine.DataPropertyName = "PowerEngine";
            this.PowerEngine.HeaderText = "PowerEngine";
            this.PowerEngine.MinimumWidth = 6;
            this.PowerEngine.Name = "PowerEngine";
            // 
            // MaxSpeed
            // 
            this.MaxSpeed.DataPropertyName = "MaxSpeed";
            this.MaxSpeed.HeaderText = "MaxSpeed";
            this.MaxSpeed.MinimumWidth = 6;
            this.MaxSpeed.Name = "MaxSpeed";
            // 
            // dataGridViewCars
            // 
            this.dataGridViewCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCars.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridViewCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Multi_wheels,
            this.Volume_airbags});
            this.dataGridViewCars.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dataGridViewCars.Location = new System.Drawing.Point(0, 232);
            this.dataGridViewCars.Name = "dataGridViewCars";
            this.dataGridViewCars.ReadOnly = true;
            this.dataGridViewCars.RowHeadersWidth = 51;
            this.dataGridViewCars.RowTemplate.Height = 24;
            this.dataGridViewCars.Size = new System.Drawing.Size(1143, 343);
            this.dataGridViewCars.TabIndex = 1;
            this.dataGridViewCars.Visible = false;
            this.dataGridViewCars.SelectionChanged += new System.EventHandler(this.dataGridViewCars_SelectionChanged);
            // 
            // Number
            // 
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // Multi_wheels
            // 
            this.Multi_wheels.HeaderText = "Header2";
            this.Multi_wheels.MinimumWidth = 6;
            this.Multi_wheels.Name = "Multi_wheels";
            this.Multi_wheels.ReadOnly = true;
            // 
            // Volume_airbags
            // 
            this.Volume_airbags.HeaderText = "Header3";
            this.Volume_airbags.MinimumWidth = 6;
            this.Volume_airbags.Name = "Volume_airbags";
            this.Volume_airbags.ReadOnly = true;
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMenu.Controls.Add(this.labelSeriolizeInfo);
            this.groupBoxMenu.Controls.Add(this.labelTitleMenu);
            this.groupBoxMenu.Controls.Add(this.buttonExit);
            this.groupBoxMenu.Controls.Add(this.buttonSave);
            this.groupBoxMenu.Controls.Add(this.buttonLoad);
            this.groupBoxMenu.Controls.Add(this.buttonFile);
            this.groupBoxMenu.Controls.Add(this.labelSelection);
            this.groupBoxMenu.Controls.Add(this.textBoxSelection);
            this.groupBoxMenu.Location = new System.Drawing.Point(991, 0);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(200, 591);
            this.groupBoxMenu.TabIndex = 2;
            this.groupBoxMenu.TabStop = false;
            // 
            // labelSeriolizeInfo
            // 
            this.labelSeriolizeInfo.AutoSize = true;
            this.labelSeriolizeInfo.Location = new System.Drawing.Point(76, 284);
            this.labelSeriolizeInfo.Name = "labelSeriolizeInfo";
            this.labelSeriolizeInfo.Size = new System.Drawing.Size(44, 16);
            this.labelSeriolizeInfo.TabIndex = 8;
            this.labelSeriolizeInfo.Text = "label1";
            // 
            // labelTitleMenu
            // 
            this.labelTitleMenu.AutoSize = true;
            this.labelTitleMenu.Location = new System.Drawing.Point(6, 9);
            this.labelTitleMenu.Name = "labelTitleMenu";
            this.labelTitleMenu.Size = new System.Drawing.Size(44, 16);
            this.labelTitleMenu.TabIndex = 7;
            this.labelTitleMenu.Text = "label1";
            this.labelTitleMenu.Visible = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(42, 202);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(116, 40);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Visible = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(42, 138);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(116, 40);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(42, 76);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(116, 40);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Visible = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(42, 21);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(116, 40);
            this.buttonFile.TabIndex = 3;
            this.buttonFile.Text = "File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // labelSelection
            // 
            this.labelSelection.AutoSize = true;
            this.labelSelection.Location = new System.Drawing.Point(45, 337);
            this.labelSelection.Name = "labelSelection";
            this.labelSelection.Size = new System.Drawing.Size(137, 16);
            this.labelSelection.TabIndex = 3;
            this.labelSelection.Text = "Selection text number.";
            // 
            // textBoxSelection
            // 
            this.textBoxSelection.Location = new System.Drawing.Point(42, 355);
            this.textBoxSelection.Name = "textBoxSelection";
            this.textBoxSelection.Size = new System.Drawing.Size(100, 22);
            this.textBoxSelection.TabIndex = 2;
            this.textBoxSelection.TextChanged += TextBoxSelection_TextChanged;
            // 
            // FormBrandTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 587);
            this.Controls.Add(this.dataGridViewCars);
            this.Controls.Add(this.dataGridViewBrands);
            this.KeyPreview = true;
            this.Name = "FormBrandTable";
            this.Text = "Brands";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBrandTable_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCars)).EndInit();
            this.groupBoxMenu.ResumeLayout(false);
            this.groupBoxMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBrands;
        private DataGridViewComboBoxColumn Type;
        private DataGridViewTextBoxColumn Brand;
        private DataGridViewTextBoxColumn Model;
        private DataGridViewTextBoxColumn PowerEngine;
        private DataGridViewTextBoxColumn MaxSpeed;
        private DataGridView dataGridViewCars;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Multi_wheels;
        private DataGridViewTextBoxColumn Volume_airbags;
        private GroupBox groupBoxMenu;
        private Button buttonFile;
        private Button buttonExit;
        private Button buttonSave;
        private Button buttonLoad;
        private Label labelTitleMenu;
        private Label labelSeriolizeInfo;
        private TextBox textBoxSelection;
        private Label labelSelection;
    }
}

