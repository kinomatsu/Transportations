using System.Security.Cryptography;
using System.Text;

namespace Transportations.BLL
{
    /// <summary>
    /// Хеширование паролей алгоритмом SHA-256.
    /// Возвращает hex-строку из 64 символов.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>Хеширует открытый текст и возвращает hex SHA-256.</summary>
        public static string Hash(string plainText)
        {
            ArgumentNullException.ThrowIfNull(plainText);
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            var sb = new StringBuilder(64);
            foreach (var b in bytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
