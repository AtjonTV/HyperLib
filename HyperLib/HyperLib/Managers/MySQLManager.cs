using MySql.Data.MySqlClient;
using System;

namespace HyperLib.Managers
{
    public class MySQLManager
    {
        MySqlConnection connection;
        public MySqlConnection Connection
        {
            get {
                return connection;
            }

            set {
                if (value != null)
                {
                    connection = value;
                }
            }
        }

        public MySQLManager()
        {

        }

        public MySQLManager(MySqlConnection conn)
        {
            connection = conn;
        }

        public Tuple<bool, string> GetValue(string Selection, string From, string Where, string IsEquialTo)
        {
            string returning = "";
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT "+Selection+" FROM "+From+" WHERE "+Where+" = '" + IsEquialTo + "';";
                MySqlDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        returning += reader.GetValue(i).ToString() + ";";
                }
                connection.Close();
            }
            catch (MySqlException MSE)
            {
                return new Tuple<bool, string>(false, MSE.Message);
            }
            return new Tuple<bool,string>(true, returning);
        }

        public Tuple<bool, string> GetValue(string SQL)
        {
            string returning = "";
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = SQL;
                MySqlDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        returning += reader.GetValue(i).ToString() + ";";
                }
                connection.Close();
            }
            catch (MySqlException MSE)
            {
                return new Tuple<bool, string>(false, MSE.Message);
            }
            return new Tuple<bool, string>(true, returning);
        }

        public Tuple<bool, string> GetValue(MySqlCommand command)
        {
            string returning = "";
            try
            {
                MySqlDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        returning += reader.GetValue(i).ToString() + ";";
                }
                connection.Close();
            }
            catch (MySqlException MSE)
            {
                return new Tuple<bool, string>(false, MSE.Message);
            }
            return new Tuple<bool, string>(true, returning);
        }

        public Tuple<bool, string> SetValue(string InsertInto, string BuildLike, string InsertThis)
        {
            try
            {
                string myInsertQuery = "INSERT INTO " + InsertInto + " " + BuildLike + " VALUES " + InsertThis + ";";
                MySqlCommand command = new MySqlCommand(myInsertQuery);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (MySqlException MSE)
            {
                return new Tuple<bool, string>(false, MSE.Message);
            }
            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> SetValue(string SQL)
        {
            try
            {
                string myInsertQuery = SQL;
                MySqlCommand command = new MySqlCommand(myInsertQuery);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (MySqlException MSE)
            {
                return new Tuple<bool, string>(false, MSE.Message);
            }
            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> SetValue(MySqlCommand command)
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (MySqlException MSE)
            {
                return new Tuple<bool, string>(false, MSE.Message);
            }
            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, Exception> TryConnection()
        {
            if(connection == null)
            {
                return new Tuple<bool, Exception>(false, null);
            }

            try
            {
                connection.Open();
                connection.Close();
            }
            catch(Exception ex)
            {
                return new Tuple<bool, Exception>(false, ex);
            }

            return new Tuple<bool, Exception>(true, null);
        }
    }
}
