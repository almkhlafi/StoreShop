using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revision
{
    public partial class payment : Form
    {   public decimal getAmount {  set; get; }
         public int UserId{ set; get; }

        string Path = "Data Source=ABDULRAHMAN\\SQLEXPRESS;Initial Catalog=SaleManagementSystem;Integrated Security=True";
        // string Path = "server=localhost;uid=root;pwd=root;database=storandsalesmanagementsystem";
        SqlConnection con;
        SqlCommand cmd;
      
       public payment()
        {
            InitializeComponent();

        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            
            bool pamentstate = false;
            if(Pay.Checked)
            {
                pamentstate=true;
            }
          //  CalculateAndInsertPayment(UserId);



        }
   /*     private void CalculateAndInsertPayment(int userID)
        {
            using (SqlConnection connection = new SqlConnection(Path))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("CalculateAndInsertPayment", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the UserID parameter
                    command.Parameters.AddWithValue("@UserID", userID);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    MessageBox.Show("Payment calculated and inserted successfully.");
                }
                catch (Exception ex)
                {
                    // Handle the exception appropriately (e.g., display an error message)
                }
                finally
                {
                    connection.Close();
                }
            }
        }
*/
    }
}
