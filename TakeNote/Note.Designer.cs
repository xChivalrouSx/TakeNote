namespace TakeNote
{
    partial class Note
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
            this.panel_main = new System.Windows.Forms.Panel();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.pBox_add = new System.Windows.Forms.PictureBox();
            this.pBox_remove = new System.Windows.Forms.PictureBox();
            this.pBox_close = new System.Windows.Forms.PictureBox();
            this.label_title = new System.Windows.Forms.Label();
            this.pBox_drag = new System.Windows.Forms.PictureBox();
            this.panel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_drag)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.panel_main.Controls.Add(this.textBox_content);
            this.panel_main.Location = new System.Drawing.Point(0, 30);
            this.panel_main.Name = "panel_main";
            this.panel_main.Padding = new System.Windows.Forms.Padding(5);
            this.panel_main.Size = new System.Drawing.Size(300, 300);
            this.panel_main.TabIndex = 0;
            // 
            // textBox_content
            // 
            this.textBox_content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.textBox_content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_content.Location = new System.Drawing.Point(5, 5);
            this.textBox_content.Margin = new System.Windows.Forms.Padding(20);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(290, 290);
            this.textBox_content.TabIndex = 0;
            this.textBox_content.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_content_KeyUp);
            // 
            // pBox_add
            // 
            this.pBox_add.Location = new System.Drawing.Point(234, -6);
            this.pBox_add.Name = "pBox_add";
            this.pBox_add.Size = new System.Drawing.Size(30, 30);
            this.pBox_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_add.TabIndex = 0;
            this.pBox_add.TabStop = false;
            this.pBox_add.Click += new System.EventHandler(this.Add_Click);
            this.pBox_add.MouseEnter += new System.EventHandler(this.PictureBox_Enter);
            this.pBox_add.MouseLeave += new System.EventHandler(this.PictureBox_Leave);
            // 
            // pBox_remove
            // 
            this.pBox_remove.Location = new System.Drawing.Point(198, -6);
            this.pBox_remove.Name = "pBox_remove";
            this.pBox_remove.Size = new System.Drawing.Size(30, 30);
            this.pBox_remove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_remove.TabIndex = 1;
            this.pBox_remove.TabStop = false;
            this.pBox_remove.Click += new System.EventHandler(this.Remove_Click);
            this.pBox_remove.MouseEnter += new System.EventHandler(this.PictureBox_Enter);
            this.pBox_remove.MouseLeave += new System.EventHandler(this.PictureBox_Leave);
            // 
            // pBox_close
            // 
            this.pBox_close.Location = new System.Drawing.Point(270, -6);
            this.pBox_close.Name = "pBox_close";
            this.pBox_close.Size = new System.Drawing.Size(30, 30);
            this.pBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_close.TabIndex = 2;
            this.pBox_close.TabStop = false;
            this.pBox_close.Click += new System.EventHandler(this.Close_Click);
            this.pBox_close.MouseEnter += new System.EventHandler(this.PictureBox_Enter);
            this.pBox_close.MouseLeave += new System.EventHandler(this.PictureBox_Leave);
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(12, 1);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(140, 23);
            this.label_title.TabIndex = 3;
            this.label_title.Text = "title_label";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_drag
            // 
            this.pBox_drag.Location = new System.Drawing.Point(0, 0);
            this.pBox_drag.Name = "pBox_drag";
            this.pBox_drag.Size = new System.Drawing.Size(30, 30);
            this.pBox_drag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_drag.TabIndex = 4;
            this.pBox_drag.TabStop = false;
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(149)))));
            this.ClientSize = new System.Drawing.Size(300, 330);
            this.Controls.Add(this.pBox_drag);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.pBox_close);
            this.Controls.Add(this.pBox_remove);
            this.Controls.Add(this.pBox_add);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Note";
            this.ShowInTaskbar = false;
            this.Text = "Note";
            this.Load += new System.EventHandler(this.Note_Load);
            this.Shown += new System.EventHandler(this.Note_Shown);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_drag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.PictureBox pBox_add;
        private System.Windows.Forms.PictureBox pBox_remove;
        private System.Windows.Forms.PictureBox pBox_close;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.PictureBox pBox_drag;
    }
}

