using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineshoppingstore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "bhor.shailesh@gmail.com";
        public string MailFromAddress = "bhor.shailesh@gmail.com";
        public bool UseSsl = true;
        public string Username = "bhor.shailesh@gmail.com";
        public string Password = "amdavad12!@";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
