using System;
using System.Collections.Generic;
using System.Text;

namespace AtApi.Model.Settings
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public AuthenticationSettings Authentication { get; set; }
    }
}
