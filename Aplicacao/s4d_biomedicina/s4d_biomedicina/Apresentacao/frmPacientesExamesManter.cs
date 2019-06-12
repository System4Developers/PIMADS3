﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s4d_biomedicina.Apresentacao
{
    public partial class frmPacientesExamesManter : Form
    {
        private string comando;
        private int idPaciente;
        private int idExame;

        public frmPacientesExamesManter(string comando, int idPaciente,int idExame)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
            this.idExame = idExame;
            this.comando = comando;
        }

        private void frmPacientesExamesManter_Load(object sender, EventArgs e)
        {
            
            Modelo.Controle controle = new Modelo.Controle();
            cmbExamesAreas.DataSource = controle.GetExameAreaCombo();

            cmbExamesAreas.DisplayMember = "dsArea";
            cmbExamesAreas.ValueMember = "ID";
            cmbExamesAreas.Text = "";

            
            ltvExamesSelecionados.Columns.Add("ID");
            ltvExamesSelecionados.Columns.Add("Tipo");
            ltvExamesSelecionados.Columns.Add("SubTipo");
        }

        private void bntMover1_Click(object sender, EventArgs e)
        {
            if (ltvExames.SelectedItems.Count < 1)
            {
                MessageBox.Show("selecione um item");
            }
            else
            {
                ltvExamesSelecionados.Items.Add(new ListViewItem(new string[] { ltvExames.SelectedItems[0].Text, ltvExames.SelectedItems[0].SubItems[1].Text, ltvExames.SelectedItems[0].SubItems[2].Text }));
                ltvExames.SelectedItems[0].Remove();
            }
            AjustarColunas(ltvExamesSelecionados);
        }
        
        private void btnRemover_Click(object sender, EventArgs e)
        {

            if (ltvExamesSelecionados.SelectedItems.Count < 1)
            {
                MessageBox.Show("selecione um item");
            }
            else
            {
                ltvExamesSelecionados.SelectedItems[0].Remove();
            }
            CarregaListBox();
            AjustarColunas(ltvExames);
        }

        private void btnMoverTodos_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ltvExames.Items)
            {
                ltvExamesSelecionados.Items.Add((ListViewItem)item.Clone());
            }
            ltvExames.Items.Clear();
            AjustarColunas(ltvExamesSelecionados);
        }

        private void btnRemoverTodos_Click(object sender, EventArgs e)
        {
            ltvExamesSelecionados.Items.Clear();
            AjustarColunas(ltvExames);
            CarregaListBox();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Modelo.Controle controle = new Modelo.Controle();

            int idExameAgendado = 0;
            int idExameParametro = 0;

            idExameAgendado = controle.AdicionarExameAgendado("PENDENTE", dtpAgendamento.Text, this.idExame, this.idPaciente);

            for (int i = 0; i < ltvExamesSelecionados.Items.Count; i++)
            {
                idExameParametro = Convert.ToInt32(ltvExamesSelecionados.Items[i].Text);
                if (idExameParametro > 0)
                {
                    controle.AdicionarExameResultado(idExameAgendado, idExameParametro);
                }
            }
            this.Close();
        }

        private void CarregaListBox()
        {
            Modelo.Controle controle = new Modelo.Controle();
            int id = Convert.ToInt32(cmbExamesAreas.SelectedValue.ToString());
            controle.GetListaExames(id);
            ltvExames.Clear();
            ltvExames.Columns.Add("ID");
            ltvExames.Columns.Add("Tipo");
            ltvExames.Columns.Add("SubTipo"); 


            while (controle.Dr.Read())
            {
                ltvExames.Items.Add(new ListViewItem(new string[] { controle.Dr["ID"].ToString(), controle.Dr["Tipo"].ToString(), controle.Dr["SubTipo"].ToString() }));
            }
        }

        private void AjustarColunas(ListView ltv)
        {
            ltv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ltv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void cmbExamesAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaListBox();
                AjustarColunas(ltvExames);
            }
            catch (Exception)
            {

            }    
        }
    }
}
