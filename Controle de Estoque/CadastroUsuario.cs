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
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
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
            cmd.CommandText = "INSERT INTO  Login values ('" + txtUsuario.Text + "','" + txtSenha.Text + "')";
            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario cadastrado com sucesso!");
                conexao.Desconectar();

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Erro ao conectar-se com o banco");
            }
        }
    }
}
