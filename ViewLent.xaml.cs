/*
 * Name: Ashok Sasitharan
 * Student Number: 100745484
 * Date: October 14 2020
 */
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
    /// Interaction logic for ViewLent.xaml
    /// </summary>
    public partial class ViewLent : UserControl
    {
        public ViewLent()
        {
            InitializeComponent();
            FillDataGrid(); //call the FillDataGrid function
        }
        private void FillDataGrid()
        {
            try
            {
                //connect to the database
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                //creata a query statement
                string selectionQuery = "SELECT * FROM equipment";
                //create a new command
                SqlCommand command = new SqlCommand(selectionQuery, conn);
                //use a data adapter
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //link the datatable with the equipment table
                DataTable dt = new DataTable("equipment");
                sda.Fill(dt);
                //display the data from the table
                lentGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
