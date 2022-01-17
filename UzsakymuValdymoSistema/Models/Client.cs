using System;
using System.Collections.Generic;
using System.Text;

namespace UzsakymuValdymoSistema.Models
{
    public class Client
    {
        public int      ClientId          { get; set; }
        public string   ClientName        { get; set; }
        public string   ClientCompanyName { get; set; }

        public Client()
        {
        }

        public Client(int clientId, string clientName, string clientCompanyName)
        {
            ClientId          = clientId;
            ClientName        = clientName;
            ClientCompanyName = clientCompanyName;
        }
    }
}
