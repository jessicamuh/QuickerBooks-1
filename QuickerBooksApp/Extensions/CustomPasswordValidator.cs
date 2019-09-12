using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace QuickerBooksApp.Extensions
{
    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }
        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }

        /* 
         * logic to validate password: I am using regex to count how many 
         * types of characters exists in the password
         */
        public Task<IdentityResult> ValidateAsync(string password)
        {
            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed( String.Format("Password should be at least {0} characters", RequiredLength)));
            }

      
            List<string> patterns = new List<string>();
            patterns.Add(@"[a-z]");                                          // lowercase
            patterns.Add(@"[A-Z]");                                          // uppercase
            patterns.Add(@"[0-9]");                                          // digits                                                                
            patterns.Add(@"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]"); // special symbols

            char c = password[0];
            if (!c.Equals("^[A-Z].*$") || !c.Equals("^[a-z].*$"))
            {
                return Task.FromResult(IdentityResult.Failed("Password must start with a letter"));
            }

            foreach (string p in patterns)
                {
                    if (!Regex.IsMatch(password, p))
                    {
                        return Task.FromResult(IdentityResult.Failed("Password must contain a letter, number"));      
                    }        
                }
            return Task.FromResult(IdentityResult.Success);
        }  
    }
}
    