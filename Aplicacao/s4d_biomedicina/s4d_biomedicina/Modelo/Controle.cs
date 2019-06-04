﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s4d_biomedicina.Modelo

{
    public class Controle : absPropriedades
    {

        #region Login
        public void acessar(string login, string senha)
        {
            Estaticos.logado = false;
            this.mensagem = "";

            Validacao validacao = new Validacao();
            validacao.verLogin(login, senha);
            if (validacao.ToString().Equals(""))
            {
                DAL.dalUsuario loginCmd = new DAL.dalUsuario();
                loginCmd.VerificarLogin(login, senha);
                if (loginCmd.ToString().Equals(""))
                {
                    Estaticos.logado = true;
                    Estaticos.userName = login;
                }
                else
                {
                    this.mensagem= loginCmd.ToString();
                }
            }
            else
            {
                this.mensagem = validacao.ToString();
            }
        }
        #endregion

        #region Manter Usuario
        public void cadastrarUsuario(string login, string senha, string ra, string registro, string curso, string estado, string tipo, int idPessoa)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao();
            validacao.verCadastroUsuario(login,senha,ra,registro,curso,estado,tipo,idPessoa);
            if (validacao.ToString().Equals(""))
            {
                DAL.dalUsuario usuario = new DAL.dalUsuario();
                usuario.AdicionarUsuario(login, senha, ra, registro, curso, estado, tipo, idPessoa);
                if (!usuario.ToString().Equals(""))
                {
                    this.mensagem = usuario.ToString();
                }
            }
            else
            {
                this.mensagem = validacao.ToString();
            }
        }

        public void AtualizarUsuario(string login, string senha, string ra, string registro, string curso, string estado, string tipo, int idPessoa,int idUsuario)
        {
            this.mensagem = "";
            DAL.dalUsuario usuario = new DAL.dalUsuario();
            usuario.AtualizarUsuario(login, senha, ra, registro, curso, estado, tipo, idPessoa,idUsuario);
            if (!usuario.ToString().Equals(""))
            {
                this.mensagem = usuario.ToString();
            }
        }

        public DataTable ListaUsuario()
        {
            DataTable dt = new DataTable();
            DAL.dalUsuario usuario = new DAL.dalUsuario();
            dt = usuario.GetListaUsuario();
            return dt;
        }

        public DataTable PequisarUsuario(int idUsuario, string dslogin)
        {
            DataTable dt = new DataTable();
            DAL.dalUsuario usuario = new DAL.dalUsuario();
            dt = usuario.GetPesquisaUsuario(idUsuario, dslogin);
            return dt;
        }
        #endregion

        #region Manter Paciente
        public void cadastrarPaciente(string nome, string rg, string cpf, string dtNascimento, string profissao, string grauInstrucao, string prontuario, double peso, double altura, string grupoSanguineo, string estadoPaciente, string logradouro, string bairro, string numero, string cidade, string estado)
        {
            this.mensagem = "";

            DAL.dalPaciente paciente = new DAL.dalPaciente();
            paciente.AdicionarPaciente(nome,rg,cpf,dtNascimento,profissao,grauInstrucao,prontuario,peso,altura,grupoSanguineo,estadoPaciente,logradouro,bairro,numero,cidade,estado);
            if (!paciente.ToString().Equals(""))
            {
                this.mensagem = paciente.ToString();
            }
        }

        public void AtualizarPaciente(string nome, string rg, string cpf, string dtNascimento, string profissao, string grauInstrucao, string prontuario, double peso, double altura, string grupoSanguineo, string estadoPaciente, string logradouro, string bairro, string numero, string cidade, string estado, int idPaciente)
        {
            this.mensagem = "";
            DAL.dalPaciente paciente = new DAL.dalPaciente();
            paciente.AtualizarPaciente(nome,rg,cpf,dtNascimento,profissao,grauInstrucao,prontuario,peso,altura,grupoSanguineo,estadoPaciente,logradouro,bairro,numero,cidade,estado,idPaciente);
            if (!paciente.ToString().Equals(""))
            {
                this.mensagem = paciente.ToString();
            }
        }

        public DataTable PesquisarPaciente(string nome, string cpf)
        {
            DataTable dt = new DataTable();
            DAL.dalPaciente dalPaciente = new DAL.dalPaciente();
            dt = dalPaciente.GetPesquisaPaciente(nome, cpf);
            return dt;
        }

        public DataTable ListaPaciente()
        {
            DataTable dt = new DataTable();
            DAL.dalPaciente paciente = new DAL.dalPaciente();
            dt = paciente.GetListaPacientes();
            return dt;
        }
        #endregion

        #region Manter Exames Areas
        public void CadastrarExameArea(string dsExameArea)
        {
            this.mensagem = "";

            DAL.dalExameArea exame = new DAL.dalExameArea();
            exame.AdicionarArea(dsExameArea);
            if (!exame.ToString().Equals(""))
            {
                this.mensagem = exame.ToString();
            }
        }

        public void AtualizarExameArea(string dsExameArea, int idExameArea)
        {
            this.mensagem = "";
            DAL.dalExameArea exame = new DAL.dalExameArea();
            exame.AtualizarArea(dsExameArea, idExameArea);
                if (!exame.ToString().Equals(""))
            {
                this.mensagem = exame.ToString();
            }
        }

        public DataTable ListaExamesAreas()
        {
            DataTable dt = new DataTable();
            DAL.dalExameArea exame = new DAL.dalExameArea();
            dt = exame.GetListaExamesAreas();
            return dt;
        }

        public DataTable PesquisarExameArea(int idExameArea, string dsExameArea)
        {
            DataTable dt = new DataTable();
            DAL.dalExameArea exame = new DAL.dalExameArea();
            dt = exame.GetPesquisaAreas(idExameArea,dsExameArea);
            return dt;
        }
        #endregion

        #region Manter Exames Tipos
        public void cadastrarExameTipo(string dsExameArea, string estadoExameTipo, int idExameArea)
        {
            this.mensagem = "";

            DAL.dalExameTipo exametipo = new DAL.dalExameTipo();
            exametipo.AdicionarExameTipo(dsExameArea, estadoExameTipo, idExameArea);
            if (!exametipo.ToString().Equals(""))
            {
                this.mensagem = exametipo.ToString();
            }
        }

        public void AtualizarExamesTipos(string dsExameTipo, string estadoExameTipo,int idExameTipo,int idExameArea)
        {
            this.mensagem = "";
            DAL.dalExameTipo exametipo = new DAL.dalExameTipo();
            exametipo.AtualizarExamesTipos(dsExameTipo, estadoExameTipo, idExameTipo,idExameArea);
            if (!exametipo.ToString().Equals(""))
            {
                this.mensagem = exametipo.ToString();
            }
        }

        public DataTable GetExameAreaCombo()
        {
            DAL.dalExameTipo dalExameTipo = new DAL.dalExameTipo();
            dalExameTipo.GetExameAreaCombo();
            return dalExameTipo.dt;
        }
        
        public DataTable ListaExamesTipos()
        {
            DataTable dt = new DataTable();
            DAL.dalExameTipo exametipo = new DAL.dalExameTipo();
            dt = exametipo.GetListaExamesTipos();
            return dt;
        }

        public DataTable PesquisarExamesTipos(int idExameTipo, string dsExameTipo)
        {
            DataTable dt = new DataTable();
            DAL.dalExameTipo exametipo = new DAL.dalExameTipo();
            dt = exametipo.GetPesquisaExamesTipos(idExameTipo, dsExameTipo);
            return dt;
        }
        #endregion

        #region Manter Exames Parametros

        public void cadastarExameParametro(string dsExameParametro, double valorMax, double valorMin, int idExameTipo)
        {
            this.mensagem = "";

            DAL.dalExameParametro dalExameParametro = new DAL.dalExameParametro();
            dalExameParametro.AdicionarExamesParametros(dsExameParametro, valorMax, valorMin,idExameTipo);
            if (!dalExameParametro.ToString().Equals(""))
            {
                this.mensagem = dalExameParametro.ToString();
            }
        }

        public DataTable GetExameTipoCombo()
        {
            DAL.dalExameParametro dalExameParametro = new DAL.dalExameParametro();
            dalExameParametro.GetExameTipoCombo();
            return dalExameParametro.dt;
        }
        
        public void AtualizarExamesParametros(string dsExameParametro, double valorMax, double valorMin, int idExameTipo,int idExameParametro)
        {
            this.mensagem = "";
            DAL.dalExameParametro dalExameParametro = new DAL.dalExameParametro();
            dalExameParametro.AtualizarExamesParametros(dsExameParametro,valorMax, valorMin, idExameTipo, idExameParametro);
            if (!dalExameParametro.ToString().Equals(""))
            {
                this.mensagem = dalExameParametro.ToString();
            }
        }

        public DataTable ListaExamesParametros()
        {
            DataTable dt = new DataTable();
            DAL.dalExameParametro dalExameParametro = new DAL.dalExameParametro();
            dt = dalExameParametro.GetListaExamesParametros();
            return dt;
        }
        /*
        public DataTable PesquisarExamesTipos(int idExameTipo, string dsExameTipo)
        {
            DataTable dt = new DataTable();
            DAL.dalExameTipo exametipo = new DAL.dalExameTipo();
            dt = exametipo.GetPesquisaExamesTipos(idExameTipo, dsExameTipo);
            return dt;
        }*/
        #endregion

    }
}
