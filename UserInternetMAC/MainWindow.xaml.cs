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
using System.Net.NetworkInformation;

namespace UserInternetMAC
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        string sName;

        private void InterName_Click(object sender, RoutedEventArgs e)
        {
            Names.Items.Clear();
            foreach (NetworkInterface adapter in nics)
            {
                sName = adapter.Name.ToString();
                if (sName == "Loopback Pseudo-Interface 1")
                    Names.Items.Remove(sName);
                else
                Names.Items.Add(sName + "\r\n");

            }

        }

        private void Names_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] Search = new string[Names.Items.Count];
            string[] Search_MAC = new string[Names.Items.Count];
            
            int i = 0;
            foreach (NetworkInterface adapter in nics)
            {
                if (Names.SelectedItem != null)
                {
                    sName = adapter.Name.ToString();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    Search[i] += sName+"\r\n";
                    Search_MAC[i] += sMacAddress;
                    if (Names.SelectedItem.ToString() == Search[i])
                        Mac.Content = Search_MAC[i].ToString();
                    i++;
                    if (i == Search.Length)
                        i = 0;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Mac.Content = "";
            Names.SelectedItem = null;
            Names.Items.Clear();

        }
    }

}
