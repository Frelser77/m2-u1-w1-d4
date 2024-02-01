using System;

namespace m2_u1_w1_d4
{
    internal static class Utente
    {
        private static string Email;
        private static string Password;
        private static string Password2;
        private static bool IsLoggedIn;
        private static DateTime LoginAt;
        private static string TipoUltimoAccesso;


        public static void SetEmail(string email)
        { Email = email; }

        public static void SetPassword(string password)
        { Password = password; }

        public static void SetPassword2(string password2)
        { Password2 = password2; }

        public static void SetLoginDate(DateTime loginAt)
        { LoginAt = DateTime.Now; }

        // controllo se utente é loggato
        public static bool GetIsLoggedIn()
        {
            return IsLoggedIn;
        }
        // setto l'utente su loggato altrimenti rimane false
        public static void SetIsLoggedIn(bool isLoggedIn)
        {
            IsLoggedIn = isLoggedIn;
        }
        public static void GetLoginAt()
        {
            if (IsLoggedIn)
            {
                string loginAt = LoginAt.ToString("dd/MM/yyyy HH:mm:ss");
                Console.WriteLine("Ora e Data login: \n" + loginAt);
            }
            else
            {
                Console.WriteLine("Devi loggarti per vedere questa informazione");
            }
        }

        // metodo home
        public static void Home()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
        }
        public static void TakeLogin()
        {
            Console.WriteLine("Registrati\n");
            Console.Write("Inserisci email: ");
            string email = Console.ReadLine();
            SetEmail(email);
            Console.Write("Inserisci password: ");
            string password = Console.ReadLine();
            SetPassword(password);
            Console.Write("Ripeti password: ");
            string password2 = Console.ReadLine();
            SetPassword2(password2);
            PasswordRepeat(password, password2);
            DateTime loginDate = DateTime.Now;                           // Ottiene la data e l'ora corrente
            string loginAt = loginDate.ToString("dd/MM/yyyy HH:mm:ss"); // Converte la data in una stringa con un formato specifico
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratlazioni registrazione avvenuta con successo");
            Console.WriteLine("Ecco un riepilogo dati");
            Console.WriteLine("La tua email: \n" + email);
            Console.WriteLine("La tua password: \n" + password);
            Console.WriteLine("Ora e Data login: \n" + loginAt);
            Console.ResetColor();
        }

        // metodo effettua login
        public static void EffectLogin()
        {
            do// si ripete finché l'utente non logga
            {
                Console.WriteLine("\nEffettua login");
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine(Login(email, password));
            } while (!GetIsLoggedIn());
        }

        // metodo login completo
        public static void DataLogin()
        {
            TakeLogin();
            EffectLogin();
        }


        //controllo dati 
        // passo email e password se sono uguali a quelle registrate, logga
        public static string Login(string email, string password)
        {
            if (Email == email && Password == password)
            {
                IsLoggedIn = true;
                LoginAt = DateTime.Now;
                TipoUltimoAccesso = "Login";
                Console.ForegroundColor = ConsoleColor.Green;
                return "Login effettuato con successo\n" +
                        "Premere un tasto per continua...   ";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Email o password non corretti";
            }
        }

        public static bool PasswordRepeat(string password, string password2)
        {
            if (password != password2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le password non corrispondono.");

                TakeLogin();
                return false;
            }
            else
            {
                return true;

            }
        }

        public static void Logout()
        {
            // Chiedi all'utente se è sicuro di voler effettuare il logout solo se è loggato
            if (IsLoggedIn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sicuro di volere effettuare il logout?");
                Console.WriteLine("y/n");
                string logout = Console.ReadLine();
                if (logout == "y")
                {
                    IsLoggedIn = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Logout effettuato con successo.");
                    TipoUltimoAccesso = "Logout";
                }
                else if (logout == "n")
                {
                    Console.WriteLine("Premere un tasto per tornare alla Home");
                    Console.ReadLine();
                    Home();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Scelta non valida.");
                    Console.ReadLine();
                    Home();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non sei loggato per effettuare un logout.");
            }

        }
        public static void ShowLastLoginLogout()
        {
            if (LoginAt == default(DateTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nessun accesso precedente registrato.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Ultimo {TipoUltimoAccesso}: {LoginAt:dd/MM/yyyy HH:mm:ss}");
                Console.WriteLine("Premi un tasto per continuare...");
            }
        }

    }
}
