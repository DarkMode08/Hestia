using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Share
{
    public class LoginViewModel
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
