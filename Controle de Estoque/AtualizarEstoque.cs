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
    public partial class AtualizarEstoque : Form
    {
        public AtualizarEstoque()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicio inicio = new TelaInicio();
            inicio.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarDados();
            //Pergunta se o usuário deseja adicionar outro produto
            if (MessageBox.Show("Gostaria de alterar outro produto?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Caso sim, ele limpa os campos
                LimpaCampos();
            }
            else
            {
                //caso não volta para o inicio
                TelaInicio inicio = new TelaInicio();
                inicio.Show();
                this.Hide();
            }
        }

        private void LimpaCampos()
        {
            txtCodigo.Text = "";
            txtDepartamento.Text = "";
            txtDescricao.Text = "";
            txtProduto.Text = "";
            txtQuantidade.Text = "";
            txtValorCompra.Text = "";
            txtValorVenda.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConexaoBanco conexao = new ConexaoBanco();
            SqlCommand cmd = new SqlCommand();
            string codigo = txtCodigo.Text;
            cmd.CommandText = "SELECT Codigo,Nome,ValorCompra,ValorVenda,QntEstoque,Descricao,Departamento FROM Produtos WHERE Codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.ExecuteNonQuery();
            try
            {
                //inicia a conexão com o banco
                cmd.Connection = conexao.Conectar();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["Codigo"].ToString();
                    txtDepartamento.Text = dr["Departamento"].ToString();
                    txtDescricao.Text = dr["Descricao"].ToString();
                    txtProduto.Text = dr["Nome"].ToString();
                    txtQuantidade.Text = dr["QntEstoque"].ToString();
                    txtValorCompra.Text = dr["ValorCompra"].ToString();
                    txtValorVenda.Text = dr["ValorVenda"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Código incorreto");
                }
                conexao.Desconectar();

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se ao banco de dados!");
            }

        }

        public void SalvarDados()
        {
            ConexaoBanco conexao = new ConexaoBanco();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string codigo = txtCodigo.Text;
                //inicia a conexão com o banco
                cmd.Connection = conexao.Conectar();
                cmd.CommandText = "UPDATE Produtos SET Nome = '" + txtProduto.Text + ",ValorCompra = '" + txtValorCompra.Text + "',ValorVenda = " + txtValorVenda.Text + "',QntEstoque = '" + txtQuantidade.Text + "', Descricao = '" + txtDescricao.Text + " WHERE Codigo = @codigo)";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["Codigo"].ToString();
                    MessageBox.Show("Dados alterados com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro");
                }
                conexao.Desconectar();
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se com o banco de dados!");
            }
        }
    }
}
