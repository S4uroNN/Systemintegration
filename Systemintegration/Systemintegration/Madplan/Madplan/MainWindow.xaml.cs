using BusinessLogicCore.BLL;
using DTOCore.Model;
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

namespace Madplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
           
        }

        RetBLL bll = new RetBLL();
        Ret ret;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ret = bll.GetRet(Int32.Parse(Search.Text));
            Ret_navn.Content = ret.Navn;
        }
    }
}
