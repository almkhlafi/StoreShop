using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;


using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Revision
{
    public partial class MainForm : Form
    {
      
string Path = "Data Source=ABDULRAHMAN\\SQLEXPRESS;Initial Catalog=SaleManagementSystem;Integrated Security=True";
       // string Path = "server=localhost;uid=root;pwd=root;database=storandsalesmanagementsystem";
        SqlConnection con;
        SqlCommand cmd;
        List<Product_control> products;
        List<ListProducts> productlist;
        int count = 0;
        public int ISvalid { get; set; }
        public int UserIDForProducts { get; set; }

        //  MySqlDataAdapter adpt;
        // MySqlConnection con;
        // MySqlCommand cmd;
        public MainForm()
        {
            InitializeComponent();
            con = new SqlConnection(Path);
            SubscribeToProductClickedEvents();
        }

        private void SubscribeToProductClickedEvents()
        {
            foreach (Product_control productControl in flowLayoutPanel1.Controls.OfType<Product_control>())
            {
                productControl.ProductClicked += ProductControl_ProductClicked;
            }
        }
        private void ProductControl_ProductClicked(object sender, ProductClickedEventArgs e)
        {
            string description = e.Description;

            // Find the corresponding Product_control in flowLayoutPanel1
            Product_control product = flowLayoutPanel1.Controls
                .OfType<Product_control>()
                .FirstOrDefault(p => p.description == description);

            if (product != null)
            {
                ListProducts existingProduct = flowLayoutPanel2.Controls
                    .OfType<ListProducts>()
                    .FirstOrDefault(p => p.description == product.description);

                if (existingProduct != null)
                {
                    // Existing product found, update the quantity and price
                    if (int.TryParse(existingProduct.amount, out int existingAmount) &&
                        decimal.TryParse(existingProduct.price, out decimal existingPrice) &&
                        int.TryParse(product.amount, out int newAmount) &&
                        decimal.TryParse(product.price, out decimal newPrice))
                    {
                        int updatedAmount = existingAmount + newAmount;
                        decimal updatedPrice = existingPrice + (newPrice * newAmount);

                        existingProduct.amount = updatedAmount.ToString();
                        existingProduct.price = updatedPrice.ToString();
                    }
                    else
                    {
                        // Invalid amount or price for the product.
                        // Display an error message or handle the situation accordingly.
                    }
                }
                else
                {
                    // Create a new ListProducts control and add it to the FlowLayoutPanel
                    ListProducts newProduct = new ListProducts()
                    {
                        productimage = product.productimage,
                        amount = product.amount,
                        description = product.description
                    };

                    if (decimal.TryParse(product.price, out decimal productPrice) &&
                        int.TryParse(product.amount, out int productAmount))
                    {
                        newProduct.price = (productPrice * productAmount).ToString();
                        flowLayoutPanel2.Controls.Add(newProduct);
                    }
                }

                CalculateTotalPrice(); // Update the total price
            }
        }

        private void WriteProductDetailsToDatabase()
        {
         

                if (UserIDForProducts == 0)
                {
                    Login login=new Login();
                    login.Show();
                    this.Hide();
                }
                else { 
                try
                {
                    con.Open();

                    foreach (ListProducts product in flowLayoutPanel2.Controls.OfType<ListProducts>())
                    {
                        int productID=0;
                        decimal productPrice=0;
                        int amount=0;
                            int i = 0;

                        if (int.TryParse(product.productID, out productID) && decimal.TryParse(product.price, out productPrice) && int.TryParse(product.amount, out amount))
                        {
                            SqlConnection con = new SqlConnection(Path);
                            using (SqlCommand command = new SqlCommand("Pr_InsertOrder", con))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@ProductID", productID);
                                command.Parameters.AddWithValue("@ProductPrice", productPrice);
                                command.Parameters.AddWithValue("@Amount", amount);
                                command.Parameters.AddWithValue("@UserID", UserIDForProducts); //the actual UserID 
                                command.ExecuteNonQuery();
                                   
                                    
                                }
                        }
                            


                        }
                    MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                    // Handle the exception appropriately (e.g., display an error message)
                }
                finally
                {
                    con.Close();
                }
                
            }
        }


    
        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (ListProducts product in flowLayoutPanel2.Controls.OfType<ListProducts>())
            {
                decimal productPrice;

                if (decimal.TryParse(product.price.ToString(), out productPrice))
                {
                    totalPrice += productPrice;
                }
            }

            // Update the total price display
            Total.Text = $"Total Price: {totalPrice.ToString("0.00")}";
        }


        private Image GetImageFromByteArray(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(memoryStream);
                return new Bitmap(image);
                // Create a new Bitmap to ensure the original image is not locked in memory
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ISvalid==1) AdminSide.Visible = true;
             else if(ISvalid ==2) EmployeeSide.Visible = true;

            if (count == 0)
            {
                LoadProduct("Pr_GetAllProducts", ProductControl_ProductClicked);


                // ListProduct("Pr_GetAllProducts");
            }
            else MessageBox.Show("All Data was loaded");
        }
        private void Addproduct_Click(object sender, EventArgs e)
        {
            ADDPRODUCTFORM form2 = new ADDPRODUCTFORM();
            form2.Show();
            this.Dispose();
        }
        //--------------------Search----------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchList.Text.Trim();

            try
            {
                using (SqlConnection con = new SqlConnection(Path))
                {
                    con.Open();

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Product_Pic, Price, Product_Description, Quantity FROM ProductInventory WHERE Product_Description LIKE '%' + @SearchText + '%'", con);
                        cmd.Parameters.AddWithValue("@SearchText", searchText);

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<ListProducts> filteredProducts = new List<ListProducts>();

                        while (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["Product_Pic"];
                            Image image = GetImageFromByteArray(imageData);
                            string price = reader["Price"].ToString();
                            int amount = (int)reader["Quantity"];
                            string description = reader["Product_Description"].ToString();

                            ListProducts product = new ListProducts()
                            {
                                productimage = image,
                                price = price.ToString(),
                                description = description
                            };

                            filteredProducts.Add(product);
                        }

                        reader.Close();

                        // Clear previous products from the flowLayoutPanel2
                        flowLayoutPanel2.Controls.Clear();

                        foreach (ListProducts product in filteredProducts)
                        {
                            flowLayoutPanel2.Controls.Add(product);
                        }
                    }
                    else
                    {
                        // If the search text is empty, display all products
                        ClearProducts(flowLayoutPanel2);
                       // ListProduct("Pr_GetAllProducts");
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = SearchMain.Text.Trim();

            try
            {
                using (SqlConnection con = new SqlConnection(Path))
                {
                    con.Open();

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Product_Pic, Price, Product_Description, Quantity FROM ProductInventory WHERE Product_Description LIKE '%' + @SearchText + '%'", con);
                        cmd.Parameters.AddWithValue("@SearchText", searchText);

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<Product_control> filteredProducts = new List<Product_control>();

                        while (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["Product_Pic"];
                            Image image = GetImageFromByteArray(imageData);
                            string price = reader["Price"].ToString();
                            int amount = (int)reader["Quantity"];
                            string description = reader["Product_Description"].ToString();

                            Product_control product = new Product_control()
                            {
                                productimage = image,
                                price = price.ToString(),
                                amount = amount.ToString(),
                                description = description
                            };

                            filteredProducts.Add(product);
                        }

                        reader.Close();

                        // Clear previous products from the flowLayoutPanel1
                        flowLayoutPanel1.Controls.Clear();

                        foreach (Product_control product in filteredProducts)
                        {
                            flowLayoutPanel1.Controls.Add(product);
                        }
                    }
                    else
                    {
                        // If the search text is empty, display all products
                        ClearProducts(flowLayoutPanel1);


                        LoadProduct("Pr_GetAllProducts", ProductControl_ProductClicked);


                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //--------------------Clear Code----------------------
        private void ClearProducts(Control container)
        {
            // Clear all child controls from the container
            foreach (Control control in container.Controls)
            {
                control.Dispose();
            }

            container.Controls.Clear();
        }

        //--------------------CalculateTotalPrice----------------------

      
        //--------------------List Categories Products----------------------




    public void ListProduct(string passProcedure, Action<Product_control> productClickHandler)
{
    products = new List<Product_control>();

    using (SqlConnection con = new SqlConnection(Path))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(passProcedure, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
                    byte[] imageData = (byte[])reader["Product_Pic"];
                    Image image = GetImageFromByteArray(imageData);
                    string price = reader["Price"].ToString();
                    int amount = (int)reader["Quantity"];
                    string description = reader["Product_Description"].ToString();

                    Product_control product = new Product_control()
            {
                productimage = image,
                price = price.ToString(),
                amount = amount.ToString() ,
                description = description,
            };

            // Add click event handler to the product control
            product.Click += (sender, e) => productClickHandler.Invoke(product);

            products.Add(product);
        }

        con.Close();
    }

    flowLayoutPanel1.Controls.Clear(); // Clear existing controls

            foreach (Product_control product in products)
            {
                flowLayoutPanel1.Controls.Add(product);
            }
}

        //_____________________________LoadBy Category Main And Categories____________________________________________
        public List<Product_control> GetProductsByCategory(string category, EventHandler<ProductClickedEventArgs> productClickedHandler)
        {
            List<Product_control> categoryProducts = new List<Product_control>();

            using (SqlConnection con = new SqlConnection(Path))
            {
                con.Open();

                string viewName = $"{category}View";
                string sqlQuery = $"SELECT [Product_Pic], [Price], [Product_Description], [Quantity],[Product_ID] FROM {viewName}";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    byte[] imageData = (byte[])reader["Product_Pic"];
                    Image image = GetImageFromByteArray(imageData);
                    decimal price = (decimal)reader["Price"];
                    int amount = (int)reader["Quantity"];
                    string description = reader["Product_Description"].ToString();
                    int product_ID = (int)reader["Product_ID"];

                    Product_control product = new Product_control()
                    {
                        productimage = image,
                        price = price.ToString(),
                        amount = amount.ToString(),
                        description = description,
                        productID = product_ID.ToString(),

                    };

                    // Attach the event handler for the ProductClicked event
                    product.ProductClicked += productClickedHandler;
                    categoryProducts.Add(product);
                }

                con.Close();
            }

            flowLayoutPanel1.Controls.Clear();

            foreach (Product_control product in categoryProducts)
            {
                flowLayoutPanel1.Controls.Add(product);
            }

            return categoryProducts;
        }
        
        public void LoadProduct(string passProcedure, EventHandler<ProductClickedEventArgs> productClickedHandler)
        {
            List<Product_control> products = new List<Product_control>();

            using (SqlConnection con = new SqlConnection(Path))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(passProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    byte[] imageData = (byte[])reader["Product_Pic"];
                    Image image = GetImageFromByteArray(imageData);
                    decimal price = (decimal)reader["Price"];
                    int amount = (int)reader["Quantity"];
                    string description = reader["Product_Description"].ToString();
                    string product_ID = reader["Product_ID"].ToString();

                    Product_control product = new Product_control()
                    {
                        productimage = image,
                        price = price.ToString(),
                        amount = amount.ToString(),
                        description = description,
                        productID = product_ID,
                    };

                    // Attach the event handler for the ProductClicked event
                    product.ProductClicked += productClickedHandler;

                    products.Add(product);
                }

                con.Close();
            }

            flowLayoutPanel1.Controls.Clear(); // Clear existing controls

            foreach (Product_control product in products)
            {
                flowLayoutPanel1.Controls.Add(product);
            }
        }
        //_________________________________________________________________________

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            List<Product_control> clothesProducts = GetProductsByCategory("Clothes", ProductControl_ProductClicked);
          

        }

        private void ElectronicsCategory_Click(object sender, EventArgs e)
        {


            List<Product_control> electronicsProducts = GetProductsByCategory("Electronics", ProductControl_ProductClicked);
        }

        private void ShoesCategory_Click(object sender, EventArgs e)
        {
            List<Product_control> shoesProducts = GetProductsByCategory("Shoes", ProductControl_ProductClicked);
        }

        private void CarCategory_Click(object sender, EventArgs e)
        {

            List<Product_control> carsProducts = GetProductsByCategory("Cars", ProductControl_ProductClicked);


        }

        private void allProducts_Click(object sender, EventArgs e)
        {

            ClearProducts(flowLayoutPanel1);
            // Call the LoadProduct function with the click event handler
            LoadProduct("Pr_GetAllProducts", ProductControl_ProductClicked);


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    
       
           
        private void button1_Click(object sender, EventArgs e)
        {
            WriteProductDetailsToDatabase();

           



        }
        void paymentt()
        {

             
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("CalculateAndInsertPayment", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the UserID parameter
                        command.Parameters.AddWithValue("@UserID", UserIDForProducts);

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

            payment py = new payment();

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login logq = new Login();
            logq.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminSide_Click(object sender, EventArgs e)
        {
            AdminDashBoard admin=new AdminDashBoard();  
            admin.Show();
            this.Hide();
        }
        // py.UserId = UserIDForProducts;
    }
    }





