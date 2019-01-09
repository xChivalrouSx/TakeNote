using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeNote.Classes
{
    class Common
    {
        #region [ - Constant Fields - ]

        public static readonly string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();

        public static readonly Icon APPLICATION_ICON = new Icon(CURRENT_DIRECTORY + "/../../Icons/Note.ico");

        public static readonly Bitmap IMAGE_ADD_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Add.png");
        public static readonly Bitmap IMAGE_REMOVE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Remove.png");
        public static readonly Bitmap IMAGE_CLOSE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Close.png");
        public static readonly Bitmap IMAGE_DRAG_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Drag.png");
        public static readonly Bitmap IMAGE_MINIMIZE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Minimize.png");

        public static readonly Size DEFAULT_BUTTON_SIZE = new Size(30, 30);
        public static readonly int SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        public static readonly int SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;

        public static readonly string DEFAULT_NOTE_TITLE = "- Take Note -";
        public static readonly string APPLICATION_NAME = "Take Note";


        public static readonly int SETTINGS_PANEL_HEAD_HEIGHT = 30;
        public static readonly Color COLOR_HEAD_DEFAULT = Color.FromArgb(239, 83, 80);
        public static readonly Color COLOR_LEFT_MENU_DEFAULT = Color.FromArgb(225, 226, 225);

        private static DBHelper _db = new DBHelper();
        private static bool _draggable = false;
        private static Point _lastLocation;

        #endregion

        #region [ - Methods - ]

        public static void LocateButtonsX(PictureBox pBox, int numberFromRight)
        {
            pBox.Location = new Point(pBox.Parent.Width - (Common.DEFAULT_BUTTON_SIZE.Width * numberFromRight), 0);
        }

        public static void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            _draggable = true;
            _lastLocation = e.Location;
        }

        public static void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            Form form = control.FindForm();

            _draggable = false;

            if (form is Note)
            {
                Note note = form as Note;
                _db.ChangeLocation(note.Id, note.Location.X, note.Location.Y);
            }

            
        }

        public static void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            Form form = control.FindForm();

            if (_draggable)
            {
                form.Location = new Point(
                    (form.Location.X - _lastLocation.X) + e.X,
                    (form.Location.Y - _lastLocation.Y) + e.Y);

                Common.CatchEdges(form);

                control.Update();
            }
        }

        public static void CatchEdges(Control control)
        {   // Catch for X axis
            if (control.Location.X < 11)
            {
                control.Location = new Point(0, control.Location.Y);
            }

            int xLocationForRightEdge = (Common.SCREEN_WIDTH - control.Width);
            if (control.Location.X > xLocationForRightEdge - 11)
            {
                control.Location = new Point(xLocationForRightEdge, control.Location.Y);
            }

            // Catch for Y axis
            if (control.Location.Y < 11)
            {
                control.Location = new Point(control.Location.X, 0);
            }

            int yLocationForBottomEdge = (Common.SCREEN_HEIGHT - control.Height);
            if (control.Location.Y > yLocationForBottomEdge - 11)
            {
                control.Location = new Point(control.Location.X, yLocationForBottomEdge);
            }
        }

        #endregion

    }
}
