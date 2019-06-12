﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s4d_biomedicina.Apresentacao
{
    public partial class frmPacientesExamesResultados : Form
    {
        private string comando;
        private int idExameResultado;

        public frmPacientesExamesResultados(int idExameResultado, string comando)
        {
            InitializeComponent();
            this.comando = comando;
            this.idExameResultado = idExameResultado;

        }

        private void frmPacientesExamesResultados_Load(object sender, EventArgs e)
        {
            if (this.comando == "editar")
            {
                Modelo.Controle controle = new Modelo.Controle();
                controle.GetPacienteExameResultado(this.idExameResultado);
                while (controle.Dr.Read())
                {
                    txbExameTipo.Text = controle.Dr["dsExameTipo"].ToString();
                    txbParametro.Text = controle.Dr["dsExameParametro"].ToString();
                    txbValor1.Text = controle.Dr["valormedidoa"].ToString();
                    txbValor2.Text = controle.Dr["valormedidob"].ToString();
                    txbValor3.Text = controle.Dr["valormedidoc"].ToString();
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.comando == "editar")
            {
                Modelo.Controle controle = new Modelo.Controle();
                controle.AtualizarResultadoExame(this.idExameResultado, Convert.ToDouble(txbValor1.Text), Convert.ToDouble(txbValor2.Text), Convert.ToDouble(txbValor3.Text));
                if (controle.ToString().Equals(""))
                {
                    MessageBox.Show("Valores Salvos com Sucesso!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(controle.ToString());
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
