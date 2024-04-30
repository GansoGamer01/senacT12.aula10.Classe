namespace WinFormsAppClasse
{
    public partial class FormConta : Form
    {
        // criado um objeto chamado conta do tipo Conta //
        Conta conta = new Conta();

        //criada uma lista de conta //
        List<Conta> contas = new List<Conta>();


        public FormConta()
        {
            InitializeComponent();
            btnSacar.Enabled = false;
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            conta = new Conta();
            // determinei os atributos do objeto conta //
            // obtendo o texto do txtNumeroConta e atribuindo ao NumeroConta //
            conta.NumeroConta = int.Parse(txtNumeroConta.Text);
            conta.Nome = txtTitularConta.Text;
            conta.Depositar(100);
            // adicionar a nova conta na lista //
            contas.Add(conta);

            // carregar a tabela de dados DataGridView //
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = contas;

            // limpa os campos da tela // 
            txtNumeroConta.Clear();
            txtTitularConta.Clear();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            // se a string txtValor.text está nula ou vazia //
            if (string.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Focus();
                MessageBox.Show("preencha o valor de deposito");

                // encerra o metodo de clique //
                return;
            }
            // criar uma variavel para obter o valor a ser depositado //
            decimal valorADepositar = decimal.Parse(txtValor.Text);

            // chama o metodo depositar da classe conta //
            conta.Depositar(valorADepositar);

            // monta uma string chamada dadosconta com o saldo atualizado //



        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            conta.Sacar(100);

        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            if (txtValor.Text.Length > 0)
                btnSacar.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // se o indice da linha for maior ou igual a 0 //
            // significa que foi selecionada uma linha //
            if (e.RowIndex >= 0) 
            {
                // cria uma variave do tipo conta baseado na linha de contas //
                var contaSelecionada = contas[e.RowIndex];

                // atribui o texto para o campo de acordo e numeroConta da conta selecionada //
                txtNumeroConta.Text = contaSelecionada.NumeroConta.ToString();
                txtTitularConta.Text = contaSelecionada.Nome;
            }

        }
    }
}
