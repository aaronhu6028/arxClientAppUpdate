namespace arxClientAppUpdater
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbProject = new System.Windows.Forms.ListBox();
            this.lbCurrent2 = new System.Windows.Forms.Label();
            this.lbNew2 = new System.Windows.Forms.Label();
            this.lbRemote = new System.Windows.Forms.Label();
            this.lbRelease = new System.Windows.Forms.Label();
            this.lbLocal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAllInOne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProject
            // 
            this.lbProject.FormattingEnabled = true;
            this.lbProject.ItemHeight = 16;
            this.lbProject.Location = new System.Drawing.Point(14, 13);
            this.lbProject.Margin = new System.Windows.Forms.Padding(4);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(325, 100);
            this.lbProject.TabIndex = 1;
            this.lbProject.SelectedIndexChanged += new System.EventHandler(this.lbProject_SelectedIndexChanged);
            // 
            // lbCurrent2
            // 
            this.lbCurrent2.AutoSize = true;
            this.lbCurrent2.Location = new System.Drawing.Point(11, 120);
            this.lbCurrent2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrent2.Name = "lbCurrent2";
            this.lbCurrent2.Size = new System.Drawing.Size(112, 16);
            this.lbCurrent2.TabIndex = 2;
            this.lbCurrent2.Text = "Release Version:";
            // 
            // lbNew2
            // 
            this.lbNew2.AutoSize = true;
            this.lbNew2.Location = new System.Drawing.Point(11, 136);
            this.lbNew2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNew2.Name = "lbNew2";
            this.lbNew2.Size = new System.Drawing.Size(111, 16);
            this.lbNew2.TabIndex = 3;
            this.lbNew2.Text = "Remote Dev Ver:";
            // 
            // lbRemote
            // 
            this.lbRemote.Location = new System.Drawing.Point(121, 136);
            this.lbRemote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRemote.Name = "lbRemote";
            this.lbRemote.Size = new System.Drawing.Size(120, 16);
            this.lbRemote.TabIndex = 8;
            // 
            // lbRelease
            // 
            this.lbRelease.Location = new System.Drawing.Point(121, 120);
            this.lbRelease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRelease.Name = "lbRelease";
            this.lbRelease.Size = new System.Drawing.Size(120, 16);
            this.lbRelease.TabIndex = 7;
            // 
            // lbLocal
            // 
            this.lbLocal.Location = new System.Drawing.Point(121, 152);
            this.lbLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(120, 16);
            this.lbLocal.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 152);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Local Dev Ver:";
            // 
            // btnAllInOne
            // 
            this.btnAllInOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllInOne.Location = new System.Drawing.Point(47, 176);
            this.btnAllInOne.Name = "btnAllInOne";
            this.btnAllInOne.Size = new System.Drawing.Size(253, 23);
            this.btnAllInOne.TabIndex = 16;
            this.btnAllInOne.Text = "ALL IN ONE";
            this.btnAllInOne.UseVisualStyleBackColor = true;
            this.btnAllInOne.Click += new System.EventHandler(this.btnAllInOne_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 211);
            this.Controls.Add(this.btnAllInOne);
            this.Controls.Add(this.lbLocal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbRemote);
            this.Controls.Add(this.lbRelease);
            this.Controls.Add(this.lbNew2);
            this.Controls.Add(this.lbCurrent2);
            this.Controls.Add(this.lbProject);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Update Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbProject;
        private System.Windows.Forms.Label lbCurrent2;
        private System.Windows.Forms.Label lbNew2;
        private System.Windows.Forms.Label lbRemote;
        private System.Windows.Forms.Label lbRelease;
        private System.Windows.Forms.Label lbLocal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAllInOne;
    }
}

