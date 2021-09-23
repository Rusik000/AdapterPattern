using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using WpfApp5.Models;

namespace WpfApp5.ViewModels
{

    interface IAdapter
    {
        void Write();
    }

    class JSON_Adapter : IAdapter
    {
        JSON_File _JSON_File;

        public JSON_Adapter(JSON_File JSON_File)
        {
            _JSON_File = JSON_File;
        }
        public void Write()
        {
            _JSON_File.JSON_Serialize();
        }
    }


    class XML_Adapter : IAdapter
    {
        XML_File _XML_File;


        public XML_Adapter(XML_File XML_File)
        {
            _XML_File = XML_File;
        }
        public void Write()
        {
            _XML_File.XML_Serialize();
        }
    }



    class JSON_File : BaseViewModel
    {

        private ObservableCollection<User> _user_List;
        public ObservableCollection<User> User_List
        {
            get { return _user_List; }
            set { _user_List = value; OnPropertyChanged(); }
        }


        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

        public MainWindow MainWindows { get; set; }

        public AppViewModel AppViewModel { get; set; }

        public JSON_File()
        {

        }

        public void JSON_Serialize()
        {

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($@"UserData.json", true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, User_List);
                }
            }

        }



    }



    class XML_File : BaseViewModel
    {

        private ObservableCollection<User> _user_List;
        public ObservableCollection<User> User_List 
        { 
            get { return _user_List; } 
            set { _user_List = value; OnPropertyChanged(); }
        }


        private User _user;

        public User User 
        { 
            get { return _user; } 
            set { _user = value; OnPropertyChanged(); } 
        }


        public MainWindow MainWindows { get; set; }

        public AppViewModel appViewModel { get; set; }

        public XML_File()
        {

        }



        public void XML_Serialize()
        {

            var xml = new XmlSerializer(typeof(ObservableCollection<User>));
            using (var fs = new FileStream($@"UserData.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, User_List);
            }
        }


    }




    class Converter
    {
        private readonly IAdapter _adapter;

        public Converter(IAdapter adapter)
        {
            _adapter = adapter;
        }

        public void WriteFile()
        {
            _adapter.Write();
        }

    }


    class Application_File
    {
        private readonly Converter _converter;

        public Application_File(IAdapter adapter)
        {
            _converter = new Converter(adapter);
        }

        public void Start()
        {
            _converter.WriteFile();
        }

    }


}
