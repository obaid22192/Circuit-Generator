namespace circuit
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
            this.components = new System.ComponentModel.Container();
            this.panelsidebar = new System.Windows.Forms.Panel();
            this.panelline = new System.Windows.Forms.Panel();
            this.CBLine = new System.Windows.Forms.CheckBox();
            this.pbsink = new System.Windows.Forms.PictureBox();
            this.pbsource = new System.Windows.Forms.PictureBox();
            this.pbnot = new System.Windows.Forms.PictureBox();
            this.pbor = new System.Windows.Forms.PictureBox();
            this.pband = new System.Windows.Forms.PictureBox();
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panelmain = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelsidebar.SuspendLayout();
            this.panelline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbsink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbnot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pband)).BeginInit();
            this.mainmenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelsidebar
            // 
            this.panelsidebar.Controls.Add(this.panelline);
            this.panelsidebar.Controls.Add(this.pbsink);
            this.panelsidebar.Controls.Add(this.pbsource);
            this.panelsidebar.Controls.Add(this.pbnot);
            this.panelsidebar.Controls.Add(this.pbor);
            this.panelsidebar.Controls.Add(this.pband);
            this.panelsidebar.Location = new System.Drawing.Point(12, 207);
            this.panelsidebar.Name = "panelsidebar";
            this.panelsidebar.Size = new System.Drawing.Size(125, 435);
            this.panelsidebar.TabIndex = 3;
            // 
            // panelline
            // 
            this.panelline.Controls.Add(this.CBLine);
            this.panelline.Location = new System.Drawing.Point(7, 211);
            this.panelline.Name = "panelline";
            this.panelline.Size = new System.Drawing.Size(115, 70);
            this.panelline.TabIndex = 7;
            // 
            // CBLine
            // 
            this.CBLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBLine.BackgroundImage = global::circuit.Properties.Resources.line;
            this.CBLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CBLine.Location = new System.Drawing.Point(5, 7);
            this.CBLine.Name = "CBLine";
            this.CBLine.Size = new System.Drawing.Size(105, 54);
            this.CBLine.TabIndex = 0;
            this.CBLine.UseVisualStyleBackColor = true;
            this.CBLine.Click += new System.EventHandler(this.CBLine_Click);
            // 
            // pbsink
            // 
            this.pbsink.Image = global::circuit.Properties.Resources.Onbulb;
            this.pbsink.Location = new System.Drawing.Point(4, 366);
            this.pbsink.Name = "pbsink";
            this.pbsink.Size = new System.Drawing.Size(121, 56);
            this.pbsink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbsink.TabIndex = 5;
            this.pbsink.TabStop = false;
            this.pbsink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbsink_MouseDown);
            // 
            // pbsource
            // 
            this.pbsource.Image = global::circuit.Properties.Resources.source;
            this.pbsource.Location = new System.Drawing.Point(4, 296);
            this.pbsource.Name = "pbsource";
            this.pbsource.Size = new System.Drawing.Size(118, 54);
            this.pbsource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbsource.TabIndex = 4;
            this.pbsource.TabStop = false;
            this.pbsource.DoubleClick += new System.EventHandler(this.pbsource_DoubleClick);
            this.pbsource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbsource_MouseDown);
            // 
            // pbnot
            // 
            this.pbnot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbnot.Image = global::circuit.Properties.Resources.not;
            this.pbnot.Location = new System.Drawing.Point(7, 152);
            this.pbnot.Name = "pbnot";
            this.pbnot.Size = new System.Drawing.Size(118, 48);
            this.pbnot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbnot.TabIndex = 2;
            this.pbnot.TabStop = false;
            this.pbnot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbnot_MouseDown);
            // 
            // pbor
            // 
            this.pbor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbor.Image = global::circuit.Properties.Resources.or;
            this.pbor.Location = new System.Drawing.Point(4, 76);
            this.pbor.Name = "pbor";
            this.pbor.Size = new System.Drawing.Size(121, 47);
            this.pbor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbor.TabIndex = 1;
            this.pbor.TabStop = false;
            this.pbor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbor_MouseDown);
            // 
            // pband
            // 
            this.pband.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pband.Image = global::circuit.Properties.Resources.and;
            this.pband.Location = new System.Drawing.Point(7, 3);
            this.pband.Name = "pband";
            this.pband.Size = new System.Drawing.Size(118, 50);
            this.pband.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pband.TabIndex = 0;
            this.pband.TabStop = false;
            this.pband.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pband_MouseDown);
            // 
            // mainmenu
            // 
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(884, 24);
            this.mainmenu.TabIndex = 4;
            this.mainmenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newProjectToolStripMenuItem.Text = "New Circuit";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openProjectToolStripMenuItem.Text = "Open Circuit";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "Save Circuit";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save Circuit As ";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.helpToolStripMenuItem.Text = "Edit";
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.cToolStripMenuItem.Text = "Clear Grid";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // Panelmain
            // 
            this.Panelmain.AllowDrop = true;
            this.Panelmain.AutoSize = true;
            this.Panelmain.BackgroundImage = global::circuit.Properties.Resources._500cup425052_1495;
            this.Panelmain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panelmain.Location = new System.Drawing.Point(143, 47);
            this.Panelmain.Name = "Panelmain";
            this.Panelmain.Size = new System.Drawing.Size(741, 595);
            this.Panelmain.TabIndex = 2;
            this.Panelmain.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panelmain_DragDrop);
            this.Panelmain.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panelmain_DragEnter);
            this.Panelmain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panelmain_MouseDown);
            this.Panelmain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panelmain_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.mainmenu);
            this.Controls.Add(this.panelsidebar);
            this.Controls.Add(this.Panelmain);
            this.Name = "Form1";
            this.Text = "CircuitGenrator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panelsidebar.ResumeLayout(false);
            this.panelline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbsink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbnot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pband)).EndInit();
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panelmain;
        private System.Windows.Forms.Panel panelsidebar;
        private System.Windows.Forms.PictureBox pbsink;
        private System.Windows.Forms.PictureBox pbsource;
        private System.Windows.Forms.PictureBox pbnot;
        private System.Windows.Forms.PictureBox pbor;
        private System.Windows.Forms.PictureBox pband;
        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.Panel panelline;
        private System.Windows.Forms.CheckBox CBLine;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

