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

            // Set System Buttons
            pBox_close.Size = Common.DEFAULT_BUTTON_SIZE;
            pBox_close.Image = Common.IMAGE_CLOSE_BUTTON;
            Common.LocateButtonsX(pBox_close, 1);

            // Set Title lable
            label_title.Location = new Point(0, 0);
            label_title.Size = new Size(this.Width - Common.DEFAULT_BUTTON_SIZE.Width, 30);
            label_title.Text = Common.APPLICATION_NAME;
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
