using System;
using System.Security.Cryptography;

namespace transportation
{
    public static class PasswordHasher
    {
        private const int DefaultIterations = 100000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, DefaultIterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                return string.Format("pbkdf2_sha256${0}${1}${2}", DefaultIterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(enteredPassword) || string.IsNullOrWhiteSpace(storedHash))
                return false;

            string[] parts = storedHash.Split('$');
            if (parts.Length != 4)
                return false;

            string algorithm = parts[0];
            string iterationsString = parts[1];
            string saltBase64 = parts[2];
            string hashBase64 = parts[3];

            if (algorithm != "pbkdf2_sha256")
                return false;

            if (!int.TryParse(iterationsString, out int iterations))
                return false;

            byte[] salt = Convert.FromBase64String(saltBase64);
            byte[] expectedHash = Convert.FromBase64String(hashBase64);

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, iterations, HashAlgorithmName.SHA256))
            {
                byte[] actualHash = pbkdf2.GetBytes(expectedHash.Length);
                return FixedTimeEquals(actualHash, expectedHash);
            }
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left == null || right == null)
                return false;
            if (left.Length != right.Length)
                return false;
            int diff = 0;
            for (int i = 0; i < left.Length; i++)
                diff |= left[i] ^ right[i];
            return diff == 0;
        }
    }
}
