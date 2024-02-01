using System;

namespace m2_u1_w1_d4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;

            while (continua)
            {


                Utente.Home();
                string imput = Console.ReadLine();
                switch (imput)
                {
                    case "1":
                        Utente.DataLogin();
                        break;
                    case "2":
                        Utente.Logout();
                        break;
                    case "3":
                        Utente.GetLoginAt();
                        break;
                    case "4":
                        Utente.ShowLastLoginLogout();
                        break;
                    case "5":
                        continua = false;
                        break;


                }
                Console.ReadLine();
            }
        }
    }
}

