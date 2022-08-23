using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Web;

namespace BirthdayReminder.App_Code
{
    public class DataAccessor
    {
        private static OdbcConnection conn = null;
        public static OdbcConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    conn = new OdbcConnection(Config.ConnectionString);
                }
                return conn;
            }
        }
        public static void CreateConnection(string connectionString)
        {
            conn = new OdbcConnection(connectionString);
        }

        private static OdbcCommand cmd = null;
        private static OdbcDataAdapter dataAdapter = null;

        #region Students
        public static List<Person> SelectPeople()
        {
            List<Person> result = new List<Person>();
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText = "SELECT People.PersonId, People.PersonName, People.PersonBirthdate, People.PersonPhotoName FROM People ORDER BY People.PersonBirthdate, People.PersonName";
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                int i = 1; //счётчик строк в таблице
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(new Person(row, i));
                    i++;
                }
            }
            return result;
        }

        public static Person SelectPerson(int id)
        {
            Person result = null;
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText = "SELECT People.PersonId, People.PersonName, People.PersonBirthdate, People.PersonPhotoName FROM People WHERE[PersonId]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[PersonId]", id);
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                    if (dataTable.Rows.Count > 0)
                    {
                        result = new Person(dataTable.Rows[0]);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static int InsertPerson(Person entity)
        {
            int result = 0;
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "INSERT INTO [People] ([PersonName], [PersonBirthdate], [PersonPhotoName]) VALUES (?,?,?)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[PersonName]", entity.PersonName);
                    cmd.Parameters.AddWithValue("[PersonBirthdate]", entity.PersonBirthdate);
                    cmd.Parameters.AddWithValue("[PersonPhotoName]", entity.PersonPhotoName);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT @@IDENTITY";
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        result = int.Parse(o.ToString());
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static void UpdatePerson(Person entity, bool updatePhoto)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    if (updatePhoto)
                    {
                        cmd.CommandText = "UPDATE [People] SET [PersonName]=?, [PersonBirthdate]=?, [PersonPhotoName]=? WHERE [PersonId]=?";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("[PersonName]", entity.PersonName);
                        cmd.Parameters.AddWithValue("[PersonBirthdate]", entity.PersonBirthdate);
                        cmd.Parameters.AddWithValue("[PersonPhotoName]", entity.PersonPhotoName);
                        cmd.Parameters.AddWithValue("[PersonId]", entity.PersonId);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE [People] SET [PersonName]=?, [PersonBirthdate]=? WHERE [PersonId]=?";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("[PersonName]", entity.PersonName);
                        cmd.Parameters.AddWithValue("[PersonBirthdate]", entity.PersonBirthdate);
                        cmd.Parameters.AddWithValue("[PersonId]", entity.PersonId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void DeletePerson(int id)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "DELETE FROM [People] WHERE [PersonId]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[PersonId]", id);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion
        public static void DeletePhoto(int id)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    DataTable dataTable = new DataTable();
                    cmd.CommandText = "SELECT People.PersonPhotoName FROM People WHERE[PersonId]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[PersonId]", id);
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                    DataRow dataRow = dataTable.Rows[0];
                    string photoname = dataRow["PersonPhotoName"].ToString();
                    if (photoname != "none.jpg")
                        File.Delete(HttpContext.Current.Server.MapPath("/image/people/") + photoname);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}