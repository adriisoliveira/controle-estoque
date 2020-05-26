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
    public partial class CadastroDeProdutos : Form
    {
        public CadastroDeProdutos()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarProduto();
            //Pergunta se o usuário deseja adicionar outro produto
            if (MessageBox.Show("Gostaria de cadastrar outro produto?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Caso sim, ele limpa os campos
                LimpaCampos();
                SalvarProduto();

            }
            else
            {
                //caso não volta para o inicio
                TelaInicio inicio = new TelaInicio();
                inicio.Show();
                this.Hide();
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicio inicio = new TelaInicio();
            inicio.Show();
            this.Hide();
        }

        private void LimpaCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtNomeProduto.Text = "";
            txtQuantidade.Text = "";
            txtValorCompra.Text = "";
            txtValorVenda.Text = "";
        }

        private void SalvarProduto()
        {
            //Instancia a classe de conexão com o banco
            ConexaoBanco conexao = new ConexaoBanco();
            //Instancia a classe de comandos do SQL
            SqlCommand cmd = new SqlCommand();
            try
            {
                //abre a conexão
                cmd.Connection = conexao.Conectar();
                //Comando SQL para salvar os dados no banco
                cmd.CommandText = "INSERT INTO Produto values ('" + txtCodigo.Text + "','" + txtNomeProduto.Text + "','" + txtValorCompra.Text + "','" + txtValorVenda.Text + "','" + txtQuantidade.Text + "','" + txtDescricao.Text + "','" + cbxDepartamento.Items + ")";
                //executa o comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso!");
                conexao.Desconectar();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se ao banco de dados");
            }

        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConexaoBanco conexao = new ConexaoBanco();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT Codigo FROM Departamentos";
            SqlDataReader dr = cmd.ExecuteReader();
            cbxDepartamento.DisplayMember = "Codigo";
            cbxDepartamento.DataSource = (dr);
            cmd.Connection = conexao.Desconectar();
        }
    }
}
