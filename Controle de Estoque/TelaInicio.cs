using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Estoque
{
    public partial class TelaInicio : Form
    {
        public TelaInicio()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //instancia a classe da tela desejada
            ConsultaDeProdutos consulta = new ConsultaDeProdutos();
            //metodo show abre a tela
            consulta.Show();
            //método que fecha a tela atual
            this.Hide();
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            CadastroDeProdutos Cprodutos = new CadastroDeProdutos();
            Cprodutos.Show();
            this.Hide();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AtualizarEstoque Aestoque = new AtualizarEstoque();
            Aestoque.Show();
            this.Hide();
        }

        private void btnCadastrarDepartamento_Click(object sender, EventArgs e)
        {
            CadastroDepartamentos Cdepartamento = new CadastroDepartamentos();
            Cdepartamento.Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicio inicio = new TelaInicio();
            inicio.Show();
            this.Hide();
        }

        private void TelaInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            CadastroUsuario NewUsuario = new CadastroUsuario();
            NewUsuario.Show();
            this.Hide();
        }
    }
}
