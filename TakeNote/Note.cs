using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeNote.Classes;

namespace TakeNote
{
    public partial class Note : Form
    {

        #region [ - Fields - ]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int IsVisible { get; set; }

        private DBHelper _db = new DBHelper();

        #endregion


        #region [ - Public Methods - ]

        public Note()
        {
            InitializeComponent();

            int x = Common.WIDTH_SCREEN - this.Width;
            int y = 0;

            setProperties(_db.Insert(Common.DEFAULT_NOTE_TITLE, string.Empty, x, y), Common.DEFAULT_NOTE_TITLE, string.Empty, 1, x, y);
        }

        public Note(int id, string title, string content, int isVisible, int locationX, int locationY)
        {
            InitializeComponent();

            setProperties(id, title, content, isVisible, locationX, locationY);
        }

        #endregion


        #region [ - Event Handlers - ]

        private void Note_Load(object sender, EventArgs e)
        {
            SetMainDesign();

            NoteManager.AddNote(this);
        }

        private void Note_Shown(object sender, EventArgs e)
        {
            textBox_content.SelectionStart = textBox_content.Text.Length;
            textBox_content.SelectionLength = 0;

            Location = _db.GetLocation(Id);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            NoteManager.RemoveNote(this);

            this.Close();
            this.Dispose();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            IsVisible = 0;
            _db.ChangeVisibility(this.Id, 0);

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

        private void textBox_content_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Content = textBox.Text;

            // Background thread for update database
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                _db.Update(Id, Title, Content, IsVisible);
            }).Start();
        }

        #endregion


        #region [ - Private Methods - ]

        private void setProperties(int id, string title, string content, int isVisible, int locationX, int locationY)
        {
            Id = id;
            label_title.Text = Title = title;
            textBox_content.Text = Content = content;
            this.IsVisible = isVisible;
            this.Location = new Point(locationX, locationY);

            pBox_drag.MouseDown += Common.Drag_MouseDown;
            pBox_drag.MouseUp += Common.Drag_MouseUp;
            pBox_drag.MouseMove += Common.Drag_MouseMove;
        }

        private void SetMainDesign()
        {
            pBox_close.Size = Common.SIZE_DEFAULT_BUTTON;
            pBox_close.Image = Common.IMAGE_CLOSE_BUTTON;
            Common.LocateButtonsX(pBox_close, 1);

            pBox_remove.Size = Common.SIZE_DEFAULT_BUTTON;
            pBox_remove.Image = Common.IMAGE_REMOVE_BUTTON;
            Common.LocateButtonsX(pBox_remove, 2);

            pBox_add.Size = Common.SIZE_DEFAULT_BUTTON;
            pBox_add.Image = Common.IMAGE_ADD_BUTTON;
            Common.LocateButtonsX(pBox_add, 3);

            pBox_drag.Size = Common.SIZE_DEFAULT_BUTTON;
            pBox_drag.Image = Common.IMAGE_DRAG_BUTTON;
            pBox_drag.Location = new Point(0, 0);

            label_title.Location = new Point(Common.SIZE_DEFAULT_BUTTON.Width, 0);
            label_title.Size = new Size(this.Width - Common.SIZE_DEFAULT_BUTTON.Width * 4, 30);
        }

        

        #endregion

    }
}
