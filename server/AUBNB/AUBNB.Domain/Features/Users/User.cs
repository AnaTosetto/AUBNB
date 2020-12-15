using System;
using AUBNB.Domain.Features.Hostings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AUBNB.Infra.Security;

namespace AUBNB.Domain.Features.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Password { get; set; }
        public virtual List<Hosting> Hostings { get; set; }

        public string Salt { get; set; }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("User password can not be null");
            }

            this.Salt = encrypter.GetSalt(password);
            this.Password = encrypter.GetHash(password, this.Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => this.Password.Equals(encrypter.GetHash(password, this.Salt));
    }
}
