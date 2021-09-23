using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.ViewModels;

namespace WpfApp5.Models
{
    public class User : BaseViewModel
    {
        public User()
        {

        }
        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }


        public override string ToString()
        {
            return $"{Name}-{Surname}-{Email}";
        }
    }
}
