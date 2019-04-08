using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public static class Configuration
    {
        public static string ConnectionString => @"Server=(localdb)\MSSQLLocalDB;Database=MyApplicationDb;Integrated Security=True";
    }
}
