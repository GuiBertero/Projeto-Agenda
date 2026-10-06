using System;
using System.Collections.Generic;

namespace Agenda.Models
{
    public class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public Contato()
        {
            telefones = new List<Telefone>();
        }

        public Contato(string email, string nome, Data dtNasc)
        {
            this.email = email;
            this.nome = nome;
            this.dtNasc = dtNasc;
            this.telefones = new List<Telefone>();
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public Data getDtNasc()
        {
            return dtNasc;
        }

        public void setDtNasc(Data dtNasc)
        {
            this.dtNasc = dtNasc;
        }

        public int getIdade()
        {
            DateTime hoje = DateTime.Now;

            int idade = hoje.Year - dtNasc.getAno();

            if (hoje.Month < dtNasc.getMes() ||
                (hoje.Month == dtNasc.getMes() &&
                 hoje.Day < dtNasc.getDia()))
            {
                idade--;
            }

            return idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            for (int i = 0; i < telefones.Count; i++)
            {
                if (telefones[i].getPrincipal())
                {
                    return telefones[i].getNumero();
                }
            }

            return "Não informado";
        }

        public List<Telefone> getTelefones()
        {
            return telefones;
        }

        public override string ToString()
        {
            string dados = "";

            dados += "Nome: " + nome + "\n";
            dados += "E-mail: " + email + "\n";
            dados += "Data de nascimento: " + dtNasc + "\n";
            dados += "Idade: " + getIdade() + " anos\n";
            dados += "Telefone principal: " + getTelefonePrincipal();

            return dados;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contato))
            {
                return false;
            }

            Contato contato = (Contato)obj;

            return email == contato.email;
        }

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }
    }
}
