using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace VegetationMonitoring.Services
{
    public class DebugMailService : IMailService
    {
        public void SendMail(string to, string from, string subject, string body)
        {
            string message = $"Sending Mail: To: {to} From {from} Subject: {subject} Body:{body}";
            Debug.WriteLine(message);
        }
    }
}
