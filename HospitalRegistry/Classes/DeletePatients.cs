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
    class DeletePatients
    {
        public void deletePatients(HospitalRegistryWindow Hwin)
        {
            dynamic itemSelectList = Hwin.patientsListView.SelectedItem;
            var id = itemSelectList.id;
            DataTable dataTable = new DataTable("dataBase");
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-7NIK29D\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=HospitalRegistry;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = "DELETE FROM Table_patients WHERE [ID] = @id";
            sqlCommand.Parameters.AddWithValue("@id", id); // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable); ;
            Hwin.patientsListView.Items.Clear();
            Classes.LoadPatients loadPatients = new Classes.LoadPatients();
            loadPatients.loadPatients(Hwin);
        }
    }
}
