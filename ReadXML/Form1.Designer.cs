namespace ReadXML
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataReasonGridView = new System.Windows.Forms.DataGridView();
            this.dataTransitionGridView = new System.Windows.Forms.DataGridView();
            this.dataStateGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReasonGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTransitionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataStateGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Učitaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 467);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(775, 108);
            this.listBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 438);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataReasonGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(766, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ChangeReason";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataTransitionGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(766, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transition";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataStateGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(766, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "State";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataReasonGridView
            // 
            this.dataReasonGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataReasonGridView.Location = new System.Drawing.Point(6, 35);
            this.dataReasonGridView.Name = "dataReasonGridView";
            this.dataReasonGridView.Size = new System.Drawing.Size(754, 377);
            this.dataReasonGridView.TabIndex = 0;
            // 
            // dataTransitionGridView
            // 
            this.dataTransitionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTransitionGridView.Location = new System.Drawing.Point(4, 31);
            this.dataTransitionGridView.Name = "dataTransitionGridView";
            this.dataTransitionGridView.Size = new System.Drawing.Size(762, 378);
            this.dataTransitionGridView.TabIndex = 0;
            // 
            // dataStateGridView
            // 
            this.dataStateGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStateGridView.Location = new System.Drawing.Point(0, 35);
            this.dataStateGridView.Name = "dataStateGridView";
            this.dataStateGridView.Size = new System.Drawing.Size(766, 374);
            this.dataStateGridView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 624);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "XMLReader";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataReasonGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTransitionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataStateGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataReasonGridView;
        private System.Windows.Forms.DataGridView dataTransitionGridView;
        private System.Windows.Forms.DataGridView dataStateGridView;
    }
}

