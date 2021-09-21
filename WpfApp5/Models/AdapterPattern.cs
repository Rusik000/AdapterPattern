using Newtonsoft.Json;
using System;
using System.IO;

namespace WpfApp5.ViewModels
{

    class PersonData
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
    }

    interface IAdapter
    {
        void WriteData();
    }

    class XmlAdapter : IAdapter
    {
        private XmlFile _file;

        public XmlAdapter(XmlFile file)
        {
            _file = file;
        }

        public void WriteData()
        {
            _file.Write();
        }




    }
    class JsonAdapter : IAdapter
    {
        private JsonFile _file;

        public PersonData person { get; set; }

        public JsonAdapter(JsonFile file)
        {
            _file = file;
        }

        public void WriteData()
        {
            _file.Write(person, person.Name);
        }




    }

    class XmlFile
    {
        public void Write()
        {
            Console.WriteLine("Xml");
        }

    }

    class JsonFile
    {
        public void Write(PersonData personData, string filename)
        {


            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter($"{filename}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, personData);
                }
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
        public void Write()
        {
            _adapter.WriteData();
        }

    }

    class Application
    {
        private readonly Converter _converter;
        public Application(IAdapter adapter)
        {
            _converter = new Converter(adapter);
        }
        public void Start()
        {
            _converter.Write();

        }
    }

}
