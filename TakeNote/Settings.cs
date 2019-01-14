using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeNote.Classes;
using TakeNote.Panels;

namespace TakeNote
{
    public partial class Settings : Form
    {

        #region [ - Import DLL - ]

        // For creat rounded rectangle Region
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        #endregion


        #region [ - Fields - ]

        DBHelper _db;

        #endregion


        #region [ - Public Methods - ]

        public Settings()
        {
            InitializeComponent();

            setUI();

            init();
        }

        public void UpdateContent(Panel panel)
        {
            if (panel is NotesControl)
            {
                panel_body.Controls.Remove(panel);

                NotesControl noteControl = new NotesControl(_db.GetNotes(), panel_body);

                panel_body.Controls.Add(noteControl);
            }
        }

        #endregion


        #region [ - Event Handlers - ]

        private void Settings_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MenuShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void MenuClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pBox_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SettingsButton_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Common.COLOR_LEFT_MENU_BUTTON_HOVER;
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Common.COLOR_LEFT_MENU_BUTTON_DEFAULT;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Name.Equals(Common.LABEL_NOTES_NAME))
            {
                NotesControl noteControl = new NotesControl(_db.GetNotes(), panel_body);

                panel_body.Controls.Add(noteControl);
            }
        }

        #endregion


        #region [ - Private Methods - ]

        private void setUI()
        {
            // Set Border to 'None'
            this.FormBorderStyle = FormBorderStyle.None;

            // Create Rounded Region
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Set head and menu Containers
            panel_head.Location = new Point(0, 0);
            panel_head.Size = new Size(this.Width, Common.SETTINGS_PANEL_HEAD_HEIGHT);
            panel_head.BackColor = Common.COLOR_HEAD_DEFAULT;

            panel_leftMenu.Location = new Point(0, Common.SETTINGS_PANEL_HEAD_HEIGHT);
            panel_leftMenu.Size = new Size(200, this.Height - panel_head.Height);
            panel_leftMenu.BackColor = Common.COLOR_LEFT_MENU_DEFAULT;

            panel_body.Location = new Point(panel_leftMenu.Width, panel_head.Height);
            panel_body.Size = new Size(this.Width - panel_leftMenu.Width, this.Height - panel_head.Height);
            panel_body.Padding = new Padding(10, 10, 10, 10);

            // Set System Buttons
            pBox_close.Size = Common.DEFAULT_BUTTON_SIZE;
            pBox_close.Image = Common.IMAGE_CLOSE_BUTTON;
            Common.LocateButtonsX(pBox_close, 1);

            // Set Title lable
            label_title.Location = new Point(0, 0);
            label_title.Size = new Size(this.Width - Common.DEFAULT_BUTTON_SIZE.Width, 30);
            label_title.Text = Common.APPLICATION_NAME;

            label_title.MouseDown += Common.Drag_MouseDown;
            label_title.MouseUp += Common.Drag_MouseUp;
            label_title.MouseMove += Common.Drag_MouseMove;

            SetLeftMenuContent();
        }

        private void SetLeftMenuContent()
        {
            AddNewContent(Common.LABEL_NOTES_NAME, Common.LABEL_NOTES_TITLE);
        }

        private void AddNewContent(string name, string title)
        {
            Label label_notes = new Label();
            label_notes.Name = name;
            label_notes.AutoSize = false;
            label_notes.Width = panel_leftMenu.Width;
            label_notes.Height = Common.LEFT_MENU_BUTTON_HEIGHT;
            label_notes.TextAlign = ContentAlignment.MiddleCenter;
            label_notes.Text = title;
            label_notes.Location = new Point(0, 0);
            label_notes.BackColor = Common.COLOR_LEFT_MENU_BUTTON_DEFAULT;

            label_notes.MouseEnter += SettingsButton_MouseEnter;
            label_notes.MouseLeave += SettingsButton_MouseLeave;
            label_notes.Click += SettingsButton_Click;

            panel_leftMenu.Controls.Add(label_notes);
        }

        private void init()
        {
            CreateContextMenu();
            notifyIcon.Icon = Common.APPLICATION_ICON;

            _db = new DBHelper();
            List<Note> notes = _db.GetNotes();
            if (notes.Count == 0)
            {
                Note note = new Note();
                note.Show();
            }
            else
            {
                foreach (Note note in notes)
                {
                    if (note.IsVisible == 1)
                    {
                        note.Show();
                    }
                }
            }
        }

        private void CreateContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Settings", MenuShow_Click);
            menu.MenuItems.Add("Close", MenuClose_Click);

            notifyIcon.ContextMenu = menu;
        }

        #endregion

    }
}
