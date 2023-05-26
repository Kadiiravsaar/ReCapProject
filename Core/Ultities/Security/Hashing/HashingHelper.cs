using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.Hashing
{
    public class HashingHelper // bi tane hash'leme aracı yazıcaz bu bir araç (Örneğin parola hasleme)
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) // ona verdiğimiz password'ün hashini oluşturacak, saltını da oluştruucak
            // out keywördü oray gönderilen 2 tane değeri boş bile olsa doldurup geriye döndürmeye yarıyor referans yapılar için
            // out'u dışarıya verilecek değer gibi düşünebiliriz.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) // kriptografi algoritmasını kullanmak için
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // byte array'e dönüşdürdük 

                // kısacası bu kod verilen password değerine göre passwordHash ve passwordSalt değerini oluşturmaya yarar
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // out olmamalı çünkü bu değerleri biz vericez ve karşılaştırma yapıcaz
        { // string password => kullanıcının sonradan sisteme girerken kullandığı paroladır  

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) 
            {
                // bu metot (VerifyPasswordHash) => sonradan sisteme girmek isteyen kişinin verdiği password ile dbdeki hashle ilgili salta göre eşleşip eşleşmediğini verdiğimiz yerdir

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // computedHash ;=> hesaplanan hash demek
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) // passwordHash=> veritabanından gönderilenin i. değerine 
                    {
                        return false;
                    }
                }
               
            }
            return true;
        }

    }
}
