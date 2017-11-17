using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhSnip.Models.AccountViewModels
{
    public class LoginRegisterViewModel
    {
        public RegisterViewModel Register { get; set; }
        public LoginViewModel Login { get; set; }
    }
}
