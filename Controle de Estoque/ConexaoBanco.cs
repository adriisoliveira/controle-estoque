using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Estoque
{
    class ConexaoBanco
    {
        SqlConnection con = new SqlConnection();
        //metodo construtor da classe
        public ConexaoBanco()
        {
            //string de conexão, é o endereço do banco de dados
            con.ConnectionString = "Data Source=LAPTOP-19CP4RFH\\DRIH;Initial Catalog=controleEstoque;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            //Se a conexão estiver fechada então
            if (con.State == System.Data.ConnectionState.Closed)
            {
                //abre-se a conexão
                con.Open();
            }

            //Retorna a conexão
            return con;
        }

        public SqlConnection Desconectar()
        {
            //Se a conexão estiver aberta então
            if (con.State == System.Data.ConnectionState.Open)
            {
                //fecha-se a conexão
                con.Close();
            }
            //retorna a conexão
            return con;
        }
    }
}
