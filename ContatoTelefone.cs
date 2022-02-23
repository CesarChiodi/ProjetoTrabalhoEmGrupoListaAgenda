using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReexecuçaoTrablalhoEmGrupoLista
{
    internal class ContatoTelefone
    {
        public int Ddd { get; set; }
        public int Telefone { get; set; }
        public string Tipo { get; set; }

        public ContatoTelefone(int ddd, int telefone, string tipo)
        {
            Ddd = ddd;
            Telefone = telefone;
            Tipo = tipo;
        }
        public override string ToString()
        {
            return $"\n({Ddd}) - {Telefone}\nTIPO DE TELEFONE {Tipo}\n_________________\n";
        }
    }
}
