using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace HospitalRegistry.Classes
{
    class Login
    {
        string log;
        int index;
        public void login(MainWindow MW)
        {
            if (MW.loginTextBox.Text.Length > 0)
            {
                if (MW.passwordBox.Password.Length > 0)
                {
                    Classes.Connection connection = new Classes.Connection();
                    DataTable dt_HospitalRegistry = connection.Select("SELECT * FROM [dbo].[Table_users] WHERE [Логин] = '" + MW.loginTextBox.Text + "' AND [Пароль] = '" + MW.passwordBox.Password + "'");
                    if (dt_HospitalRegistry.Rows.Count > 0)
                    {
                        dt_HospitalRegistry = connection.Select("SELECT * FROM [dbo].[Table_users]"); // данные из БД
                        for (int i = 0; i < dt_HospitalRegistry.Rows.Count; i++) // перебираем данные
                        {
                           log = dt_HospitalRegistry.Rows[i][0].ToString();
                           if (log == MW.loginTextBox.Text.ToString())
                           {
                                index = i;
                           }
                        }
                        HospitalRegistryWindow Hwin = new HospitalRegistryWindow();
                        Hwin.Owner = MW;
                        Hwin.userLabel.Content = dt_HospitalRegistry.Rows[index][2].ToString() + " " + dt_HospitalRegistry.Rows[index][3].ToString() + " " + dt_HospitalRegistry.Rows[index][4].ToString();
                        Hwin.Show();
                        MW.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
        }
    }
}
