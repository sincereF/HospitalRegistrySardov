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
    class RecordPatients
    {
        public void recordPatients(HospitalRegistryWindow Hwin)
        {
            DataTable dataTable = new DataTable("dataBase");
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-7NIK29D\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=HospitalRegistry;");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "Insert into Table_patients (Фамилия,Имя,Отчество,Дата_рождения,Пол,Номер_полиса,Участок,Жалобы,Время_приема)values(@Фамилия,@Имя,@Отчество,@Дата_рождения,@Пол,@Номер_полиса,@Участок,@Жалобы,@Время_приема)";
            sqlCommand.Parameters.AddWithValue("@Фамилия", Hwin.surnameTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Имя", Hwin.nameTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Отчество", Hwin.patronymicTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Дата_рождения", Hwin.dateOfBirthTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Пол", Hwin.genderTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Номер_полиса", Hwin.policyTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Участок", Hwin.regionTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Жалобы", Hwin.complaintsTextBox.Text);
            sqlCommand.Parameters.AddWithValue("@Время_приема", Hwin.timeTextBox.Text);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
        }
    }
}
