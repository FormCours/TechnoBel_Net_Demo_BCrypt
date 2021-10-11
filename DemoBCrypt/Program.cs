using System;

namespace DemoBCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string salt1 = Guid.NewGuid().ToString();
            string salt2 = BCrypt.Net.BCrypt.GenerateSalt();

            Console.WriteLine(salt1);
            Console.WriteLine(salt1.Length);

            Console.WriteLine("---------------------------");

            Console.WriteLine(salt2);
            Console.WriteLine(salt2.Length);

            Console.WriteLine("---------------------------");

            string pwd = "Test1234=";

            string saltDemo = BCrypt.Net.BCrypt.GenerateSalt();
            string pepperDemo = BCrypt.Net.BCrypt.GenerateSalt();
            string pwdHash = BCrypt.Net.BCrypt.HashPassword(saltDemo + pwd + pepperDemo);

            Console.WriteLine("Pwd : " + pwd);
            Console.WriteLine("Salt : " + saltDemo);
            Console.WriteLine("pepper : " + pepperDemo);
            Console.WriteLine("Hash : " + pwdHash);

            string pwd2 = "Test1234=";

            string temp = saltDemo + pwd + pepperDemo;
            bool test =  BCrypt.Net.BCrypt.Verify(temp, pwdHash);
            Console.WriteLine(test);
        }
    }
}
