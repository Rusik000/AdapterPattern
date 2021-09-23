using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp5.Command;
using WpfApp5.Models;

namespace WpfApp5.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        private User _user;


        public User User { get { return _user; } set { _user = value; OnPropertyChanged(); } }

        public MainWindow MainWindow { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public AppViewModel()
        {
            XML_File XML_File = new XML_File();
            JSON_File JSON_File = new JSON_File();


            if (XML_File.User_List == null)
            {
                XML_File.User_List = new ObservableCollection<User>();
            }

            if (JSON_File.User_List == null)
            {
                JSON_File.User_List = new ObservableCollection<User>();
            }

            User = new User
            {
                Name = "Name",
                Surname = "Surname",
                Email = "Email",
            };



            SaveCommand = new RelayCommand((e) =>
            {
                IAdapter adapter;

                if (MainWindow.xmlCheckBx.IsChecked == true)
                {
                    try
                    {
                        if (XML_File.User_List == null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = MainWindow.NameTxtBx.Text,
                                Surname = MainWindow.SurnameTxtBx.Text,
                                Email = MainWindow.EmailTxtBx.Text,
                            });

                            XML_File.User_List.RemoveAt(0);

                            adapter = new XML_Adapter(XML_File);

                            Application_File application = new Application_File(adapter);

                            application.Start();
                        }

                        if (XML_File.User_List != null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = MainWindow.NameTxtBx.Text,
                                Surname = MainWindow.SurnameTxtBx.Text,
                                Email = MainWindow.EmailTxtBx.Text,
                            });

                            adapter = new XML_Adapter(XML_File);

                            Application_File application = new Application_File(adapter);

                            application.Start();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                }


                if (MainWindow.JsonCheckBx.IsChecked == true)
                {
                    try
                    {
                        if (JSON_File.User_List == null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = MainWindow.NameTxtBx.Text,
                                Surname = MainWindow.SurnameTxtBx.Text,
                                Email = MainWindow.EmailTxtBx.Text,
                            });

                            JSON_File.User_List.RemoveAt(0);

                            adapter = new JSON_Adapter(JSON_File);

                            Application_File application = new Application_File(adapter);

                            application.Start();
                        }

                        if (JSON_File.User_List != null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = MainWindow.NameTxtBx.Text,
                                Surname = MainWindow.SurnameTxtBx.Text,
                                Email = MainWindow.EmailTxtBx.Text,
                            });

                            adapter = new JSON_Adapter(JSON_File);

                            Application_File application = new Application_File(adapter);

                            application.Start();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                }

            });




        }
    }
}
