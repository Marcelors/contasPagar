using System;
using System.Linq;

namespace BILLSToPAY.Domain.Shared.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this string value) => !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);

        private static string Chars => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateString(int length)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(Chars, length)
                              .Select(x => x[random.Next(x.Length)])
                              .ToArray());
        }


    }
}
