﻿namespace UXM
{
    partial class FormMain
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
            System.Windows.Forms.Label lblBreak;
            System.Windows.Forms.Label lblExePath;
            System.Windows.Forms.Label lblStatus;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnPatch = new System.Windows.Forms.Button();
            this.btnUnpack = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnExplore = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtExePath = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.llbUpdate = new System.Windows.Forms.LinkLabel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.ofdExe = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxSkip = new System.Windows.Forms.CheckBox();
            this.btnFileView = new System.Windows.Forms.Button();
            lblBreak = new System.Windows.Forms.Label();
            lblExePath = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBreak
            // 
            lblBreak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblBreak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblBreak.Location = new System.Drawing.Point(-20, 131);
            lblBreak.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBreak.Name = "lblBreak";
            lblBreak.Size = new System.Drawing.Size(998, 3);
            lblBreak.TabIndex = 31;
            // 
            // lblExePath
            // 
            lblExePath.AutoSize = true;
            lblExePath.Location = new System.Drawing.Point(18, 14);
            lblExePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblExePath.Name = "lblExePath";
            lblExePath.Size = new System.Drawing.Size(125, 20);
            lblExePath.TabIndex = 30;
            lblExePath.Text = "Executable Path";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(18, 143);
            lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(56, 20);
            lblStatus.TabIndex = 32;
            lblStatus.Text = "Status";
            // 
            // btnPatch
            // 
            this.btnPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatch.Location = new System.Drawing.Point(588, 80);
            this.btnPatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(112, 35);
            this.btnPatch.TabIndex = 27;
            this.btnPatch.Text = "Patch";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(async (sender, e) => await btnPatch_Click(sender, e));
            // 
            // btnUnpack
            // 
            this.btnUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnpack.Location = new System.Drawing.Point(466, 80);
            this.btnUnpack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUnpack.Name = "btnUnpack";
            this.btnUnpack.Size = new System.Drawing.Size(112, 35);
            this.btnUnpack.TabIndex = 26;
            this.btnUnpack.Text = "Unpack";
            this.btnUnpack.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(async (sender, e) => await btnUnpack_Click(sender, e));
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(710, 80);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(112, 35);
            this.btnRestore.TabIndex = 28;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.Enabled = false;
            this.btnAbort.Location = new System.Drawing.Point(831, 80);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(112, 35);
            this.btnAbort.TabIndex = 29;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnExplore
            // 
            this.btnExplore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExplore.Location = new System.Drawing.Point(831, 35);
            this.btnExplore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(112, 35);
            this.btnExplore.TabIndex = 25;
            this.btnExplore.Text = "Explore";
            this.btnExplore.UseVisualStyleBackColor = true;
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(710, 35);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 35);
            this.btnBrowse.TabIndex = 24;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtExePath
            // 
            this.txtExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExePath.Location = new System.Drawing.Point(18, 38);
            this.txtExePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExePath.Name = "txtExePath";
            this.txtExePath.Size = new System.Drawing.Size(680, 26);
            this.txtExePath.TabIndex = 23;
            this.txtExePath.Text = "{0}\\steamapps\\common\\EldenRing\\Game\\eldenring.exe";
            this.txtExePath.TextChanged += new System.EventHandler(this.txtExePath_TextChanged);
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.Location = new System.Drawing.Point(264, 257);
            this.lblUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(680, 20);
            this.lblUpdate.TabIndex = 35;
            this.lblUpdate.Text = "Checking for update...";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // llbUpdate
            // 
            this.llbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbUpdate.Location = new System.Drawing.Point(268, 257);
            this.llbUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbUpdate.Name = "llbUpdate";
            this.llbUpdate.Size = new System.Drawing.Size(675, 20);
            this.llbUpdate.TabIndex = 36;
            this.llbUpdate.TabStop = true;
            this.llbUpdate.Text = "New version available!";
            this.llbUpdate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.llbUpdate.Visible = false;
            this.llbUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbUpdate_LinkClicked);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(18, 168);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(924, 26);
            this.txtStatus.TabIndex = 33;
            // 
            // pbrProgress
            // 
            this.pbrProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrProgress.Location = new System.Drawing.Point(18, 208);
            this.pbrProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbrProgress.Maximum = 1000;
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(926, 35);
            this.pbrProgress.TabIndex = 34;
            // 
            // ofdExe
            // 
            this.ofdExe.FileName = "eldenring.exe";
            this.ofdExe.Filter = "FromSoft Game Executable|*.exe";
            this.ofdExe.Title = "Select FromSoft Game executable...";
            // 
            // cbxSkip
            // 
            this.cbxSkip.AutoSize = true;
            this.cbxSkip.Location = new System.Drawing.Point(137, 86);
            this.cbxSkip.Name = "cbxSkip";
            this.cbxSkip.Size = new System.Drawing.Size(168, 24);
            this.cbxSkip.TabIndex = 37;
            this.cbxSkip.Text = "Use Selected Files";
            this.cbxSkip.UseVisualStyleBackColor = true;
            this.cbxSkip.CheckedChanged += new System.EventHandler(this.cbxSkip_CheckedChanged);
            // 
            // btnFileView
            // 
            this.btnFileView.Location = new System.Drawing.Point(18, 80);
            this.btnFileView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFileView.Name = "btnFileView";
            this.btnFileView.Size = new System.Drawing.Size(112, 35);
            this.btnFileView.TabIndex = 38;
            this.btnFileView.Text = "View Files";
            this.btnFileView.UseVisualStyleBackColor = true;
            this.btnFileView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 274);
            this.Controls.Add(this.btnFileView);
            this.Controls.Add(this.cbxSkip);
            this.Controls.Add(this.llbUpdate);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(lblStatus);
            this.Controls.Add(this.pbrProgress);
            this.Controls.Add(lblBreak);
            this.Controls.Add(this.btnPatch);
            this.Controls.Add(this.btnUnpack);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnExplore);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtExePath);
            this.Controls.Add(lblExePath);
            this.Controls.Add(this.lblUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(2989, 330);
            this.MinimumSize = new System.Drawing.Size(984, 330);
            this.Name = "FormMain";
            this.Text = "UXM <version>";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.Button btnUnpack;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnExplore;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtExePath;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.LinkLabel llbUpdate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.OpenFileDialog ofdExe;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbxSkip;
        private System.Windows.Forms.Button btnFileView;
    }
}

