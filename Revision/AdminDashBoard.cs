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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Revision
{

        public partial class AdminDashBoard : Form
        {
        public static Main main;
        string Path = "Data Source=ABDULRAHMAN\\SQLEXPRESS;Initial Catalog=SaleManagementSystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd; // as below It can be 
        DataTable dt;
        DataTable users;
        DataTable provider;
        DataTable productss;//Or I can Use  DataTable dt=new DataTable();
        SqlDataAdapter adpt;
            string phoneN;
            string address;
            string name;
            int user=0;
            static public int table = 0;
            public AdminDashBoard()
            {
                InitializeComponent();
                con = new SqlConnection(Path);

                DELETE.Enabled = false;
                UPDATE.Enabled = false;
                ADD.Enabled = true;

            }


        

            private void AdminDashBoard_Load(object sender, EventArgs e)
            {
                providerInformation(); retrieveUsers();
        }
        
        
        public void providerInformation()
            {
                DELETE.Enabled = false;
                UPDATE.Enabled = false;
                ADD.Enabled = true;
                Search.Text = "Search .........";
                StartPosition = FormStartPosition.CenterScreen;
               provider = new DataTable();
            provider.Columns.Add("Full Name");
            provider.Columns.Add("Phone Number");
            provider.Columns.Add("Address");
                retrieveDatabase();
             users = new DataTable();
            users.Columns.Add("ID");
            users.Columns.Add("Role");
            users.Columns.Add("First Name");
            users.Columns.Add("Last Name");
            dt.Columns.Add("Password");
             productss = new DataTable();
            productss.Columns.Add("CustomerID");
            productss.Columns.Add("Amount");
            productss.Columns.Add("price");
            productss.Columns.Add("Total");
            

        }
     
        void retrieveDatabase()
            {
                /*
                 * SqlDataAdapter()
                   @It acts as a bridge between the data source (SQL Server database) and the DataSet or DataTable objects in your application
                 1)Filling a DataTable or DataSet with data from the database using the Fill() method.
                 2)Updating changes made to a DataTable or DataSet back to the database using the Update method.
                3)Executing SQL commands or stored procedures using the ExecuteNonQuery method.
                4)Retrieving a single value from the database using the ExecuteScalar method.

                *DataSource
                Binding: By setting the DataSource property, you establish a binding between the control and the data source. The control will fetch the data from the source and display it 
    */
                try
                {

                    con.Open();
                    adpt = new SqlDataAdapter("SELECT *  FROM Providers", con);
                    provider = new DataTable();
                    adpt.Fill(provider);
                    datagradInform.DataSource = provider;
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Data Is not Showen in Providers!!! Check connection to the server!!!");
                }

            }
        void retrieveUsers()
        {
            try
            {

                con.Open();
                adpt = new SqlDataAdapter("Pr_GetUserData", con);
                users = new DataTable();
                adpt.Fill(users);
                dataGridViewUSERS.DataSource = users;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Data Is not Showen in users !!! Check connection to the server!!!");
            }
        }

          void prodcutDetails(int yourUserID)
        {
            using (SqlConnection connection = new SqlConnection(Path))
            {
                con.Open();

                SqlCommand command = new SqlCommand("Pr_CalculateTotalAmountAndSum", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Provide the UserID parameter value
                command.Parameters.AddWithValue("@UserID", yourUserID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                 productss = new DataTable();
                adapter.Fill(productss);
                dataGridViewProducts.DataSource = productss;

                con.Close();
            }



        }



        public void clear()
            {
                PoviderName.Text = string.Empty;
                phoneNumber.Text = string.Empty;
                Addresss.Text = string.Empty;
                Search.Text = string.Empty;

            }
        private void AdminDashBoard_MouseClick(object sender, MouseEventArgs e)
        {
            DELETE.Enabled = false;
            UPDATE.Enabled = false;
            ADD.Enabled = true;
            clear();
        }

         void datagradInform_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
        }

        private void datagradInform_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            table = 1;
            try
            {

                clear();
                DELETE.Enabled = true;
                UPDATE.Enabled = true;
                ADD.Enabled = false;
                prodcutDetails(Convert.ToInt32(datagradInform.Rows[e.RowIndex].Cells[0].Value));
                ProviderID.Text = datagradInform.Rows[e.RowIndex].Cells[0].Value.ToString();
                PoviderName.Text = datagradInform.Rows[e.RowIndex].Cells[1].Value.ToString();
                //Email.Text = datagradInform.Rows[e.RowIndex].Cells[2].Value.ToString();
                phoneNumber.Text = datagradInform.Rows[e.RowIndex].Cells[2].Value.ToString();
                Addresss.Text = datagradInform.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show("AN ERROR !!"); }
           
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                table = 2;
                clear();
                DELETE.Enabled = true;
                UPDATE.Enabled = true;
                ADD.Enabled = false;

                prodcutDetails(Convert.ToInt32(datagradInform.Rows[e.RowIndex].Cells[0].Value));
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewUSERS.Rows.Count)
                {
                    // Access the cell values
                    UserID.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[0].Value.ToString();

                }
                UFname.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[2].Value.ToString();
                ULname.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[3].Value.ToString();
                Username.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[4].Value.ToString();
                Upwd.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[5].Value.ToString();
                Uphone.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[7].Value.ToString();
                Uaddress.Text = dataGridViewUSERS.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show("AN ERROR !!"); }
             
        }

   
      
        void updateUser()
        {
            try
            {
                if (table == 1)
                {
                    //More Secure cinnection to SQL Server
                    cmd = new SqlCommand("Pr_UpdateProvider", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProviderID", int.Parse(ProviderID.Text));
                    cmd.Parameters.AddWithValue("@Fname", PoviderName.Text);
                    cmd.Parameters.AddWithValue("@phoneN", phoneNumber.Text);
                    cmd.Parameters.AddWithValue("@address", Addresss.Text);
                    con.Open();
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("Check your values");
                    else MessageBox.Show("Updated");
                    con.Close();

                    retrieveDatabase();
                    clear();
                }
                else if (table == 2)
                {
                    // More Secure connection to SQL Server
                    cmd = new SqlCommand("Pr_UpdateUserDataByRoleID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", int.Parse(UserID.Text)); // Provide the correct value for RoleID
                    cmd.Parameters.AddWithValue("@Fname", UFname.Text); // Assuming UFname is a TextBox control
                    cmd.Parameters.AddWithValue("@Lname", ULname.Text); // Assuming ULname is a TextBox control
                    cmd.Parameters.AddWithValue("@Passwords", Upwd.Text); // Assuming Upwd is a TextBox control
                    cmd.Parameters.AddWithValue("@PhoneNumber", Uphone.Text); // Assuming Uphone is a TextBox control
                    cmd.Parameters.AddWithValue("@Users_Address", Uaddress.Text); // Assuming Uaddress is a TextBox control

                    con.Open();
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("Check your values");
                    else
                        MessageBox.Show("Updated");
                    con.Close();

                    retrieveUsers();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating user data: " + ex.Message);
            }
        }
        void deleteUser()
        {
            try
            {
                if (table == 1) { 

                con.Open();

                SqlCommand cmd = new SqlCommand("Pr_DeleteProvider", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProviderID", int.Parse(ProviderID.Text));
                if (cmd.ExecuteNonQuery() == 0) MessageBox.Show("OOPS !!"); else MessageBox.Show("DELETED");
                con.Close();
                retrieveDatabase();
                clear();
                }else if(table == 2)
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Pr_DeleteUserByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", int.Parse(UserID.Text));
                    if (cmd.ExecuteNonQuery() == 0) MessageBox.Show("OOPS !!"); else MessageBox.Show("DELETED");
                    con.Close();
                    retrieveUsers();

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void addUser()
        {
            
            name = PoviderName.Text;
            phoneN = phoneNumber.Text;
            address = Addresss.Text;
            DataRow dr = dt.NewRow();
            if (string.IsNullOrEmpty(PoviderName.Text) || string.IsNullOrEmpty(phoneNumber.Text) ||
            string.IsNullOrEmpty(Addresss.Text))
            {
                MessageBox.Show("Fill the Empty Fields please !!");
            }
            else
            {
                try
                {
                    //Insert the values to the databse 
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("Pr_InsertNewProvider", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FullName", name);
                            cmd.Parameters.AddWithValue("@Phone_Number", phoneN);
                            cmd.Parameters.AddWithValue("@Providers_Address", address);

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        MessageBox.Show("Your data has been saved successfully!");
                        clear();
                    retrieveDatabase();
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Not Added !! \n" + e.Message);
                    }
                }

            
        }

        private void UPDATE_Click_1(object sender, EventArgs e)
        {
            if (table == 1)
                updateUser();
            else updateUser();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (table == 1)
                deleteUser();
            else deleteUser();
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            if (table == 1)
                addUser();
            else if (table == 2)
            {
                NewUser newUser = new NewUser();
                newUser.Show();
                retrieveUsers();

            }
            retrieveUsers();

        }

        private void loadproduct_Click(object sender, EventArgs e)
        {
            MainForm Mf = new MainForm();
            Mf.Show();
            this.Hide();
        }

        private void btAddProduct_Click(object sender, EventArgs e)
        {

            ADDPRODUCTFORM form2 = new ADDPRODUCTFORM();
            form2.Show();
            this.Hide();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                adpt = new SqlDataAdapter("Select * from Providers where FullName like '%" + Search.Text + "%'", con);
                dt = new DataTable();

                adpt.Fill(dt);
                datagradInform.DataSource = dt;
                adpt = new SqlDataAdapter("Select * from Users where UserName like '%" + Search.Text + "%'", con);
                dt = new DataTable();
                adpt.Fill(dt);
                dataGridViewUSERS.DataSource = dt;
           
             
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
    }


