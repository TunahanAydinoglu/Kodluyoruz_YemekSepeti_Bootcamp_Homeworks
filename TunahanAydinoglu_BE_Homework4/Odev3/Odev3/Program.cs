using System;
using System.Collections.Generic;
using System.Linq;

namespace Odev3
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Clean Code [ Temiz Kodlama ] Prensipleri – Giriş

            #region Boolean Karsilastirma
            bool start = true;
            if (start == true)
            {
                Console.WriteLine("yanlis yaklasim");
            }

            if (start)
            {
                Console.WriteLine("dogru yaklasim");
            }



            #endregion Boolean Karsilastirma

            #region Boolean Değer Atamaları

            int not = 80;

            //Hatali yaklasim
            bool gecerNotMu = false;
            if (not > 70)
            {
                gecerNotMu = true;
            }
            else
            {
                gecerNotMu = false;
            }

            //Dogru yaklasim
            bool notGecerMi = not > 70;


            #endregion Boolean Değer Atamaları

            #region Pozitif Ol
            bool dersiGecti = true;
            bool derstenKaldi = false;
            if (!derstenKaldi)
            {
                Console.WriteLine("yanlis yaklasim");
            }

            if (dersiGecti)
            {
                Console.WriteLine("dogru yaklasim");
            }

            string name = "";

            bool DoluMu()
            {
                return !(name == null);
            }

            bool DoluMu2()
            {
                return name.Length > 0;
            }

            #endregion Pozitif Ol

            #region Ternary IF
            bool proMember = true;
            int requestLimit;

            //yanlis yaklasim
            if (proMember)
            {
                requestLimit = 999;
            }
            else
            {
                requestLimit = 100;
            }

            //dogru yaklasim

            requestLimit = proMember ? 999 : 100;



            #endregion Ternary IF

            #region Strongly type  kullan, stringly type değil

            //YANLIS YAKLASIM

            string memberType = "ProMember";

            if (memberType == "ProMember")
            {
                Console.WriteLine(memberType);
            }

            var user1 = UserType.Pro;

            if (user1 == UserType.Pro)
            {
                Console.WriteLine(user1);
            }



            #endregion Strongly type  kullan, stringly type değil

            #region Başı boş ifadelerden kaçının
            //yanlis yaklasim
            int speed = 140;
            if (speed > 120)
            {
                Console.WriteLine("Hiz limiti asildi");
            }

            //dogru yaklasim
            int maxSpeed = 120;
            if (speed > maxSpeed)
            {
                Console.WriteLine("Hiz limiti asildi");
            }

            #endregion Başı boş ifadelerden kaçının

            #region Karmaşık koşulları sadeleştir ve anlamlandır

            //yanlis yaklasim
            int age = 20;
            int height = 170;
            if (age > 18 && height > 165)
            {
                Console.WriteLine("Ise giris sartlari karsiliyor");
            }

            //Dogru yaklasim
            int ageRequirement = 18;
            int heightRequirement = 165;
            bool jobEntryRequirement = age > ageRequirement && height > heightRequirement;

            if (jobEntryRequirement)
            {
                Console.WriteLine("Ise giris sartlari karsiliyor");
            }

            #endregion Karmaşık koşulları sadeleştir ve anlamlandır

            #region Açıklayıcı ol doğru aracı kullan
            //yanlis yaklasim

            List<User> users = new List<User>();

            List<User> relatedUsers = new List<User>();

            foreach (var user in users)
            {
                if (user.age > 18 && user.IsActive && user.userType == UserType.Pro)
                {
                    relatedUsers.Add(user);
                }
            }
            Console.WriteLine(relatedUsers);


            //dogru yaklasim


            Console.WriteLine(
                 users.Where(u => u.age > 18 && u.IsActive && u.userType == UserType.Pro)
                );



            #endregion Açıklayıcı ol doğru aracı kullan

            #endregion Clean Code [ Temiz Kodlama ] Prensipleri – Giriş


            #region Clean Code [ Temiz Kodlama ] Prensipleri – Method Function


            #region Degiskenler
            //yanlis yaklasim
            int minAge = 18;
            int maxAge = 55;
            bool validAge;
            User user3 = new User();

            if (user3.age < minAge)
            {
                validAge = false;
            }
            if (user3.age > maxAge)
            {
                validAge = false;
            }


            //dogru yaklasim

            int minAge2 = 18;
            if (user3.age < minAge2)
            {
                validAge = false;
            }
            int maxAge2 = 55;

            if (user3.age > maxAge2)
            {
                validAge = false;
            }




            #endregion Degiskenler

            #region Parametreler

            //yanlis yaklasim birden cok parametre girmek
            static void AddUser(
                              string Name,
                              int age,
                              bool IsActive
                )
            { }

            // dogru yaklasim parametre yerine model girmek
            static void AddUser2(User user) { }

            #endregion Parametreler

            #region Karmaşıklık ve Girintiler azaltmak
            //yanlis yaklasim
            if (user3.age > minAge)
            {
                if (user3.IsActive)
                {
                    if (user3.Name.Length > 3)
                    {
                        Console.WriteLine("Yanlis yaklasim");
                    }
                }
            }

            //dogru yaklasim

            if (user3.age > minAge)
            {
                CheckUser(user3);
            }

            static void CheckUser(User user)
            {
                if (user.IsActive)
                {
                    if (user.Name.Length > 3)
                    {
                        Console.WriteLine("dogru yaklasim");
                    }
                }
            }


            #endregion Karmaşıklık ve Girintiler azaltmak

            #region Tekrarlamayı azaltmak

            //yanlis yaklasim kodlari tekrarlamak
            int counter = 0;

                counter = counter + 1;
            counter = counter + 2;
            counter = counter + 1;
            counter = counter + 3;
            counter = counter + 1;

            //dogru yaklasim yapilan işi methodlamak

            int Increment(int value, int incrementPay)
            {
                return value + incrementPay;
            }

            counter = Increment(counter, 1);
            counter = Increment(counter, 2);
            counter = Increment(counter, 3);

            #endregion Tekrarlamayı azaltmak

            #region Fail Fast
            //yanlis yaklasim once isi yapan kodu yazip sonra hatayi kodlamak

            void SaveUser(User user)
            {
                if (user.Name.Length > 0)
                {
                    user.Name = user.Name.ToUpper();

                    if (user.IsActive)
                    {
                        Console.WriteLine("Kayit alindi");
                    }
                    else
                    {
                        throw Exception("Kayit alinamadi");
                    }
                }
                else
                {
                    throw Exception("Kayit alinamadi");
                }
            }


            //dogru yaklasim hatalardan gectikten sonra isi kodlamak

            void SaveUser2(User user)
            {
                if (user.Name.Length <= 0)
                {
                    throw Exception("Kayit alinamadi");
                }
                if (!user.IsActive)
                {
                    throw Exception("Kayit alinamadi");
                }
                Console.WriteLine("Kayit alindi");
            }


            #endregion Fail Fast

            #region Return Early

            //yanlis yaklasim
            bool IsValidUser(User user)
            {
                bool isValid = false;
                if (user.IsActive)
                {
                    if(user.age > 18)
                    {
                        if(user.Name.Length > 0)
                        {
                            isValid = true;
                        }
                    }
                }

                return isValid;
            }

            //dogru yaklasim
            bool IsValidUser2(User user)
            {
                if (!user.IsActive)
                {
                    return false;
                }
                int minAge3 = 18;
                if(user.age < minAge3)
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    return false;
                }

                return true;
            }


            #endregion Return Early



            #endregion Clean Code [ Temiz Kodlama ] Prensipleri – Method Function


            Console.ReadKey();
        }
    
        enum UserType
        {
            Pro,
            Free
        }

        class User
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
            public int age { get; set; }
            public UserType userType { get; set; }

        }

        private static Exception Exception(string v)
        {
            throw new NotImplementedException();
        }

    }
}
