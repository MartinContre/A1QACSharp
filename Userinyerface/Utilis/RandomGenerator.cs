using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using System.Text;

namespace Userinyerface.Utilis
{
    public class RandomGenerator
    {
        private static readonly int minLength = 10;
        private static readonly Random random = new();

        private static readonly string CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string LETTERS = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string NUMBERS = "0123456789";
        private static readonly string CYRILLIC = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string GenerateRandomEmail(int length)
        {
            if (length < minLength)
            {
                Logger.Instance.Warn("The mail lenght was less than 10, using default value");
                length = minLength;
            }

            string allowedChars = CAPS + LETTERS;
            char[] email = new char[length];

            for (int i = 0; i < length; i++)
            {
                email[i] = allowedChars[random.Next(allowedChars.Length)];
            }


            return new string(email);
        }
        public static string GenerateRandomPassword(string email, int length)
        {
            string allowedChars = CAPS + LETTERS + NUMBERS;
            if (length < minLength)
            {
                Logger.Instance.Warn("The password lenght was less than 10, using default value");
                length = minLength;
            }

            StringBuilder password = new StringBuilder();
            password.Append(CAPS[random.Next(CAPS.Length)]);
            password.Append(NUMBERS[random.Next(NUMBERS.Length)]);
            password.Append(email[random.Next(email.Length)]);
            password.Append(CYRILLIC[random.Next(CYRILLIC.Length)]);

            for (int i = password.Length; i < length; i++)
            {
                char nextChar;

                nextChar = (random.Next(2) == 0) ? allowedChars[random.Next(allowedChars.Length)] : CYRILLIC[random.Next(CYRILLIC.Length)];

                password.Append(nextChar);
            }

            // Shuffle the password characters
            for (int i = password.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (password[j], password[i]) = (password[i], password[j]);
            }

            return password.ToString();
        }

        public static string GetEmailDomain(List<string> domains)
        {
            int i = random.Next(domains.Count);
            return domains[i];
        }
    }
}
