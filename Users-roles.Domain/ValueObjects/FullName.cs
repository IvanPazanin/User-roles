using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Users_roles.Domain.Infrastructure;

namespace Users_roles.Domain.ValueObjects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public FullName(string fullName)
        {
            var regex = new Regex(@"[a-zA-ZčćšĐžČĆŠĐŽ]+");
            var matches = regex.Matches(fullName);
            MiddleName = "";
            FirstName = "";
            LastName = "";

            if (matches.Count == 0)
                throw new Exception(string.IsNullOrEmpty(fullName) 
                    ? "name field cannot be empty" 
                    : $"{fullName} is invalid value");

            for (var i = 0; i < matches.Count; i++)
            {
                if (i == 0)
                    FirstName = matches[i].Value.FirstLetterToUpper();

                else if (i == matches.Count - 1)
                    LastName = matches[i].Value.FirstLetterToUpper();

                else
                    MiddleName += i < matches.Count - 2
                        ? matches[i].Value.FirstLetterToUpper() + " "
                        : matches[i].Value.FirstLetterToUpper();
            }
        }

        public static explicit operator FullName(string fullName)
        {
            return new FullName(fullName);
        }

        public static implicit operator string(FullName customName)
        {
            return customName.ToString();
        }

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }
    }
}
