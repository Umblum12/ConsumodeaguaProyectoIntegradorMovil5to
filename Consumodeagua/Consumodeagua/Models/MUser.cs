using System;
using System.Collections.Generic;
using System.Text;

namespace Consumodeagua.Models
{
    public class MUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }
    }
}
