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

     
        //adds the enetered data to the table if valid
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int employeeID;
            try
            {
                //run if txtName is not empty
                if(txtName.Text!=string.Empty)
                {
                    //run if employee id is not empty
                    if (txtEmployeeID.Text != string.Empty)
                    {
                        //run if employee id is a number
                        if (int.TryParse(txtEmployeeID.Text, out employeeID))
                        {
                            //run if decription is not empty
                            if (txtDescEquipment.Text != string.Empty)
                            {
                                //run if phone number is not empty
                                if (txtPhoneNum.Text != string.Empty)
                                {
                                    //connect to the database
                                    string connectString = Properties.Settings.Default.connect_string;
                                    SqlConnection conn = new SqlConnection(connectString);
                                    conn.Open();
                                    //create the insert statement
                                    string insertQuery = "INSERT INTO equipment (name, empID, description, phone) VALUES('" + txtName.Text + "', '" + employeeID + "', '" + txtDescEquipment.Text + "', '" + txtPhoneNum.Text + "')";
                                    //create a new command
                                    SqlCommand command = new SqlCommand(insertQuery, conn);
                                    //execute the query
                                    command.ExecuteNonQuery();
                                    //end the connection
                                    conn.Close();
                                    MessageBox.Show("Added a record");
                                    //clears all of the textboxes and set the focus on Name
                                    txtName.Text = "";
                                    txtPhoneNum.Text = "";
                                    txtEmployeeID.Text = "";
                                    txtDescEquipment.Text = "";
                                    txtName.Focus();
                                }
                                //all of the error messages are below
                                else
                                {
                                    MessageBox.Show("Phone Number cannot be empty.");
                                    txtPhoneNum.Text = "";
                                    txtPhoneNum.Focus();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Description cannot be empty.");
                                txtDescEquipment.Text = "";
                                txtDescEquipment.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee ID must be numeric.");
                            txtEmployeeID.Text = "";
                            txtEmployeeID.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee ID cannot be empty.");
                        txtEmployeeID.Text = "";
                        txtEmployeeID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Name cannot be empty.");
                    txtName.Text = "";
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
