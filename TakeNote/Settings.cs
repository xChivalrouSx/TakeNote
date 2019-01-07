using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeNote.Classes;

namespace TakeNote
{
    public partial class Settings : Form
    {

        #region [ - Constant Fields - ]

        private static readonly string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();

        private static readonly Icon NOTIFY_ICON = new Icon(CURRENT_DIRECTORY + "/../../Icons/Note.ico");

        #endregion


        #region [ - Fields - ]

        DBHelper _db;

        #endregion


        #region [ - Public Methods - ]

        public Settings()
        {
            InitializeComponent();
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

        #endregion


        #region [ - Private Methods - ]

        private void init()
        {
            CreateContextMenu();
            notifyIcon.Icon = NOTIFY_ICON;

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
