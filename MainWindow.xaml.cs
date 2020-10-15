using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ASasitharan_NETD3200_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Control controlAddRecord = new AddData();
            MainContentPanel.Children.Add(controlAddRecord);
        }

 

        private void ControlList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = e.Source as ListView;
            if(listView !=null)
            {
                MainContentPanel.Children.Clear();
                
                if(listView.SelectedItem.Equals(lsviLendOut))
                {
                    Control controlAddRecord = new AddData();
                    this.MainContentPanel.Children.Add(controlAddRecord);
                }
                if(listView.SelectedItem.Equals(lsviViewLentOut))
                {
                    Control controlViewLent = new ViewLent();
                    this.MainContentPanel.Children.Add(controlViewLent);
                }
               
            }
        }
    }
}
