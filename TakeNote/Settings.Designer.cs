namespace TakeNote
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_head = new System.Windows.Forms.Panel();
            this.label_title = new System.Windows.Forms.Label();
            this.pBox_close = new System.Windows.Forms.PictureBox();
            this.panel_leftMenu = new System.Windows.Forms.Panel();
            this.panel_body = new System.Windows.Forms.Panel();
            this.panel_head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_close)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "TakeNoteApp";
            this.notifyIcon.Visible = true;
            // 
            // panel_head
            // 
            this.panel_head.Controls.Add(this.label_title);
            this.panel_head.Controls.Add(this.pBox_close);
            this.panel_head.Location = new System.Drawing.Point(12, 12);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(1056, 100);
            this.panel_head.TabIndex = 0;
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_title.Location = new System.Drawing.Point(27, 29);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(100, 23);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "label1";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_close
            // 
            this.pBox_close.Location = new System.Drawing.Point(97, 12);
            this.pBox_close.Name = "pBox_close";
            this.pBox_close.Size = new System.Drawing.Size(59, 50);
            this.pBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_close.TabIndex = 1;
            this.pBox_close.TabStop = false;
            this.pBox_close.Click += new System.EventHandler(this.pBox_close_Click);
            // 
            // panel_leftMenu
            // 
            this.panel_leftMenu.Location = new System.Drawing.Point(12, 118);
            this.panel_leftMenu.Name = "panel_leftMenu";
            this.panel_leftMenu.Size = new System.Drawing.Size(200, 448);
            this.panel_leftMenu.TabIndex = 1;
            // 
            // panel_body
            // 
            this.panel_body.Location = new System.Drawing.Point(218, 118);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(850, 448);
            this.panel_body.TabIndex = 2;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 578);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_leftMenu);
            this.Controls.Add(this.panel_head);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.panel_head.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.Panel panel_leftMenu;
        private System.Windows.Forms.PictureBox pBox_close;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel_body;
    }
}