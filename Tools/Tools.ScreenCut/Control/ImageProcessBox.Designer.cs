﻿namespace Tools.ScreenCut
{
    partial class ImageProcessBox
    {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // ImageProcessBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ImageProcessBox";
            this.Size = new System.Drawing.Size(971, 437);
            this.Load += new System.EventHandler(this.ImageProcessBox_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ImageProcessBox_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
