namespace WikiDataStructure
{
    partial class FormWiki
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
            System.Windows.Forms.StatusStrip stsMessage;
            this.stsLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ListViewData = new System.Windows.Forms.ListView();
            this.Nane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stucture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Definition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.txtDefinition = new System.Windows.Forms.TextBox();
            this.btnBinarySearch = new System.Windows.Forms.Button();
            this.btnBubbleSort = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpStructureOptions = new System.Windows.Forms.GroupBox();
            this.rdoNonLinear = new System.Windows.Forms.RadioButton();
            this.rdoLinear = new System.Windows.Forms.RadioButton();
            stsMessage = new System.Windows.Forms.StatusStrip();
            stsMessage.SuspendLayout();
            this.grpStructureOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsMessage
            // 
            stsMessage.ImageScalingSize = new System.Drawing.Size(20, 20);
            stsMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsLbl,
            this.toolStripStatusLabel1});
            stsMessage.Location = new System.Drawing.Point(0, 397);
            stsMessage.Name = "stsMessage";
            stsMessage.Size = new System.Drawing.Size(811, 26);
            stsMessage.TabIndex = 8;
            stsMessage.Text = "statusStrip1";
            // 
            // stsLbl
            // 
            this.stsLbl.Name = "stsLbl";
            this.stsLbl.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 20);
            this.toolStripStatusLabel1.Text = "feedback";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(23, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 37);
            this.txtSearch.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(125, 99);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 37);
            this.txtName.TabIndex = 1;
            this.txtName.DoubleClick += new System.EventHandler(this.txtName_DoubleClick_1);
            // 
            // ListViewData
            // 
            this.ListViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nane,
            this.Category,
            this.Stucture,
            this.Definition});
            this.ListViewData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewData.HideSelection = false;
            this.ListViewData.Location = new System.Drawing.Point(494, 43);
            this.ListViewData.Name = "ListViewData";
            this.ListViewData.Size = new System.Drawing.Size(305, 355);
            this.ListViewData.TabIndex = 2;
            this.ListViewData.UseCompatibleStateImageBehavior = false;
            this.ListViewData.View = System.Windows.Forms.View.Details;
            this.ListViewData.DoubleClick += new System.EventHandler(this.ListViewData_DoubleClick);
            this.ListViewData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewData_MouseClick_1);
            // 
            // Nane
            // 
            this.Nane.Text = "Name";
            // 
            // Category
            // 
            this.Category.Text = "Category";
            // 
            // Stucture
            // 
            this.Stucture.Text = "Stucture";
            // 
            // Definition
            // 
            this.Definition.Text = "Definition";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(18, 95);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 31);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(18, 140);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(125, 31);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category";
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefinition.Location = new System.Drawing.Point(18, 256);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(128, 31);
            this.lblDefinition.TabIndex = 3;
            this.lblDefinition.Text = "Definition";
            // 
            // txtDefinition
            // 
            this.txtDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefinition.Location = new System.Drawing.Point(21, 285);
            this.txtDefinition.Multiline = true;
            this.txtDefinition.Name = "txtDefinition";
            this.txtDefinition.Size = new System.Drawing.Size(279, 115);
            this.txtDefinition.TabIndex = 1;
            // 
            // btnBinarySearch
            // 
            this.btnBinarySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinarySearch.Location = new System.Drawing.Point(360, 45);
            this.btnBinarySearch.Name = "btnBinarySearch";
            this.btnBinarySearch.Size = new System.Drawing.Size(110, 38);
            this.btnBinarySearch.TabIndex = 6;
            this.btnBinarySearch.Text = "Search";
            this.btnBinarySearch.UseVisualStyleBackColor = true;
            this.btnBinarySearch.Click += new System.EventHandler(this.btnBinarySearch_Click);
            // 
            // btnBubbleSort
            // 
            this.btnBubbleSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBubbleSort.Location = new System.Drawing.Point(230, 45);
            this.btnBubbleSort.Name = "btnBubbleSort";
            this.btnBubbleSort.Size = new System.Drawing.Size(110, 38);
            this.btnBubbleSort.TabIndex = 6;
            this.btnBubbleSort.Text = "Sort";
            this.btnBubbleSort.UseVisualStyleBackColor = true;
            this.btnBubbleSort.Click += new System.EventHandler(this.btnBubbleSort_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(328, 141);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 38);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(328, 206);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 38);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(328, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 38);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Array",
            "List",
            "Tree",
            "Graphs",
            "Abstract",
            "Hash"});
            this.cboCategory.Location = new System.Drawing.Point(125, 140);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(175, 38);
            this.cboCategory.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grpStructureOptions
            // 
            this.grpStructureOptions.Controls.Add(this.rdoNonLinear);
            this.grpStructureOptions.Controls.Add(this.rdoLinear);
            this.grpStructureOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStructureOptions.Location = new System.Drawing.Point(14, 184);
            this.grpStructureOptions.Name = "grpStructureOptions";
            this.grpStructureOptions.Size = new System.Drawing.Size(282, 78);
            this.grpStructureOptions.TabIndex = 11;
            this.grpStructureOptions.TabStop = false;
            this.grpStructureOptions.Text = "Structure";
            // 
            // rdoNonLinear
            // 
            this.rdoNonLinear.AutoSize = true;
            this.rdoNonLinear.Location = new System.Drawing.Point(127, 28);
            this.rdoNonLinear.Name = "rdoNonLinear";
            this.rdoNonLinear.Size = new System.Drawing.Size(154, 33);
            this.rdoNonLinear.TabIndex = 1;
            this.rdoNonLinear.TabStop = true;
            this.rdoNonLinear.Text = "Non-Linear";
            this.rdoNonLinear.UseVisualStyleBackColor = true;
            this.rdoNonLinear.CheckedChanged += new System.EventHandler(this.rdoNonLinear_CheckedChanged);
            // 
            // rdoLinear
            // 
            this.rdoLinear.AutoSize = true;
            this.rdoLinear.Location = new System.Drawing.Point(17, 29);
            this.rdoLinear.Name = "rdoLinear";
            this.rdoLinear.Size = new System.Drawing.Size(101, 33);
            this.rdoLinear.TabIndex = 0;
            this.rdoLinear.TabStop = true;
            this.rdoLinear.Text = "Linear";
            this.rdoLinear.UseVisualStyleBackColor = true;
            this.rdoLinear.CheckedChanged += new System.EventHandler(this.rdoLinear_CheckedChanged);
            // 
            // FormWiki
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(811, 423);
            this.Controls.Add(this.grpStructureOptions);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(stsMessage);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnBubbleSort);
            this.Controls.Add(this.btnBinarySearch);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ListViewData);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSearch);
            this.Name = "FormWiki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormWiki";
            stsMessage.ResumeLayout(false);
            stsMessage.PerformLayout();
            this.grpStructureOptions.ResumeLayout(false);
            this.grpStructureOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListView ListViewData;
        private System.Windows.Forms.ColumnHeader Nane;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Stucture;
        private System.Windows.Forms.ColumnHeader Definition;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDefinition;
        private System.Windows.Forms.TextBox txtDefinition;
        private System.Windows.Forms.Button btnBinarySearch;
        private System.Windows.Forms.Button btnBubbleSort;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolStripStatusLabel stsLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox grpStructureOptions;
        private System.Windows.Forms.RadioButton rdoNonLinear;
        private System.Windows.Forms.RadioButton rdoLinear;
    }
}

