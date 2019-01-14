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

        // Strings
        public static readonly string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();
        public static readonly string DEFAULT_NOTE_TITLE = "- Take Note -";
        public static readonly string APPLICATION_NAME = "Take Note";
        public static readonly string MAKE_HIDDEN = "Hide";
        public static readonly string MAKE_VISIBLE = "Show";
        public static readonly string REMOVE = "Remove";
        public static readonly string LABEL_NOTES_NAME = "label_notes";
        public static readonly string LABEL_NOTES_TITLE = "Notes";
        public static readonly string PANEL_NAME_START = "pnl";
        public static readonly string NAME_SEPERATOR = "_";
        public static readonly string NOTIFICATION_CREATE_NOTE = "Create Note";
        public static readonly string NOTIFICATION_SETTINGS = "Settings";
        public static readonly string NOTIFICATION_CLOSE = "Close";
        public static readonly string STRING_SPACE = " ";
        public static readonly string STRING_NEW_LINE = "\r\n";

        // Icons
        public static readonly Icon APPLICATION_ICON = new Icon(CURRENT_DIRECTORY + "/../../Icons/Note.ico");

        // Bitmaps
        public static readonly Bitmap IMAGE_ADD_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Add.png");
        public static readonly Bitmap IMAGE_REMOVE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Remove.png");
        public static readonly Bitmap IMAGE_CLOSE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Close.png");
        public static readonly Bitmap IMAGE_DRAG_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Drag.png");
        public static readonly Bitmap IMAGE_MINIMIZE_BUTTON = new Bitmap(CURRENT_DIRECTORY + "/../../Icons/Black/Minimize.png");

        // Sizes
        public static readonly Size SIZE_DEFAULT_BUTTON = new Size(30, 30);

        // Integers
        public static readonly int WIDTH_SCREEN = Screen.PrimaryScreen.Bounds.Width;
        public static readonly int HEIGHT_SCREEN = Screen.PrimaryScreen.Bounds.Height;
        public static readonly int HEIGHT_SETTINGS_NOTE_PANEL = 50;
        public static readonly int HEIGHT_SETTINGS_PANEL_HEAD = 30;
        public static readonly int HEIGHT_LEFT_MENU_BUTTON = 50;
        public static readonly int MARGIN_DEFAULT = 10;

        // Colors
        public static readonly Color COLOR_HEAD_DEFAULT = Color.FromArgb(239, 83, 80);
        public static readonly Color COLOR_BOLD_DEFAULT = Color.FromArgb(182, 24, 39);
        public static readonly Color COLOR_LEFT_MENU_DEFAULT = Color.FromArgb(225, 226, 225);
        public static readonly Color COLOR_LEFT_MENU_BUTTON_DEFAULT = Color.FromArgb(200, 200, 200);
        public static readonly Color COLOR_LEFT_MENU_BUTTON_HOVER = Color.FromArgb(180, 180, 180);
        public static readonly Color COLOR_NOTE_BACK = Color.FromArgb(249, 249, 149);

        // Prvates
        private static DBHelper _db = new DBHelper();
        private static bool _draggable = false;
        private static Point _lastLocation;

        #endregion

        #region [ - Methods - ]

        public static void LocateButtonsX(PictureBox pBox, int numberFromRight)
        {
            pBox.Location = new Point(pBox.Parent.Width - (Common.SIZE_DEFAULT_BUTTON.Width * numberFromRight), 0);
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

                if (form is Note)
                {
                    Common.CatchEdges(form);
                }
                
                control.Update();
            }
        }

        public static void CatchEdges(Control control)
        {   // Catch for X axis
            if (control.Location.X < 11)
            {
                control.Location = new Point(0, control.Location.Y);
            }

            int xLocationForRightEdge = (Common.WIDTH_SCREEN - control.Width);
            if (control.Location.X > xLocationForRightEdge - 11)
            {
                control.Location = new Point(xLocationForRightEdge, control.Location.Y);
            }

            // Catch for Y axis
            if (control.Location.Y < 11)
            {
                control.Location = new Point(control.Location.X, 0);
            }

            int yLocationForBottomEdge = (Common.HEIGHT_SCREEN - control.Height);
            if (control.Location.Y > yLocationForBottomEdge - 11)
            {
                control.Location = new Point(control.Location.X, yLocationForBottomEdge);
            }
        }

        #endregion

    }
}
