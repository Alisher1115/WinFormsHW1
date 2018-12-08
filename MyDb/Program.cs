using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDb
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //            Создать базу данных MyDB.
            //Создать простейшее приложение WinForms, позволяющее пользователю
            //подключаться к базе данных MyDB, используя аутентификацию SQL
            //Server.Для построения строки подключения использовать
            //SqlConnectionStringBuilder.
            string commandText;
            SqlConnection connection = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            commandText = "CREATE DATABASE MyDB";

            SqlCommand command = new SqlCommand(commandText, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("DataBase 'MyDB' is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
