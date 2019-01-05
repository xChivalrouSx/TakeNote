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

namespace TakeNote
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            init();
        }


        #region [ - Constant Fields - ]

        private static readonly string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();

        private static readonly Icon NOTIFY_ICON = new Icon(CURRENT_DIRECTORY + "/../../Icons/Note.ico");

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

            Note note = new Note();
            note.Show();
        }

        private void CreateContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Show", MenuShow_Click);
            menu.MenuItems.Add("Close", MenuClose_Click);

            notifyIcon.ContextMenu = menu;
        }

        #endregion

    }
}
