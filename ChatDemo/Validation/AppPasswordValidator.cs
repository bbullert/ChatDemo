using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatDemo.Validation
{
    public class AppPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : IdentityUser
    {
        private readonly AppIdentityErrorDescriber appIdentityErrorDescriber;

        public AppPasswordValidator(AppIdentityErrorDescriber appIdentityErrorDescriber)
        {
            this.appIdentityErrorDescriber = appIdentityErrorDescriber;
        }

        public int RequiredLength { get; set; } = 8;

        public int MaximumLength { get; set; } = 50;

        public string AllowedCharacters { get; set; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./\\:;<=>?@[]^_`{|}~ ";

        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            var errors = new List<IdentityError>();

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add(appIdentityErrorDescriber.InvalidPassword());
            }
            if (password.Length > MaximumLength)
            {
                errors.Add(appIdentityErrorDescriber.PasswordTooLong(MaximumLength));
            }
            if (password.Except(AllowedCharacters).Any())
            {
                errors.Add(appIdentityErrorDescriber.InvalidPassword());
            }

            var result = errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;

            return Task.FromResult(result);
        }
    }
}
