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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            ConexaoBanco conexao = new ConexaoBanco();
            SqlCommand cmd = new SqlCommand();
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            cmd.CommandText = "SELECT Usuario, Senha FROM Login WHERE Usuario = @usuario and Senha = @senha";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = conexao.Conectar();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = dr["Usuario"].ToString();
                    senha = dr["Senha"].ToString();
                    TelaInicio inicio = new TelaInicio();
                    inicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login ou senha incorretos!");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Erro aos se conectar com o banco de dados!");
            }
            conexao.Desconectar();

        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
