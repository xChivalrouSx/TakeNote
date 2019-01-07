using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;

namespace TakeNote.Classes
{
    public class DBHelper
    {

        #region [ - Constant Fields - ]

        private static readonly string DATABASE_PATH = Directory.GetCurrentDirectory() + "/database.sqlite";
        private static readonly string CONNECTION_STRING = "Data Source=" + DATABASE_PATH;

        private static readonly string DB_COLUMN_ID = "id";
        private static readonly string DB_COLUMN_TITLE = "title";
        private static readonly string DB_COLUMN_CONTENT = "content";
        private static readonly string DB_COLUMN_ISVISIBLE = "isVisible";
        private static readonly string DB_COLUMN_LOCATIONX = "locationX";
        private static readonly string DB_COLUMN_LOCATIONY = "locationY";

        private static readonly string SQL_CREATE_STRING = "CREATE TABLE tbl_details (" +
                                                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                                    "title TEXT," +
                                                    "content TEXT," +
                                                    "isVisible INTEGER NOT NULL DEFAULT 1," + 
                                                    "locationX INTEGER," + 
                                                    "locationY INTEGER);";

        private static readonly string SQL_INSERT = "INSERT INTO tbl_details (title, content, locationX, locationY) VALUES ('{0}', '{1}', {2}, {3});";

        private static readonly string SQL_DELETE = "DELETE FROM tbl_details WHERE id = {0};";

        private static readonly string SQL_UPDATE = "UPDATE tbl_details SET title = '{0}', content = '{1}', isVisible = {2} WHERE id = {3};";

        private static readonly string SQL_CHANGE_VISIBILITY = "UPDATE tbl_details SET isVisible = {0} WHERE id = {1};";

        private static readonly string SQL_CHANGE_LOCATION = "UPDATE tbl_details SET locationX = {0}, locationY = {1} WHERE id = {2};";

        private static readonly string SQL_SELECT_ALL = "SELECT * FROM tbl_details";

        private static readonly string SQL_SELECT_NOTE = "SELECT * FROM tbl_details WHERE id = {0}";

        #endregion


        #region [ - Fields - ]

        SQLiteConnection _connection;

        #endregion


        #region [ - Public Methods - ]

        public DBHelper()
        {
            if (!System.IO.File.Exists(DATABASE_PATH))
            {
                CreateDatabase();
            }
        }

        public int Insert(string title, string content, int locationX, int locationY)
        {
            OpenConnection();

            int lastId = 0;
            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_INSERT, title, content, locationX, locationY), _connection);
                _command.ExecuteNonQuery();
                lastId = (int)_connection.LastInsertRowId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();

            return lastId;
        }

        public void Update(int id, string title, string content, int isVisible)
        {
            // New connection is created each time for thread usage   
            SQLiteConnection conn = new SQLiteConnection(CONNECTION_STRING);
            conn.Open();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_UPDATE, title, content, isVisible, id), conn);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Close the connection
            conn.Close();
            conn.Dispose();
        }

        public void Delete(int id)
        {
            OpenConnection();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_DELETE, id), _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();
        }

        public void ChangeVisibility(int id, int visibility)
        {
            OpenConnection();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_CHANGE_VISIBILITY, visibility, id), _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();
        }

        public void ChangeLocation(int id, int locationX, int locationY)
        {
            OpenConnection();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_CHANGE_LOCATION, locationX, locationY, id), _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();
        }

        public List<Note> GetNotes()
        {
            OpenConnection();

            List<Note> notes = new List<Note>();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(SQL_SELECT_ALL, _connection);
                SQLiteDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    Note note = new Note(
                        Int32.Parse(reader[DB_COLUMN_ID].ToString()), 
                        reader[DB_COLUMN_TITLE].ToString(), 
                        reader[DB_COLUMN_CONTENT].ToString(), 
                        Int32.Parse(reader[DB_COLUMN_ISVISIBLE].ToString()),
                        Int32.Parse(reader[DB_COLUMN_LOCATIONX].ToString()),
                        Int32.Parse(reader[DB_COLUMN_LOCATIONY].ToString())
                        );

                    notes.Add(note);
                    NoteManager.AddNote(note);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();

            return notes;
        }

        public Note GetNote(int id)
        {
            OpenConnection();

            Note note = null;

            try
            {
                SQLiteCommand _command = new SQLiteCommand(string.Format(SQL_SELECT_NOTE, id), _connection);
                SQLiteDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    note = new Note(
                        Int32.Parse(reader[DB_COLUMN_ID].ToString()),
                        reader[DB_COLUMN_TITLE].ToString(),
                        reader[DB_COLUMN_CONTENT].ToString(),
                        Int32.Parse(reader[DB_COLUMN_ISVISIBLE].ToString()),
                        Int32.Parse(reader[DB_COLUMN_LOCATIONX].ToString()),
                        Int32.Parse(reader[DB_COLUMN_LOCATIONY].ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();

            return note;
        }

        public Point GetLocation(int id)
        {
            OpenConnection();

            Point point = new Point(0, 0);

            try
            {
                SQLiteCommand _command = new SQLiteCommand(string.Format(SQL_SELECT_NOTE, id), _connection);
                SQLiteDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                {
                    point = new Point(
                        Int32.Parse(reader[DB_COLUMN_LOCATIONX].ToString()),
                        Int32.Parse(reader[DB_COLUMN_LOCATIONY].ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();

            return point;
        }

        #endregion


        #region [ - Private Methods - ]

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile(DATABASE_PATH);

            try
            {
                OpenConnection();

                SQLiteCommand _command = new SQLiteCommand(SQL_CREATE_STRING, _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OpenConnection()
        {
            try
            {
                _connection = new SQLiteConnection(CONNECTION_STRING);
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CloseConnection()
        {
            _connection.Close();
            _connection.Dispose();    
        }

        #endregion

    }
}
