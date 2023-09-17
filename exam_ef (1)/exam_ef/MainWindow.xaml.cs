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

namespace exam_ef
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //НЕ ПІДТЯГУЄТЬСЯ БАЗА ДАНИХ!(нажаль)
        public string Password { get; set; }
        public string Name { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Password= "123";
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_LoginPassword.Text == Password &&
                TextBox_LoginName.Text == "admin")
            {
                Name = "admin";
                MessageBox.Show("Hello ADMIN!");

               
                var w1 = new Window1();
                w1.Show();
                this.Close();

            }
            else if (TextBox_LoginPassword.Text == Password &&
                TextBox_LoginName.Text == "user")
            {
                Name = "user";
                MessageBox.Show("Hello USER!");

                var w2 = new Window2();
                w2.Show();
                this.Close();

            }
            else
            {
                TextBox_LoginName.Clear();
                TextBox_LoginPassword.Clear();
                MessageBox.Show("Incorrect password or login!");
            }
        }
    }
}
