using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace ASasitharan_NETD3200_Lab2
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
           
        }
        private void SearchDataGrid()
        {
            try
            {
                //connect to the database
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                //creata a query statement
                string selectionQuery = "SELECT * FROM equipment WHERE empID = " + txtEmpId.Text;
                //create a new command
                SqlCommand command = new SqlCommand(selectionQuery, conn);
                //use a data adapter
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //link the datatable with the equipment table
                DataTable dt = new DataTable("equipment");
                sda.Fill(dt);
                //display the data from the table
                searchGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int empID;
            //run if employee id is not empty
            if (txtEmpId.Text != string.Empty)
            {
                //run if employee id is a number
                if (int.TryParse(txtEmpId.Text, out empID))
                {
                    SearchDataGrid();
                }
                else
                {
                    MessageBox.Show("ID must be numeric.");
                    txtEmpId.Text = "";
                    txtEmpId.Focus();

                }
            }
            else
            {
                MessageBox.Show("ID cannot be empty.");
                txtEmpId.Text = "";
                txtEmpId.Focus();

            }
          
            
        }
    }
}
