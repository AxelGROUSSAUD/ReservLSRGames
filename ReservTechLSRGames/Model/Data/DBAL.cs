using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames
{
    public class DBAL
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBAL()
        {
            Initialize();
        }
        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "Club_Fromage";
            uid = "root";
            password = "5MichelAnnecy";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {

            query = "INSERT INTO " + query;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;
                Console.WriteLine(query);
                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {

            query = "UPDATE " + query;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            query = "DELETE FROM " + query;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        /*
        //Count statement
        public int Count(string query)
        {
            
            int Count = -1;
            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");
                //close Connection
                this.CloseConnection();
                return Count;
            }
            else
            {
                return Count;
            }
        }*/


        public void ExecQuery(string query)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        private DataSet RQuery(string query)
        {
            DataSet unDataSet = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

            adapter.Fill(unDataSet);
            return unDataSet;
        }

        public DataTable SelectAll(string table)
        {

            string query = "SELECT * FROM " + table;
            DataSet unDataSet = this.RQuery(query);
            DataTable unDataTable = unDataSet.Tables[0];
            return unDataTable;
        }

        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            string query = "SELECT * FROM " + table + " WHERE " + fieldTestCondition;
            DataSet unDataSet = this.RQuery(query);
            DataTable unDataTable = unDataSet.Tables[0];
            return unDataTable;
        }

        public DataRow SelectById(string table, int id)
        {
            string query = "";
            if (table == "Reservation")
            {
                query = "SELECT * FROM " + table + " WHERE idReservation = '" + id + "';";
            }
            //if (table == "Fromage")
            //{
            //    query = "SELECT * FROM " + table + " WHERE identifiant = '" + id + "';";
            //}
            DataSet unDataSet = this.RQuery(query);
            DataTable unDataTable = unDataSet.Tables[0];
            DataRow unDataRow = unDataTable.Rows[0];
            return unDataRow;
        }
    }
}
