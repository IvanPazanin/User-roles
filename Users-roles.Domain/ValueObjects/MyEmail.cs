using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using UsersRoles.Domain.Infrastructure;

namespace UsersRoles.Domain.ValueObjects
{
    public class MyEmail : ValueObject
    {
        public string Value { get; set; }

        private MyEmail()
        {
        }

        public MyEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                Value = email;
            }
            catch (FormatException ex)
            {
                throw new Exception($"MyEmail adress: {email} is not valid!\n {ex.Message}");
            }
        }

        public static explicit operator MyEmail(string email)
        {
            return new MyEmail(email);
        }

        public static implicit operator string(MyEmail email)
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
