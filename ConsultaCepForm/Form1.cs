using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsultaCepForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCep.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtRua.Text = String.Empty;
            txtBairro.Text = String.Empty;

        }

        private void btnConsultaCep_Click(object sender, EventArgs e)
        {

        
            txtCidade.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtRua.Text = String.Empty;
            txtBairro.Text = String.Empty;

            if (!String.IsNullOrWhiteSpace(txtCep.Text))
            {
                using (var ws = new wsCorreiosForm.AtendeClienteClient())
                {

                    try
                    {
                        var endereco = ws.consultaCEP(txtCep.Text.Trim());
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtEstado.Text = endereco.uf;
                        txtRua.Text = endereco.end;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            else 
            {

                MessageBox.Show("Informe um Cep valido",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
