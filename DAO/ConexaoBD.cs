using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCurriculos.DAO
{
    public class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            //string strCon = "Data Source=LOCALHOST; Database=AULADB; user id=sa; password=123456";
            string strCon = "Data Source=LOCALHOST\\SQLEXPRESS; Database=AULADB; integrated security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
