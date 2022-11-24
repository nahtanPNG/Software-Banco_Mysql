using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Banco_Mysql
{
    public partial class consulta : Form
    {
        public string sql;
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter adaptador;
        DataTable dados;
        public consulta()
        {
            InitializeComponent();
        }

        public void listar()
        {
            conexao = new MySqlConnection("server=localhost; user=root; password=root; database=usuario");

            sql = "select * from funcionario";

            try
            {
                conexao.Open();
                comando = new MySqlCommand(sql, conexao);
                adaptador = new MySqlDataAdapter(comando);
                dados = new DataTable();
                adaptador.Fill(dados); //Pegando dados para filtrar
                dataGridView1.DataSource = dados;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "update funcionario set nome='" + this.txtNome.Text + "',rua='" + this.txtRua.Text + "',numero='" + this.txtNumero.Text + "',bairro='" + this.txtBairro.Text + "',cep='" + this.txtCep.Text + "',tel='" + this.txtTel.Text + "',email='" + this.txtEmail.Text + "' where codigo ='"+ this.txtCodigo.Text+"'";

            try
            {
                conexao.Open();
                comando = new MySqlCommand(sql, conexao);
                adaptador = new MySqlDataAdapter(comando);
                dados = new DataTable();
                adaptador.Fill(dados);
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados ", erro.Message);
            }

            listar();

            txtCodigo.Clear();
            txtNome.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            txtEmail.Clear();
            txtNumero.Clear();
            txtTel.Clear();
            txtRua.Clear();

        }

        private void consulta_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtCodigo.Text = row.Cells[0].Value.ToString();
            txtNome.Text = row.Cells[1].Value.ToString();
            txtRua.Text = row.Cells[2].Value.ToString();
            txtNumero.Text = row.Cells[3].Value.ToString();
            txtBairro.Text = row.Cells[4].Value.ToString();
            txtCep.Text = row.Cells[5].Value.ToString();
            txtTel.Text = row.Cells[6].Value.ToString();
            txtEmail.Text = row.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql = " delete from funcionario where codigo ='"+ this.txtCodigo.Text +"'";

            try
            {
                conexao.Open();
                comando = new MySqlCommand(sql, conexao);
                adaptador = new MySqlDataAdapter(comando);
                dados = new DataTable();
                adaptador.Fill(dados);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados ", erro.Message);
            }

            listar();

            txtCodigo.Clear();
            txtNome.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            txtEmail.Clear();
            txtNumero.Clear();
            txtTel.Clear();
            txtRua.Clear();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                sql = "select * from funcionario";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            if(radioButton1.Checked == true)
            {
                sql = "select * from funcionario where codigo =" + textBox1.Text + "";
            }else if(radioButton2.Checked == true)
            {
                sql = "select * from funcionario where nome like '%" + textBox1.Text + "%'";
            }
            try
            {
                conexao.Open();
                comando = new MySqlCommand(sql, conexao);
                adaptador = new MySqlDataAdapter(comando);
                dados = new DataTable();
                adaptador.Fill(dados);

                dataGridView1.DataSource = dados;
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados!!!", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
