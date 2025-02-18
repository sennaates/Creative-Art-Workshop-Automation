using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FionerArt
{
    class SqlBaglantisi
    {
       
      
        public SqlConnection Baglanti()
        {

            SqlConnection baglan = new SqlConnection(@"Server=.\SQLEXPRESS; Database=DboFionerArt; Integrated Security=True");

            baglan.Open();
            return baglan;
        }
        public DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = Baglanti())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }

   
}