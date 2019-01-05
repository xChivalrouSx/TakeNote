using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeNote.Models
{
    public class NoteDetail
    {
        #region [ - Fields - ]

        public int Id { get; set; }
        public string Title { get; set; }

        #endregion

        public NoteDetail()
        {
            Id = 0;
            Title = "New Note";
        }



    }
}
