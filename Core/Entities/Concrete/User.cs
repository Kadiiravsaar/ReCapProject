using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; } // salt demek haslenen verilin sonuna kendimiz bi veri daha ekleiyoruz tuzluyoruz demek
        public byte[] PasswordHash { get; set; }//şifre hash'lerken kendim tuzlama yapıyorum, tekrar şifreyi verify edeceğim zaman bu salt değerine ihtiyacım var.
        public bool Status { get; set; }
    }
}
