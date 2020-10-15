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
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            try
            {
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                string selectionQuery = "SELECT * FROM equipment";

                SqlCommand command = new SqlCommand(selectionQuery, conn);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("equipment");
                sda.Fill(dt);
                lentGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
