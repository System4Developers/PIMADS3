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
    public partial class frmExamesTiposManter : Form
    {

        private string comando;
        private int idExameTipo;

        public frmExamesTiposManter(string comando, int idExameTipo)
        {
            InitializeComponent();
            this.comando = comando;
            this.idExameTipo = idExameTipo;
        }

        private void frmExamesTiposManter_Load(object sender, EventArgs e)
        {
            Modelo.Controle controle = new Modelo.Controle();
            cmbDsArea.DataSource = controle.GetExameAreaCombo(); 
            cmbDsArea.DisplayMember = "dsArea";
            cmbDsArea.ValueMember = "ID";

            if (this.comando.Equals("editar"))
             {
                controle.GetEditarExameTipo(this.idExameTipo);
                 while (controle.Dr.Read())
                 {
                     txbID.Text = this.idExameTipo.ToString();
                     cmbDsArea.Text = controle.Dr["dsExameArea"].ToString();
                     cmbStatus.Text = controle.Dr["estadoExameTipo"].ToString();
                     txbTipo.Text = controle.Dr["dsExameTipo"].ToString();
                 }
            }
            else
            {
                this.cmbStatus.SelectedIndex = 0;
            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Modelo.Controle controle = new Modelo.Controle();
            if (this.comando.Equals("inserir"))
            {
               controle.cadastrarExameTipo(txbTipo.Text, cmbStatus.Text, Convert.ToInt32(cmbDsArea.SelectedValue.ToString()));
                if (controle.ToString().Equals(""))
                {
                    MessageBox.Show("Cadastrado com Sucesso!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(controle.ToString());
                }
            }

            if (this.comando.Equals("editar"))
            {
                controle.AtualizarExamesTipos(txbTipo.Text,cmbStatus.Text, Convert.ToInt32(txbID.Text), Convert.ToInt32(cmbDsArea.SelectedValue.ToString()));
                if (controle.ToString().Equals(""))
                {
                    MessageBox.Show("Atualizado com Sucesso!");
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
