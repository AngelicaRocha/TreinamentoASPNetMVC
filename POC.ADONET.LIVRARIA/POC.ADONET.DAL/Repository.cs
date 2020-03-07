using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace POC.ADONET.DAL
{

    public class Repository
    {
        public SqlCommand Cmd { get; set; }
        public SqlConnection Conn { get; set; }

        public Repository()
        {
            Conn = new SqlConnection();
            Cmd = new SqlCommand();
        }

        public bool OpenConection()
        {
            Conn.Open();
            return (Conn.State == System.Data.ConnectionState.Open);            
        }
    }
}
