using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using Users_roles.Domain.Infrastructure;

namespace Users_roles.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; set; }

        public Email(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                Value = email;
            }
            catch (FormatException ex)
            {
                throw new Exception($"Email adress: {email} is not valid!\n {ex.Message}");
            }
        }

        public static explicit operator Email(string email)
        {
            return new Email(email);
        }

        public static implicit operator string(Email email)
        {
            return email.ToString();
        }

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
