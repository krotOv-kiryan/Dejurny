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

namespace Dejurny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model;
        
        public MainWindow()
        {
            InitializeComponent();
            var vm = new StudentListVM();
            model = new Model();
            vm.SetModel(model);
            DataContext = vm;
            //DataContext = vm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /*public void DejurLog()
        {

        }*/

        /*   public SetModel(IPage vm)
          {
              DataContext = vm; */

    }

}



