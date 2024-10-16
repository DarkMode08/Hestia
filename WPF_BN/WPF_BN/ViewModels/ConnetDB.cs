using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_BN.ViewModels
{
    class ConnetDB
    {
        private string connectionString
            = "Data Source = ATENEA; Initial Catalog = Hermes;" +
              "Integrated Security=True";

        // Cambiamos a public para permitir acceso desde otras clases
        public bool ValidarLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM Employees WHERE _Email = @Email AND _Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al intentar conectar a la base de datos: {ex.Message}");
                    return false;
                }
            }
        }
    }
}