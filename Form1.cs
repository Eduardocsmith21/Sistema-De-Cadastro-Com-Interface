using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form 
    {
        List<Pessoa> pessoas;

        public object Pessoas { get; private set; }

        public Form1()
        {
            InitializeComponent();
            pessoas = new List<Pessoa>();
            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Viuvo");
            comboEC.Items.Add("Divorciado");

            comboEC.SelectedIndex = 0;  //Para deixar um dos itens já selecionado como padrão
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            int index = -1;
            
            foreach(Pessoa ps in pessoas)
            {
                if(ps.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(ps);

                }
            }
            if(txtNome.Text == "")
            {
                MessageBox.Show("PREENCHA O CAMPO NOME");  // Caso a pessoa não preencha o campo nome aparecerar a menssagem
                txtNome.Focus();     //Dara foco no campo que não foi preenchido
                return;        //Se os campos não estivrem preenchidos não podera seguir com o cadastro

            }
            if(txtTelefone.Text == "(  )       - ")
            {
                MessageBox.Show("PREENCHA O CAMPO TELEFONE");
                txtTelefone.Focus();
                return;
            }
            char sexo;

            if(radioM.Checked)      //Se a opção checada (click) for masculino
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivel = comboEC.SelectedItem.ToString();  //Estado selecionado e convertido para string
            p.telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;      //Checando se a opção foi selecionada, analisa se foi checada e retorna um bool
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            //Verificando se será feio o cadastro de uma pessoa nova ou já existente na lista

            if(index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);        //Limpando os campos usando o botão limpar

            Listar();       //Limpar toda a lista e execultar novamente 
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = Lista.SelectedIndex;  //Seleciona um cadastro da lista
            pessoas.RemoveAt(indice);   //Remove o cadastro selecionado
            Listar();   //Lista novamente os cadastro atualizado    
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            txtTelefone.Text = "";
            comboEC.SelectedIndex = 0;
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = false;
            radioF.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();
        }
        private void Listar()
        {
            Lista.Items.Clear();       //Limpar todos os itens do ListBox

            foreach(Pessoa p in pessoas)
            {
                Lista.Items.Add(p.Nome);    //Pega apenas a propriedade nome, listando somente os nomes  
            }

        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = Lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivel;
            txtTelefone.Text = p.telefone;
            checkCasa.Checked = p.CasaPropria;
            checkVeiculo.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }



        }
    }
}
