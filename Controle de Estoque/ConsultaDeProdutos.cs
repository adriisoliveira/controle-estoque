using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Estoque
{
    public partial class ConsultaDeProdutos : Form
    {
        public ConsultaDeProdutos()
        {
            InitializeComponent();
        }

        private void ConsultaDeProdutos_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicio inicio = new TelaInicio();
            inicio.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConexaoBanco conexao = new ConexaoBanco();
            SqlCommand cmd = new SqlCommand();
            string codigo = txtCodigo.Text;
            cmd.CommandText = "SELECT * FROM Produtos WHERE Codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
           
            try
            {
                //inicia a conexão com o banco
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    codigo = dr["Codigo"].ToString();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Produto");
                    dtvProdutos.DataSource = ds;
                    dtvProdutos.DataMember = "Produto";
                    
                    
                    /*DataTable dt = new DataTable();
                    da.Fill(dt);

                    SqlDataAdapter dataadapter = novo SqlDataAdapter (sql, conexão);
                     DataSet ds = novo DataSet ();
                    connection.Open ();
                    dataadapter.Fill (ds, "Tabela de autores");
                    connection.Close ();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Tabela de autores";*/
                }
                else
                {
                    MessageBox.Show("Código incorreto");
                }
                cmd.ExecuteNonQuery();
                conexao.Desconectar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se ao banco de dados!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            dtvProdutos.Rows.Clear();
        }
    }
}
