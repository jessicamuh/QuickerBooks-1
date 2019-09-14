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

      
        public Task<IdentityResult> ValidateAsync(string password)
        {
            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed( String.Format("Password should be at least {0} characters", RequiredLength)));
            }

            //  string pattern = (@"[a-zA-Z]+");
            string s = password.Substring(0, 1);
            if (!Regex.Match(s, "^[a-zA-Z]").Success) {
                return Task.FromResult(IdentityResult.Failed("Password must start with a letter"));
            }

                /*  string s = password.Substring(0, 1);
                  if (!s.Equals(@"^[A-Z]") || !s.Equals(@"^[a-z]"))
                  {
                      return Task.FromResult(IdentityResult.Failed("Password must start with a letter"));
                  }*/

                List<string> patterns = new List<string>();
            patterns.Add(@"[a-zA-Z]+");                                      // lowercase & uppercase
            patterns.Add(@"[0-9]");                                          // digits                                                                
            patterns.Add(@"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]"); // special symbols

            foreach (string p in patterns)
                {
                    if (!Regex.IsMatch(password, p))
                    {
                        return Task.FromResult(IdentityResult.Failed("Password must contain a letter, number and special character"));      
                    }        
                }
            return Task.FromResult(IdentityResult.Success);
        }  
    }
}
    