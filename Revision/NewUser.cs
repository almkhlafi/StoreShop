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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Revision
{
    public partial class NewUser : Form
    {

        string Path = "Data Source=ABDULRAHMAN\\SQLEXPRESS;Initial Catalog=SaleManagementSystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd; // as below It can be 
        DataTable dt; //Or I can Use  DataTable dt=new DataTable();
        SqlDataAdapter adpt;
        int roleID;
        public NewUser()
        {
            InitializeComponent();
        }
        private void Comfirm_Click(object sender, EventArgs e)
        {
            string password = pwd.Text;
            string confirmPassword = Cpwd.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match. Please re-enter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string genderr = "";

                if (Male.Checked)
                {
                    genderr = "Male";
                    Famale.Checked = false;
                }
                else if (Famale.Checked)
                {
                    genderr = "Female";
                    Male.Checked = false;
                }

                string roleName = "";
                if (Admin.Checked)
                    roleName = "Admin";
                else if (Employee.Checked)
                    roleName = "Employee";
                else if (Customer.Checked)
                    roleName = "Customer";

                using (SqlConnection con = new SqlConnection(Path))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Pr_GetRoleID", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Role_Name", roleName);

                    SqlParameter outputParameter = new SqlParameter("@Role_ID", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    cmd.ExecuteNonQuery();

                    int roleID = Convert.ToInt32(outputParameter.Value);

                    SqlCommand command = new SqlCommand("Pr_InsertNewUser", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Fname", Fname.Text);
                    command.Parameters.AddWithValue("@Lname", Lname.Text);
                    command.Parameters.AddWithValue("@UserName", UserName.Text);
                    command.Parameters.AddWithValue("@Passwords", pwd.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneN.Text);
                    command.Parameters.AddWithValue("@Users_Address", Address.Text);
                    command.Parameters.AddWithValue("@Gender", genderr);
                    command.Parameters.AddWithValue("@Role_ID", roleID);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 50000)
                        {
                            string errorMessage = ex.Message;
                            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw; // Handle other SQL exceptions or rethrow the exception
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Not Added !! \n" + ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear()
        {
            Fname.Text = "";
            Lname.Text = "";
            Email.Text = "";
            UserName.Text = "";
            pwd.Text = "";
            Cpwd.Text = "";
            Address.Text = "";
            PhoneN.Text = "";
            Famale.Checked = false;
            Male.Checked = false;
            Admin.Checked = false;
            Employee.Checked = false;
            Customer.Checked = false;

            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
       
           
}




