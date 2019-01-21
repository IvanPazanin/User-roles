using System;
using System.Collections.Generic;
using System.Text;

namespace Users_roles.Domain.Infrastructure
{
    public static class FullNameExtensions
    {
        public static string FirstLetterToUpper(this string value)
        {
            return value[0].ToString().ToUpper() + value.Remove(0, 1);
        }
    }
}
