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
using TakeNote.Models;

namespace TakeNote
{
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
        }


        #region [ - Constant Fields - ]

        private static readonly string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();

        private static readonly Bitmap IMAGE_ADD_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Add.png");
        private static readonly Bitmap IMAGE_CLOSE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Close.png");
        private static readonly Bitmap IMAGE_SETTINGS_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Settings.png");

        private static readonly Size DEFAULT_BUTTON_SIZE = new Size(30, 30);

        #endregion


        #region [ - Fields - ]

        public NoteDetail Detail;

        #endregion


        #region [ - Event Handlers - ]

        private void Note_Load(object sender, EventArgs e)
        {
            SetMainDesign();

            Detail = new NoteDetail();
            label_title.Text = Detail.Title;

            NoteManager.AddNote(this);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            NoteManager.RemoveNote(this);

            this.Close();
            this.Dispose();
        }

        private void PictureBox_Enter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            pictureBox.BackColor = Color.FromArgb(50 ,0 , 0, 0);
        }

        private void PictureBox_Leave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            pictureBox.BackColor = Color.Transparent;
        }

        #endregion


        #region [ - Private Methods - ]

        private void SetMainDesign()
        {
            pBox_close.Image = IMAGE_CLOSE_BUTTON;
            LocateButtonsX(pBox_close, 1);

            pBox_settings.Image = IMAGE_SETTINGS_BUTTON;
            LocateButtonsX(pBox_settings, 2);

            pBox_add.Image = IMAGE_ADD_BUTTON;
            LocateButtonsX(pBox_add, 3);

            label_title.Location = new Point(0, 0);
            label_title.Size = new Size(this.Width - DEFAULT_BUTTON_SIZE.Width * 3, 30);
        }

        private void LocateButtonsX(PictureBox pBox, int numberFromRight)
        {
            pBox.Location = new Point(this.Width - (DEFAULT_BUTTON_SIZE.Width * numberFromRight), 0);
        }

        #endregion

    }
}
