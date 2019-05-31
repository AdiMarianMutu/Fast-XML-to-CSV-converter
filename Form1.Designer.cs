namespace FastXMLtoCSV {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolVisualFeedback_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xmlNodesFilter_listview = new System.Windows.Forms.ListView();
            this.node = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.csvNodeAlias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.xmlEditAlias_btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.xmlNodeAlias_txtbox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.xmlEditName_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.xmlNodeName_txtbox = new System.Windows.Forms.TextBox();
            this.xmlAddNode_btn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.xmlScanStructure_btn = new System.Windows.Forms.Button();
            this.xmlDeleteNode_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.csvOutputPath_btn = new System.Windows.Forms.Button();
            this.csvOutputPath_txtbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.xmlInputPath_btn = new System.Windows.Forms.Button();
            this.xmlInputPath_txtbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.csvBadOutputDelete_chbox = new System.Windows.Forms.CheckBox();
            this.xmlConversionAbort_btn = new System.Windows.Forms.Button();
            this.monitoringIntervalSec_numeric = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.monitoringIntervalMin_numeric = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.monitoringIntervalHrs_numeric = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolAction_btn = new System.Windows.Forms.Button();
            this.csvFileSuffix_txtbox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.csvFilePrefix_txtbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.csvFileName_txtbox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tool_progressbar = new System.Windows.Forms.ProgressBar();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.xmlNodesScanningTiming_lbl = new System.Windows.Forms.Label();
            this.xmlToCsvConversionTiming_lbl = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.toolProgressPercent_lbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringIntervalSec_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringIntervalMin_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringIntervalHrs_numeric)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 453);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Developed by Mutu Adi-Marian";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(217, 453);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "v1.0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Honeydew;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1059, 435);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(265, 450);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 25);
            this.label5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(903, 450);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(3, 25);
            this.label6.TabIndex = 5;
            // 
            // toolVisualFeedback_lbl
            // 
            this.toolVisualFeedback_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolVisualFeedback_lbl.BackColor = System.Drawing.Color.PowderBlue;
            this.toolVisualFeedback_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolVisualFeedback_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolVisualFeedback_lbl.Location = new System.Drawing.Point(445, 442);
            this.toolVisualFeedback_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toolVisualFeedback_lbl.Name = "toolVisualFeedback_lbl";
            this.toolVisualFeedback_lbl.Size = new System.Drawing.Size(449, 39);
            this.toolVisualFeedback_lbl.TabIndex = 6;
            this.toolVisualFeedback_lbl.Text = "Tool not running";
            this.toolVisualFeedback_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox1.Controls.Add(this.xmlNodesFilter_listview);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.xmlDeleteNode_btn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(655, 428);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML Nodes Filter";
            // 
            // xmlNodesFilter_listview
            // 
            this.xmlNodesFilter_listview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlNodesFilter_listview.CheckBoxes = true;
            this.xmlNodesFilter_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.node,
            this.csvNodeAlias});
            this.xmlNodesFilter_listview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlNodesFilter_listview.FullRowSelect = true;
            this.xmlNodesFilter_listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.xmlNodesFilter_listview.HideSelection = false;
            this.xmlNodesFilter_listview.Location = new System.Drawing.Point(5, 17);
            this.xmlNodesFilter_listview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlNodesFilter_listview.MultiSelect = false;
            this.xmlNodesFilter_listview.Name = "xmlNodesFilter_listview";
            this.xmlNodesFilter_listview.Size = new System.Drawing.Size(409, 403);
            this.xmlNodesFilter_listview.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.xmlNodesFilter_listview.TabIndex = 9;
            this.xmlNodesFilter_listview.UseCompatibleStateImageBehavior = false;
            this.xmlNodesFilter_listview.View = System.Windows.Forms.View.Details;
            this.xmlNodesFilter_listview.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.xmlNodesFilter_listview_ItemChecked);
            this.xmlNodesFilter_listview.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.xmlNodesFilter_listview_ItemSelectionChanged);
            // 
            // node
            // 
            this.node.Text = "Nodes";
            this.node.Width = 138;
            // 
            // csvNodeAlias
            // 
            this.csvNodeAlias.Text = "Aliases (CSV)";
            this.csvNodeAlias.Width = 145;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.xmlEditAlias_btn);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.xmlNodeAlias_txtbox);
            this.groupBox7.Location = new System.Drawing.Point(421, 271);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(227, 103);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Node Alias (CSV)";
            // 
            // xmlEditAlias_btn
            // 
            this.xmlEditAlias_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlEditAlias_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlEditAlias_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlEditAlias_btn.Location = new System.Drawing.Point(8, 70);
            this.xmlEditAlias_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlEditAlias_btn.Name = "xmlEditAlias_btn";
            this.xmlEditAlias_btn.Size = new System.Drawing.Size(209, 25);
            this.xmlEditAlias_btn.TabIndex = 5;
            this.xmlEditAlias_btn.Text = "Edit Alias";
            this.xmlEditAlias_btn.UseVisualStyleBackColor = true;
            this.xmlEditAlias_btn.Click += new System.EventHandler(this.xmlEditAlias_btn_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.LightCyan;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "Node Alias";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xmlNodeAlias_txtbox
            // 
            this.xmlNodeAlias_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlNodeAlias_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlNodeAlias_txtbox.ForeColor = System.Drawing.Color.Gray;
            this.xmlNodeAlias_txtbox.Location = new System.Drawing.Point(9, 38);
            this.xmlNodeAlias_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlNodeAlias_txtbox.Name = "xmlNodeAlias_txtbox";
            this.xmlNodeAlias_txtbox.Size = new System.Drawing.Size(207, 23);
            this.xmlNodeAlias_txtbox.TabIndex = 5;
            this.xmlNodeAlias_txtbox.Text = "Same as the \'Node Name\'";
            this.xmlNodeAlias_txtbox.Enter += new System.EventHandler(this.xmlNodeAlias_txtbox_Enter);
            this.xmlNodeAlias_txtbox.Leave += new System.EventHandler(this.xmlNodeAlias_txtbox_Leave);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Location = new System.Drawing.Point(421, 15);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(227, 249);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nodes Scanning";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.xmlEditName_btn);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.xmlNodeName_txtbox);
            this.groupBox4.Controls.Add(this.xmlAddNode_btn);
            this.groupBox4.Location = new System.Drawing.Point(8, 16);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(209, 148);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Manually";
            // 
            // xmlEditName_btn
            // 
            this.xmlEditName_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlEditName_btn.Enabled = false;
            this.xmlEditName_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlEditName_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlEditName_btn.Location = new System.Drawing.Point(7, 114);
            this.xmlEditName_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlEditName_btn.Name = "xmlEditName_btn";
            this.xmlEditName_btn.Size = new System.Drawing.Size(193, 25);
            this.xmlEditName_btn.TabIndex = 5;
            this.xmlEditName_btn.Text = "Edit Name";
            this.xmlEditName_btn.UseVisualStyleBackColor = true;
            this.xmlEditName_btn.Click += new System.EventHandler(this.xmlEditName_btn_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.LightCyan;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Node Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xmlNodeName_txtbox
            // 
            this.xmlNodeName_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlNodeName_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlNodeName_txtbox.Location = new System.Drawing.Point(8, 38);
            this.xmlNodeName_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlNodeName_txtbox.Name = "xmlNodeName_txtbox";
            this.xmlNodeName_txtbox.Size = new System.Drawing.Size(192, 23);
            this.xmlNodeName_txtbox.TabIndex = 2;
            this.xmlNodeName_txtbox.TextChanged += new System.EventHandler(this.xmlNodeName_txtbox_TextChanged);
            // 
            // xmlAddNode_btn
            // 
            this.xmlAddNode_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlAddNode_btn.Enabled = false;
            this.xmlAddNode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlAddNode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlAddNode_btn.Location = new System.Drawing.Point(8, 71);
            this.xmlAddNode_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlAddNode_btn.Name = "xmlAddNode_btn";
            this.xmlAddNode_btn.Size = new System.Drawing.Size(193, 25);
            this.xmlAddNode_btn.TabIndex = 1;
            this.xmlAddNode_btn.Text = "Add";
            this.xmlAddNode_btn.UseVisualStyleBackColor = true;
            this.xmlAddNode_btn.Click += new System.EventHandler(this.xmlAddNode_btn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.xmlScanStructure_btn);
            this.groupBox5.Location = new System.Drawing.Point(8, 171);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(209, 70);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Automatically";
            // 
            // xmlScanStructure_btn
            // 
            this.xmlScanStructure_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlScanStructure_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlScanStructure_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlScanStructure_btn.Location = new System.Drawing.Point(8, 27);
            this.xmlScanStructure_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlScanStructure_btn.Name = "xmlScanStructure_btn";
            this.xmlScanStructure_btn.Size = new System.Drawing.Size(193, 25);
            this.xmlScanStructure_btn.TabIndex = 2;
            this.xmlScanStructure_btn.Text = "Select XML";
            this.xmlScanStructure_btn.UseVisualStyleBackColor = true;
            this.xmlScanStructure_btn.Click += new System.EventHandler(this.xmlScanStructure_btn_Click);
            // 
            // xmlDeleteNode_btn
            // 
            this.xmlDeleteNode_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlDeleteNode_btn.Enabled = false;
            this.xmlDeleteNode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlDeleteNode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlDeleteNode_btn.Location = new System.Drawing.Point(421, 388);
            this.xmlDeleteNode_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlDeleteNode_btn.Name = "xmlDeleteNode_btn";
            this.xmlDeleteNode_btn.Size = new System.Drawing.Size(227, 25);
            this.xmlDeleteNode_btn.TabIndex = 3;
            this.xmlDeleteNode_btn.Text = "Delete Selected Node";
            this.xmlDeleteNode_btn.UseVisualStyleBackColor = true;
            this.xmlDeleteNode_btn.Click += new System.EventHandler(this.xmlDeleteNode_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox2.Controls.Add(this.csvOutputPath_btn);
            this.groupBox2.Controls.Add(this.csvOutputPath_txtbox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.xmlInputPath_btn);
            this.groupBox2.Controls.Add(this.xmlInputPath_txtbox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(671, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(387, 85);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XML/CSV Directory";
            // 
            // csvOutputPath_btn
            // 
            this.csvOutputPath_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.csvOutputPath_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvOutputPath_btn.Location = new System.Drawing.Point(347, 50);
            this.csvOutputPath_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvOutputPath_btn.Name = "csvOutputPath_btn";
            this.csvOutputPath_btn.Size = new System.Drawing.Size(32, 28);
            this.csvOutputPath_btn.TabIndex = 5;
            this.csvOutputPath_btn.Text = "...";
            this.csvOutputPath_btn.UseVisualStyleBackColor = true;
            this.csvOutputPath_btn.Click += new System.EventHandler(this.csvOutputPath_btn_Click);
            // 
            // csvOutputPath_txtbox
            // 
            this.csvOutputPath_txtbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.csvOutputPath_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvOutputPath_txtbox.Location = new System.Drawing.Point(87, 53);
            this.csvOutputPath_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvOutputPath_txtbox.Name = "csvOutputPath_txtbox";
            this.csvOutputPath_txtbox.ReadOnly = true;
            this.csvOutputPath_txtbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.csvOutputPath_txtbox.Size = new System.Drawing.Size(255, 23);
            this.csvOutputPath_txtbox.TabIndex = 4;
            this.csvOutputPath_txtbox.TextChanged += new System.EventHandler(this.csvOutputPath_txtbox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "CSV Path:";
            // 
            // xmlInputPath_btn
            // 
            this.xmlInputPath_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlInputPath_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlInputPath_btn.Location = new System.Drawing.Point(347, 16);
            this.xmlInputPath_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlInputPath_btn.Name = "xmlInputPath_btn";
            this.xmlInputPath_btn.Size = new System.Drawing.Size(32, 28);
            this.xmlInputPath_btn.TabIndex = 2;
            this.xmlInputPath_btn.Text = "...";
            this.xmlInputPath_btn.UseVisualStyleBackColor = true;
            this.xmlInputPath_btn.Click += new System.EventHandler(this.xmlInputPath_btn_Click);
            // 
            // xmlInputPath_txtbox
            // 
            this.xmlInputPath_txtbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.xmlInputPath_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlInputPath_txtbox.Location = new System.Drawing.Point(87, 18);
            this.xmlInputPath_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlInputPath_txtbox.Name = "xmlInputPath_txtbox";
            this.xmlInputPath_txtbox.ReadOnly = true;
            this.xmlInputPath_txtbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xmlInputPath_txtbox.Size = new System.Drawing.Size(255, 23);
            this.xmlInputPath_txtbox.TabIndex = 1;
            this.xmlInputPath_txtbox.TextChanged += new System.EventHandler(this.xmlInputPath_txtbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "XML Path:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox3.Controls.Add(this.csvBadOutputDelete_chbox);
            this.groupBox3.Controls.Add(this.xmlConversionAbort_btn);
            this.groupBox3.Controls.Add(this.monitoringIntervalSec_numeric);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.monitoringIntervalMin_numeric);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.monitoringIntervalHrs_numeric);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.toolAction_btn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(671, 318);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(387, 118);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monitoring";
            // 
            // csvBadOutputDelete_chbox
            // 
            this.csvBadOutputDelete_chbox.AutoSize = true;
            this.csvBadOutputDelete_chbox.Checked = true;
            this.csvBadOutputDelete_chbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.csvBadOutputDelete_chbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvBadOutputDelete_chbox.Location = new System.Drawing.Point(243, 81);
            this.csvBadOutputDelete_chbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvBadOutputDelete_chbox.Name = "csvBadOutputDelete_chbox";
            this.csvBadOutputDelete_chbox.Size = new System.Drawing.Size(131, 21);
            this.csvBadOutputDelete_chbox.TabIndex = 19;
            this.csvBadOutputDelete_chbox.Text = "Delete Bad CSV";
            this.csvBadOutputDelete_chbox.UseVisualStyleBackColor = true;
            this.csvBadOutputDelete_chbox.CheckedChanged += new System.EventHandler(this.csvBadOutputDelete_chbox_CheckedChanged);
            // 
            // xmlConversionAbort_btn
            // 
            this.xmlConversionAbort_btn.Enabled = false;
            this.xmlConversionAbort_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xmlConversionAbort_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlConversionAbort_btn.Location = new System.Drawing.Point(91, 78);
            this.xmlConversionAbort_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xmlConversionAbort_btn.Name = "xmlConversionAbort_btn";
            this.xmlConversionAbort_btn.Size = new System.Drawing.Size(144, 25);
            this.xmlConversionAbort_btn.TabIndex = 18;
            this.xmlConversionAbort_btn.Text = "Abort Conversion";
            this.xmlConversionAbort_btn.UseVisualStyleBackColor = true;
            this.xmlConversionAbort_btn.Click += new System.EventHandler(this.xmlConversionAbort_btn_Click);
            // 
            // monitoringIntervalSec_numeric
            // 
            this.monitoringIntervalSec_numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitoringIntervalSec_numeric.Location = new System.Drawing.Point(287, 36);
            this.monitoringIntervalSec_numeric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monitoringIntervalSec_numeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.monitoringIntervalSec_numeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.monitoringIntervalSec_numeric.Name = "monitoringIntervalSec_numeric";
            this.monitoringIntervalSec_numeric.Size = new System.Drawing.Size(56, 23);
            this.monitoringIntervalSec_numeric.TabIndex = 17;
            this.monitoringIntervalSec_numeric.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.monitoringIntervalSec_numeric.ValueChanged += new System.EventHandler(this.monitoringIntervalSec_numeric_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(280, 17);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 17);
            this.label18.TabIndex = 16;
            this.label18.Text = "Seconds";
            // 
            // monitoringIntervalMin_numeric
            // 
            this.monitoringIntervalMin_numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitoringIntervalMin_numeric.Location = new System.Drawing.Point(191, 36);
            this.monitoringIntervalMin_numeric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monitoringIntervalMin_numeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.monitoringIntervalMin_numeric.Name = "monitoringIntervalMin_numeric";
            this.monitoringIntervalMin_numeric.Size = new System.Drawing.Size(56, 23);
            this.monitoringIntervalMin_numeric.TabIndex = 15;
            this.monitoringIntervalMin_numeric.ValueChanged += new System.EventHandler(this.monitoringIntervalMin_numeric_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(189, 17);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 17);
            this.label17.TabIndex = 14;
            this.label17.Text = "Minutes";
            // 
            // monitoringIntervalHrs_numeric
            // 
            this.monitoringIntervalHrs_numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitoringIntervalHrs_numeric.Location = new System.Drawing.Point(91, 36);
            this.monitoringIntervalHrs_numeric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monitoringIntervalHrs_numeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.monitoringIntervalHrs_numeric.Name = "monitoringIntervalHrs_numeric";
            this.monitoringIntervalHrs_numeric.Size = new System.Drawing.Size(56, 23);
            this.monitoringIntervalHrs_numeric.TabIndex = 13;
            this.monitoringIntervalHrs_numeric.ValueChanged += new System.EventHandler(this.monitoringIntervalHrs_numeric_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(93, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Hours";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Interval:";
            // 
            // toolAction_btn
            // 
            this.toolAction_btn.Enabled = false;
            this.toolAction_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toolAction_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAction_btn.Location = new System.Drawing.Point(8, 78);
            this.toolAction_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolAction_btn.Name = "toolAction_btn";
            this.toolAction_btn.Size = new System.Drawing.Size(75, 25);
            this.toolAction_btn.TabIndex = 6;
            this.toolAction_btn.Text = "START";
            this.toolAction_btn.UseVisualStyleBackColor = true;
            this.toolAction_btn.Click += new System.EventHandler(this.toolAction_btn_Click);
            // 
            // csvFileSuffix_txtbox
            // 
            this.csvFileSuffix_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvFileSuffix_txtbox.ForeColor = System.Drawing.Color.Gray;
            this.csvFileSuffix_txtbox.Location = new System.Drawing.Point(88, 79);
            this.csvFileSuffix_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvFileSuffix_txtbox.Name = "csvFileSuffix_txtbox";
            this.csvFileSuffix_txtbox.Size = new System.Drawing.Size(291, 23);
            this.csvFileSuffix_txtbox.TabIndex = 18;
            this.csvFileSuffix_txtbox.Text = "Suffix";
            this.csvFileSuffix_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.csvFileSuffix_txtbox.TextChanged += new System.EventHandler(this.csvFileSuffix_txtbox_TextChanged);
            this.csvFileSuffix_txtbox.Enter += new System.EventHandler(this.csvFileSuffix_txtbox_Enter);
            this.csvFileSuffix_txtbox.Leave += new System.EventHandler(this.csvFileSuffix_txtbox_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 84);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 17);
            this.label16.TabIndex = 17;
            this.label16.Text = "Suffix:";
            // 
            // csvFilePrefix_txtbox
            // 
            this.csvFilePrefix_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvFilePrefix_txtbox.ForeColor = System.Drawing.Color.Gray;
            this.csvFilePrefix_txtbox.Location = new System.Drawing.Point(88, 49);
            this.csvFilePrefix_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvFilePrefix_txtbox.Name = "csvFilePrefix_txtbox";
            this.csvFilePrefix_txtbox.Size = new System.Drawing.Size(291, 23);
            this.csvFilePrefix_txtbox.TabIndex = 16;
            this.csvFilePrefix_txtbox.Text = "Prefix";
            this.csvFilePrefix_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.csvFilePrefix_txtbox.TextChanged += new System.EventHandler(this.csvFilePrefix_txtbox_TextChanged);
            this.csvFilePrefix_txtbox.Enter += new System.EventHandler(this.csvFilePrefix_txtbox_Enter);
            this.csvFilePrefix_txtbox.Leave += new System.EventHandler(this.csvFilePrefix_txtbox_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 53);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 17);
            this.label15.TabIndex = 15;
            this.label15.Text = "Prefix:";
            // 
            // csvFileName_txtbox
            // 
            this.csvFileName_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvFileName_txtbox.ForeColor = System.Drawing.Color.Gray;
            this.csvFileName_txtbox.Location = new System.Drawing.Point(88, 20);
            this.csvFileName_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.csvFileName_txtbox.Name = "csvFileName_txtbox";
            this.csvFileName_txtbox.Size = new System.Drawing.Size(291, 23);
            this.csvFileName_txtbox.TabIndex = 14;
            this.csvFileName_txtbox.Text = "Filename";
            this.csvFileName_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.csvFileName_txtbox.TextChanged += new System.EventHandler(this.csvFileName_txtbox_TextChanged);
            this.csvFileName_txtbox.Enter += new System.EventHandler(this.csvFileName_txtbox_Enter);
            this.csvFileName_txtbox.Leave += new System.EventHandler(this.csvFileName_txtbox_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 20);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 13;
            this.label14.Text = "File Name:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(435, 450);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(3, 25);
            this.label13.TabIndex = 10;
            // 
            // tool_progressbar
            // 
            this.tool_progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tool_progressbar.Location = new System.Drawing.Point(276, 449);
            this.tool_progressbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tool_progressbar.Name = "tool_progressbar";
            this.tool_progressbar.Size = new System.Drawing.Size(151, 12);
            this.tool_progressbar.TabIndex = 11;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox8.Controls.Add(this.csvFileSuffix_txtbox);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.csvFileName_txtbox);
            this.groupBox8.Controls.Add(this.csvFilePrefix_txtbox);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(671, 100);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Size = new System.Drawing.Size(387, 113);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "CSV Output File";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select a XML file";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox9.Controls.Add(this.xmlNodesScanningTiming_lbl);
            this.groupBox9.Controls.Add(this.xmlToCsvConversionTiming_lbl);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(671, 220);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox9.Size = new System.Drawing.Size(387, 90);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Timing Benchmark";
            // 
            // xmlNodesScanningTiming_lbl
            // 
            this.xmlNodesScanningTiming_lbl.AutoSize = true;
            this.xmlNodesScanningTiming_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlNodesScanningTiming_lbl.Location = new System.Drawing.Point(212, 27);
            this.xmlNodesScanningTiming_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xmlNodesScanningTiming_lbl.Name = "xmlNodesScanningTiming_lbl";
            this.xmlNodesScanningTiming_lbl.Size = new System.Drawing.Size(16, 17);
            this.xmlNodesScanningTiming_lbl.TabIndex = 3;
            this.xmlNodesScanningTiming_lbl.Text = "//";
            // 
            // xmlToCsvConversionTiming_lbl
            // 
            this.xmlToCsvConversionTiming_lbl.AutoSize = true;
            this.xmlToCsvConversionTiming_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlToCsvConversionTiming_lbl.Location = new System.Drawing.Point(212, 58);
            this.xmlToCsvConversionTiming_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xmlToCsvConversionTiming_lbl.Name = "xmlToCsvConversionTiming_lbl";
            this.xmlToCsvConversionTiming_lbl.Size = new System.Drawing.Size(16, 17);
            this.xmlToCsvConversionTiming_lbl.TabIndex = 2;
            this.xmlToCsvConversionTiming_lbl.Text = "//";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 58);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(193, 17);
            this.label20.TabIndex = 1;
            this.label20.Text = "Last XML to CSV Conversion:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(11, 27);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(179, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "Last XML Nodes Scanning:";
            // 
            // toolProgressPercent_lbl
            // 
            this.toolProgressPercent_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolProgressPercent_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolProgressPercent_lbl.Location = new System.Drawing.Point(276, 465);
            this.toolProgressPercent_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toolProgressPercent_lbl.Name = "toolProgressPercent_lbl";
            this.toolProgressPercent_lbl.Size = new System.Drawing.Size(151, 16);
            this.toolProgressPercent_lbl.TabIndex = 14;
            this.toolProgressPercent_lbl.Text = "0%";
            this.toolProgressPercent_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1065, 487);
            this.Controls.Add(this.toolProgressPercent_lbl);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.tool_progressbar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolVisualFeedback_lbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1081, 525);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast XML to CSV Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringIntervalSec_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringIntervalMin_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringIntervalHrs_numeric)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label toolVisualFeedback_lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button xmlDeleteNode_btn;
        private System.Windows.Forms.TextBox xmlNodeName_txtbox;
        private System.Windows.Forms.Button xmlAddNode_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button csvOutputPath_btn;
        private System.Windows.Forms.TextBox csvOutputPath_txtbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button xmlInputPath_btn;
        private System.Windows.Forms.TextBox xmlInputPath_txtbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button toolAction_btn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button xmlScanStructure_btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ProgressBar tool_progressbar;
        private System.Windows.Forms.TextBox csvFileSuffix_txtbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox csvFilePrefix_txtbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox csvFileName_txtbox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button xmlEditAlias_btn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox xmlNodeAlias_txtbox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown monitoringIntervalSec_numeric;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown monitoringIntervalMin_numeric;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown monitoringIntervalHrs_numeric;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button xmlEditName_btn;
        private System.Windows.Forms.ListView xmlNodesFilter_listview;
        private System.Windows.Forms.ColumnHeader node;
        private System.Windows.Forms.ColumnHeader csvNodeAlias;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label xmlNodesScanningTiming_lbl;
        private System.Windows.Forms.Label xmlToCsvConversionTiming_lbl;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label toolProgressPercent_lbl;
        private System.Windows.Forms.Button xmlConversionAbort_btn;
        private System.Windows.Forms.CheckBox csvBadOutputDelete_chbox;
    }
}

