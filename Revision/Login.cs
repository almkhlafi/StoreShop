using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Revision
{
    public partial class Login : Form
    {
        string Path = "Data Source=ABDULRAHMAN\\SQLEXPRESS;Initial Catalog=SaleManagementSystem;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }
        static public int userID=0;
        public static int roleID=0;
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Confirm_Click(object sender, EventArgs e)
        {

            void showMainProduct(int roleIDcheck, int userID)
            {
                MainForm mainForm = new MainForm();
                mainForm.ISvalid = roleIDcheck;
                mainForm.UserIDForProducts = userID;
                mainForm.Show();
                this.Hide();
            }
            int roleID = ValidateUser(Username.Text, Pwd.Text);
            if (roleID == 1) { 
                showMainProduct(roleID, userID);
                
            }
            else if (roleID == 2) { 
                
                showMainProduct(roleID, userID); 
            
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ValidateUser(string userName, string password)
        {
           

            try
            {
                SqlConnection con = new SqlConnection(Path);
                
                    con.Open();

                       SqlCommand  cmd = new SqlCommand("Pr_CheckUsernameAndPassword", con);
                    
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        SqlParameter roleIDParameter = new SqlParameter("@RoleID", SqlDbType.Int);
                        roleIDParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(roleIDParameter);

                        SqlParameter userIDParameter = new SqlParameter("@UserID", SqlDbType.Int);
                        userIDParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(userIDParameter);

                        cmd.ExecuteNonQuery();

                         roleID = Convert.ToInt32(roleIDParameter.Value);
                         userID = Convert.ToInt32(userIDParameter.Value);

                // Use the retrieved roleID and userID as needed
                
            }
                
            
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the database operation
                MessageBox.Show("Error validating user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return roleID;
        }

        private void register_Click(object sender, EventArgs e)
        {
            NewUser newuser=    new NewUser();
            newuser.Show();
            this.Hide();
        }
    }
}
