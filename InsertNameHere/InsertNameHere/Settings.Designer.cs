namespace InsertNameHere
{
    partial class Settings
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.cbFullscreen = new System.Windows.Forms.CheckBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(173, 74);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(92, 74);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(75, 23);
            this.btReset.TabIndex = 1;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(11, 74);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // cbFullscreen
            // 
            this.cbFullscreen.AutoSize = true;
            this.cbFullscreen.Checked = true;
            this.cbFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFullscreen.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbFullscreen.Location = new System.Drawing.Point(12, 12);
            this.cbFullscreen.Name = "cbFullscreen";
            this.cbFullscreen.Size = new System.Drawing.Size(74, 17);
            this.cbFullscreen.TabIndex = 3;
            this.cbFullscreen.Text = "Fullscreen";
            this.cbFullscreen.UseVisualStyleBackColor = true;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(11, 48);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(82, 20);
            this.tbWidth.TabIndex = 4;
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(117, 48);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(82, 20);
            this.tbHeight.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Resolution";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 109);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.cbFullscreen);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btCancel);
            this.MaximumSize = new System.Drawing.Size(333, 148);
            this.MinimumSize = new System.Drawing.Size(333, 148);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.CheckBox cbFullscreen;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}