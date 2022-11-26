using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace StudentMangement
{
    public static class MyDB
    {
        //connection
        
        public static MySqlConnection conn = new MySqlConnection(@"Data source=localhost;port=3306;user id=root;password=Adel@19122001+;database= studentmangement");
        //fonction to get connection
            public static MySqlConnection GetConnection
            {
            get {return conn;}         
            }
        //fonction to open connection
        public static void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed) 
                    conn.Open();
        }
        //fonction to close connection
        public static void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public static bool LoginVerfication(string textName,string textPass)
        {
            OpenConnection();
            int i= 0;
            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("select * from Users where UserName=@usn AND Pass=@pass ", GetConnection);
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textName;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textPass;
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            //adapter.SelectCommand = command;
            adapter.Fill(table);
            i= Convert.ToInt32(table.Rows.Count.ToString());
            CloseConnection(); 
            if (i == 0) return false;
            else return true;
            
        }
    }
}
