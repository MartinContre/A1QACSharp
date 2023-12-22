using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroNewsTest.Utils
{
    public abstract class PasswordGenerator
    {
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "0123456789";
        private const string SpecialSymbols = "!@#$%^&*()-_+=<>?";

        public static string GeneratePassword(int length)
        {
            if (length < 8)
            {
                Console.WriteLine("La longitud debe ser al menos 8. Ajustando la longitud a 8.");
                length = 8;
            }

            string password = GenerateRandomPart(UppercaseLetters, 1) +
                              GenerateRandomPart(LowercaseLetters, 1) +
                              GenerateRandomPart(Numbers, 1) +
                              GenerateRandomPart(SpecialSymbols, 1) +
                              GenerateRandomPart(UppercaseLetters + LowercaseLetters + Numbers + SpecialSymbols, length - 4);

            // Mezclar la contraseña para que los caracteres estén en orden aleatorio
            password = new string(password.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());

            return password;
        }

        private static string GenerateRandomPart(string characters, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
