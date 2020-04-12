using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolMachine.DbConnectionManagement
{
    public class MessagingConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DataStoreConnectionString { get; set; }

        public string DataStoreTarget { get; set; }

        public string Target { get; set; }
    }
}
