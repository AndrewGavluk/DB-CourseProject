using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace My_Project
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string[] ERRORS = new string[5];

        public DBConnect()  //Constructor
        {
            Initialize();
            OpenConnection();
            CloseConnection();
            ERRORS[0] = "Wrong password";
            ERRORS[1] = "Cannot contact server. Contact administratior. Eror_ID=1";
            ERRORS[2] = "Cannot contact server. Contact administratior. Eror_ID=2";
        }
        public ~DBConnect()
        { 
        
        }

        private void Initialize()//Initialize values
        {
            server = "localhost";
            database = "trade_platform";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show(ERRORS[1]);
                        break;

                    case 1045:
                        MessageBox.Show(ERRORS[0]);
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()//Close connection
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        protected List<string>[] SelectPassword(string query)
        {

            //Create a list to store the result
            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["Password"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                cmd.Dispose();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        } //Возвращает совпадения с паролем в БД
        public bool TryConnect(string UID, string PWD, int TYPE)
        {
            string ID_Table, Table, query;
            bool answer = true;
            Table = "tab_trader";
            ID_Table = "trader_id";
            switch (TYPE)
            {
                case 3: Table = "tab_admin"; ID_Table = "admin_id"; break;
            }

            query = " SELECT Password" + " FROM " + Table + " Where " + ID_Table + " = '" +  UID + "'";
            List<string>[] passwords=this.SelectPassword(query);

            try
            {
                if (PWD == passwords[0].First()) MessageBox.Show("Connection completed sucsesfuly");
                else
                {
                    MessageBox.Show(ERRORS[2]);
                    answer = false;
                }
            }
            catch 
            {
                MessageBox.Show(ERRORS[0]);
                answer = false;
            }
            return answer;
        } 

    }
}
