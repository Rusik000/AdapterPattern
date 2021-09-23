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
using WpfApp5.ViewModels;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new AppViewModel() { MainWindow = this };
        }

        private void NameTxtBx_MouseEnter(object sender, MouseEventArgs e)
        {
            if (NameTxtBx.Text == "Name")
            {
                NameTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                NameTxtBx.Foreground = new SolidColorBrush(color1);
            }
        }

        private void NameTxtBx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (NameTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                NameTxtBx.Text = "Name";
                NameTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }

        private void SurnameTxtBx_MouseEnter(object sender, MouseEventArgs e)
        {
            if (SurnameTxtBx.Text == "Surname")
            {
                SurnameTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                SurnameTxtBx.Foreground = new SolidColorBrush(color1);


            }
        }

        private void SurnameTxtBx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (SurnameTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                SurnameTxtBx.Text = "Surname";
                SurnameTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }

        private void EmailTxtBx_MouseEnter(object sender, MouseEventArgs e)
        {
            if (EmailTxtBx.Text == "Email")
            {
                EmailTxtBx.Text = null;



                Color color1 = new Color();
                color1 = Color.FromArgb(255, 37, 191, 191);

                EmailTxtBx.Foreground = new SolidColorBrush(color1);


            }
        }

        private void EmailTxtBx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (EmailTxtBx.Text == "")
            {

                Color color2 = new Color();
                color2 = Color.FromArgb(255, 110, 127, 128);

                EmailTxtBx.Text = "Email";
                EmailTxtBx.Foreground = new SolidColorBrush(color2);
            }
        }
    }
}
