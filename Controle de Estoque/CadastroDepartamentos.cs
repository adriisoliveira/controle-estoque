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
    public partial class CadastroDepartamentos : Form
    {
        public CadastroDepartamentos()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicio inicio = new TelaInicio();
            inicio.Show();
            this.Hide();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ConexaoBanco conexao = new ConexaoBanco();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.CommandText = "INSERT INTO Departamentos values ('"+txtCodigo.Text+"','"+txtCnpj.Text+"','"+txtNomeEmpresa.Text+"','"+txtData.Text+"','"+txtNomeFantasia.Text+")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados incluidos com sucesso");
                conexao.Desconectar();
                //Pergunta se o usuário deseja adicionar outro produto
                if (MessageBox.Show("Gostaria de cadastrar outro departamento?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se com o banco de dados!");
            }

        }

        public void LimpaCampos()
        {
            txtCnpj.Text = "";
            txtCodigo.Text = "";
            txtData.Text = "";
            txtNomeEmpresa.Text = "";
            txtNomeFantasia.Text = "";

        }

    }
}
