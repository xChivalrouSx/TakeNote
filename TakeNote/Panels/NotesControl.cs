using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeNote.Classes;

namespace TakeNote.Panels
{
    class NotesControl : Panel
    {

        #region [ - Fields - ]

        private DBHelper _db = new DBHelper();

        #endregion


        #region [ - Public Methods - ]

        public NotesControl(List<Note> notes, Panel parentPanel)
        {   // Set Panel
            this.Width = parentPanel.Width - (Common.MARGIN_DEFAULT * 2);
            this.Height = parentPanel.Height - (Common.MARGIN_DEFAULT * 2);
            this.Location = new Point(Common.MARGIN_DEFAULT, Common.MARGIN_DEFAULT);

            foreach (Note note in notes)
            {
                SetNote(note);
            }
        }

        #endregion


        #region [ - Event Handlers - ]

        private void ShowHide_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Panel panel = (sender as Label).Parent as Panel;
            int noteId = Int32.Parse(panel.Name.Split(Common.NAME_SEPERATOR.ToCharArray()[0])[1]);
            Note note = _db.GetNote(noteId);

            if (label.Text.Equals(Common.MAKE_HIDDEN))
            {
                var forms = Application.OpenForms;
                foreach (Form form in forms)
                {
                    if (form is Note && (form as Note).Id == note.Id)
                    {
                        (form as Note).IsVisible = 0;
                        _db.ChangeVisibility(note.Id, 0);

                        (form as Note).Close();
                        (form as Note).Dispose();

                        label.Text = Common.MAKE_VISIBLE;
                        break;
                    }
                }
            }
            else
            {
                note.IsVisible = 1;
                _db.ChangeVisibility(note.Id, 1);

                note.Show();
                label.Text = Common.MAKE_HIDDEN;
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Panel panel = (sender as Label).Parent as Panel;
            int noteId = Int32.Parse(panel.Name.Split(Common.NAME_SEPERATOR.ToCharArray()[0])[1]);
            Note note = _db.GetNote(noteId);

            if (note.IsVisible == 1)
            {
                var forms = Application.OpenForms;
                foreach (Form form in forms)
                {
                    if (form is Note && (form as Note).Id == note.Id)
                    {
                        (form as Note).Close();
                        (form as Note).Dispose();
                        break;
                    }
                }
            }

            NoteManager.RemoveNote(note);
            (FindForm() as Settings).UpdateContent(Common.LABEL_NOTES_NAME);
        }

        private void Hover_Enter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void Hover_Leave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.BackColor = Common.COLOR_BOLD_DEFAULT;
        }

        #endregion


        #region [ - Private Methods - ]

        private void SetNote(Note note)
        {
            int noteNumber = this.Controls.Count;

            Panel panel = new Panel();
            panel.Name = Common.PANEL_NAME_START + Common.NAME_SEPERATOR + note.Id;
            panel.Size = new Size(this.Width - (Common.MARGIN_DEFAULT * 2), Common.HEIGHT_SETTINGS_NOTE_PANEL);
            panel.Location = new Point(
                Common.MARGIN_DEFAULT, 
                (Common.MARGIN_DEFAULT * (noteNumber + 1)) + (Common.HEIGHT_SETTINGS_NOTE_PANEL * noteNumber)
                );
            panel.BackColor = Common.COLOR_LEFT_MENU_DEFAULT;

            CreateContentOfNote(panel, note);

            this.Controls.Add(panel);
        }

        private void CreateContentOfNote(Panel panel, Note note)
        {   // Note Content
            Label label = new Label();
            label.AutoSize = false;
            label.Size = new Size((panel.Width / 2) - Common.MARGIN_DEFAULT, panel.Height - (Common.MARGIN_DEFAULT * 2));
            label.Location = new Point(Common.MARGIN_DEFAULT, Common.MARGIN_DEFAULT);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Text = note.Title + Common.STRING_NEW_LINE + note.Content.Replace(Common.STRING_NEW_LINE, Common.STRING_SPACE);

            panel.Controls.Add(label);

            // Show - Hide Button
            Label lbl_showHide = new Label();
            lbl_showHide.AutoSize = false;
            lbl_showHide.Size = new Size((panel.Width / 4) - (Common.MARGIN_DEFAULT * 2), panel.Height - (Common.MARGIN_DEFAULT * 2));
            lbl_showHide.Location = new Point(label.Width + (Common.MARGIN_DEFAULT * 2), Common.MARGIN_DEFAULT);
            lbl_showHide.TextAlign = ContentAlignment.MiddleCenter;
            lbl_showHide.BorderStyle = BorderStyle.FixedSingle;
            lbl_showHide.Text = (note.IsVisible == 0 ? Common.MAKE_VISIBLE : Common.MAKE_HIDDEN);
            lbl_showHide.BackColor = Common.COLOR_BOLD_DEFAULT;

            lbl_showHide.Click += ShowHide_Click;
            lbl_showHide.MouseEnter += Hover_Enter;
            lbl_showHide.MouseLeave += Hover_Leave;

            panel.Controls.Add(lbl_showHide);

            // Remove Button
            Label lbl_remove = new Label();
            lbl_remove.AutoSize = false;
            lbl_remove.Size = new Size((panel.Width / 4) - (Common.MARGIN_DEFAULT * 2), panel.Height - (Common.MARGIN_DEFAULT * 2));
            lbl_remove.Location = new Point(label.Width + lbl_showHide.Width + (Common.MARGIN_DEFAULT * 3), Common.MARGIN_DEFAULT);
            lbl_remove.TextAlign = ContentAlignment.MiddleCenter;
            lbl_remove.BorderStyle = BorderStyle.FixedSingle;
            lbl_remove.Text = Common.REMOVE;
            lbl_remove.BackColor = Common.COLOR_BOLD_DEFAULT;

            lbl_remove.Click += Remove_Click;
            lbl_remove.MouseEnter += Hover_Enter;
            lbl_remove.MouseLeave += Hover_Leave;

            panel.Controls.Add(lbl_remove);
        }

        #endregion

    }
}
