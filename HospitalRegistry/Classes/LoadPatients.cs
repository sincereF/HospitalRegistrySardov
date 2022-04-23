using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace HospitalRegistry.Classes
{
    class LoadPatients
    {
        public class patients
        {
            public string id { get; set; }
            public string surname { get; set; }
            public string name { get; set; }
            public string patronymic { get; set; }
            public string dateOfBirth { get; set; }
            public string gender { get; set; }
            public string policy { get; set; }
            public string region { get; set; }
            public string complaints { get; set; }
            public string time { get; set; }
        }

        public void loadPatients(HospitalRegistryWindow Hwin)
        {
            Hwin.patientsListView.Items.Clear();
            Classes.Connection connection = new Classes.Connection();
            DataTable dt_Tonus = connection.Select("SELECT * FROM [dbo].[Table_patients]"); // данные из БД
            for (int i = 0; i < dt_Tonus.Rows.Count; i++) // перебираем данные
            {
                patients dataPatients = new patients() // создаём экземпляр класса
                {
                    id = dt_Tonus.Rows[i][0].ToString(),
                    surname = dt_Tonus.Rows[i][1].ToString(),
                    name = dt_Tonus.Rows[i][2].ToString(),
                    patronymic = dt_Tonus.Rows[i][3].ToString(),
                    dateOfBirth = dt_Tonus.Rows[i][4].ToString(),
                    gender = dt_Tonus.Rows[i][5].ToString(),
                    policy = dt_Tonus.Rows[i][6].ToString(),
                    region = dt_Tonus.Rows[i][7].ToString(),
                    complaints = dt_Tonus.Rows[i][8].ToString(),
                    time = dt_Tonus.Rows[i][9].ToString(),
                };
                Hwin.patientsListView.Items.Add(dataPatients); // выводим строку в список
            }
        }
    }
}
