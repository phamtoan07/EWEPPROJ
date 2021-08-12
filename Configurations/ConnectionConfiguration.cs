using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Eweb.Common.Configurations
{
    public class ConnectionConfiguration
    {
        public const string ConnectionConfig = "ConnectionConfiguration";

        private string _databaseName;
        private string _userName;
        private string _password;
        private string _dbAuthMechanism;
        private string _ipAddress;

        public string DatabaseName { get => _databaseName; set => _databaseName = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string DbAuthMechanism { get => _dbAuthMechanism; set => _dbAuthMechanism = value; }
        public string IpAddress { get => _ipAddress; set => _ipAddress = value; }
    }
}
