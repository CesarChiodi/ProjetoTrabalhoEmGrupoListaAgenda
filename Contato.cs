using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReexecuçaoTrablalhoEmGrupoLista
{
    internal class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public ContatoTelefone[] Telefones { get; set; }
        public Contato Prox { get; set; }
        public Contato Ant { get; set; } 


        public Contato(string nome, string email, ContatoTelefone[] telefone)
        {
            Nome = nome;
            Email = email;
            Telefones = telefone;
        }
        public string GetPhone()
        {
            return $"+++ DADOS_DO_CONTATO +++\nNOME: {Nome}\nE-MAIL: {Email}\n++ TELEFONE ++{Tel()}";
        }
        public string Tel()
        {
            string aux = "";
            for (int i = 0; i < Telefones.Length; i++)
            {
                aux += Telefones[i].ToString();
            }
            return aux;
        }
    }
}
