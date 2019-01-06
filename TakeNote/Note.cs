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
using TakeNote.Classes;

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
        private static readonly Bitmap IMAGE_REMOVE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Remove.png");
        private static readonly Bitmap IMAGE_SETTINGS_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Settings.png");
        private static readonly Bitmap IMAGE_DRAG_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Drag.png");

        private static readonly Size DEFAULT_BUTTON_SIZE = new Size(30, 30);

        #endregion


        #region [ - Fields - ]

        public NoteDetail Detail;

        private bool _draggable = false;
        private Point _lastLocation;

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

        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            _draggable = true;
            _lastLocation = e.Location;
        }

        private void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            _draggable = false;
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draggable)
            {
                this.Location = new Point(
                    (this.Location.X - _lastLocation.X) + e.X, 
                    (this.Location.Y - _lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        #endregion


        #region [ - Private Methods - ]

        private void SetMainDesign()
        {
            pBox_remove.Image = IMAGE_REMOVE_BUTTON;
            LocateButtonsX(pBox_remove, 1);

            pBox_settings.Image = IMAGE_SETTINGS_BUTTON;
            LocateButtonsX(pBox_settings, 2);

            pBox_add.Image = IMAGE_ADD_BUTTON;
            LocateButtonsX(pBox_add, 3);

            pBox_drag.Image = IMAGE_DRAG_BUTTON;
            pBox_drag.Location = new Point(0, 0);

            label_title.Location = new Point(DEFAULT_BUTTON_SIZE.Width, 0);
            label_title.Size = new Size(this.Width - DEFAULT_BUTTON_SIZE.Width * 4, 30);
        }

        private void LocateButtonsX(PictureBox pBox, int numberFromRight)
        {
            pBox.Location = new Point(this.Width - (DEFAULT_BUTTON_SIZE.Width * numberFromRight), 0);
        }

        #endregion

    }
}
