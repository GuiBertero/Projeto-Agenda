using System.Collections.Generic;

namespace Agenda.Models
{
    public class Contatos
    {
        private List<Contato> agenda;

        public Contatos()
        {
            agenda = new List<Contato>();
        }

        public List<Contato> getAgenda()
        {
            return agenda;
        }

        public bool adicionar(Contato c)
        {
            if (pesquisar(c) != null)
            {
                return false;
            }

            agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Equals(c))
                {
                    return agenda[i];
                }
            }

            return null;
        }

        public bool alterar(Contato c)
        {
            Contato contato = pesquisar(c);

            if (contato == null)
            {
                return false;
            }

            contato.setNome(c.getNome());
            contato.setEmail(c.getEmail());
            contato.setDtNasc(c.getDtNasc());

            return true;
        }

        public bool remover(Contato c)
        {
            Contato contato = pesquisar(c);

            if (contato == null)
            {
                return false;
            }

            agenda.Remove(contato);
            return true;
        }
    }
}
