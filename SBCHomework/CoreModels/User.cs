using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.CoreModels
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Key { get; set; }

        public int UniqKey { get; set; }

        public bool ShowAcc { get; set; }

    }
}
