﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeNote
{
    public static class NoteManager
    {
        #region [ - Fields - ]

        private static List<Note> notes = new List<Note>();

        #endregion

        #region [ - Public Methods - ]
        
        public static List<Note> GetNotes()
        {
            return notes;
        }

        public static int NotesCount()
        {
            return notes.Count;
        }

        public static void AddNote(Note newNote)
        {
            notes.Add(newNote);
        }
        
        public static void RemoveNote(Note note)
        {
            foreach (Note n in notes)
            {
                if (n.Detail.Id == note.Detail.Id)
                {
                    notes.Remove(n);
                    return;
                }
            }
        }

        #endregion



    }
}
