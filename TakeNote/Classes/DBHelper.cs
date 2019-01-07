using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace TakeNote.Classes
{
    public class DBHelper
    {

        #region [ - Constant Fields - ]

        private readonly string DATABASE_PATH = Directory.GetCurrentDirectory() + "/database.sqlite";

        private readonly string SQL_CREATE_STRING = "CREATE TABLE tbl_details (" +
                                                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                                    "title TEXT," +
                                                    "content TEXT);";

        private readonly string SQL_INSERT_STRING = "INSERT INTO tbl_details (title, content) VALUES ('{0}', '{1}');";

        private readonly string SQL_DELETE_STRING = "DELETE FROM tbl_details WHERE id = {0};";

        private readonly string SQL_UPDATE_STRING = "UPDATE tbl_details SET title = {0}, content = {1} WHERE id = {2};";
        
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

        public int Insert(string title, string content)
        {
            OpenConnection();

            int lastId = 0;
            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_INSERT_STRING, title, content), _connection);
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

        public void Update(int id, string title, string content)
        {
            OpenConnection();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_UPDATE_STRING, title, content, id), _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();
        }

        public void Delete(int id)
        {
            OpenConnection();

            try
            {
                SQLiteCommand _command = new SQLiteCommand(String.Format(SQL_DELETE_STRING, id), _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConnection();
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
                _connection = new SQLiteConnection("Data Source=" + DATABASE_PATH);
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
