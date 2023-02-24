using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Projects
{
    class DataHandler
    {
        string conn = $"Data Source=DESKTOP-TVQQ8OC;Initial Catalog=StudentInformation;Integrated Security=True";

        public DataTable Display()
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter adapter = new SqlDataAdapter("Display", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void AddStudent(string name, string surname, int dateOfbirth, string gender, int phone, string address, string module)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("AddStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName" , name);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    //cmd.Parameters.AddWithValue("@StudentImage", image);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfbirth);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ModuleCodes", module);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Added");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateStudent(string name, string surname, int dateOfbirth, string gender, int phone, string address, string module)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("AddStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", name);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    //cmd.Parameters.AddWithValue("@StudentImage", image);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfbirth);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ModuleCodes", module);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Updated");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("DeleteStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Deleted");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public DataTable SearchStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SearchStudent", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    return dt;
                }
            }
        }
    }
}
