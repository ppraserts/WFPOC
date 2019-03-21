using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace LoginLab
{

    public sealed class LoginActivity : CodeActivity<bool>
    {
        // Define an activity input argument of type string
        public InArgument<string> Username { get; set; }
        public InArgument<string> Password { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override bool Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string username = context.GetValue(this.Username);
            string password = context.GetValue(this.Password);

            if (username == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
