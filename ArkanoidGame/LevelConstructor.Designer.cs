namespace ArkanoidGame
{
    partial class LevelConstructor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelConstructor));
            this.DrawArea = new System.Windows.Forms.PictureBox();
            this.AddBtn1lvl = new System.Windows.Forms.Button();
            this.AddBtn2lvl = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawArea)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawArea
            // 
            this.DrawArea.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.DrawArea, "DrawArea");
            this.DrawArea.Name = "DrawArea";
            this.DrawArea.TabStop = false;
            // 
            // AddBtn1lvl
            // 
            this.AddBtn1lvl.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.AddBtn1lvl, "AddBtn1lvl");
            this.AddBtn1lvl.ForeColor = System.Drawing.Color.White;
            this.AddBtn1lvl.Name = "AddBtn1lvl";
            this.AddBtn1lvl.UseVisualStyleBackColor = false;
            this.AddBtn1lvl.Click += new System.EventHandler(this.AddBtn1lvl_Click);
            // 
            // AddBtn2lvl
            // 
            this.AddBtn2lvl.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.AddBtn2lvl, "AddBtn2lvl");
            this.AddBtn2lvl.ForeColor = System.Drawing.Color.White;
            this.AddBtn2lvl.Name = "AddBtn2lvl";
            this.AddBtn2lvl.UseVisualStyleBackColor = false;
            this.AddBtn2lvl.Click += new System.EventHandler(this.AddBtn2lvl_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Savebtn, "Savebtn");
            this.Savebtn.ForeColor = System.Drawing.Color.White;
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.UseVisualStyleBackColor = false;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Exitbtn, "Exitbtn");
            this.Exitbtn.ForeColor = System.Drawing.Color.White;
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // LevelConstructor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.AddBtn2lvl);
            this.Controls.Add(this.AddBtn1lvl);
            this.Controls.Add(this.DrawArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LevelConstructor";
            ((System.ComponentModel.ISupportInitialize)(this.DrawArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawArea;
        private System.Windows.Forms.Button AddBtn1lvl;
        private System.Windows.Forms.Button AddBtn2lvl;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Exitbtn;
    }
}