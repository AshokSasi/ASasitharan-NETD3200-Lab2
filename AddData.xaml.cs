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
using System.Xml.Serialization;
using System.Data.SqlClient;
namespace ASasitharan_NETD3200_Lab2
{
    /// <summary>
    /// Interaction logic for AddData.xaml
    /// </summary>
    public partial class AddData : UserControl
    {
        public AddData()
        {
            InitializeComponent();
        }
      

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = int.Parse(txtEmployeeID.Text);
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                string insertQuery = "INSERT INTO equipment (name, empID, description, phone) VALUES('" + txtName.Text + "', '" + ID + "', '" + txtDescEquipment.Text + "', '" + txtPhoneNum.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Added a record");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
