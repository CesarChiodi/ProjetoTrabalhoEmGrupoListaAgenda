using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReexecuçaoTrablalhoEmGrupoLista
{
    internal class ListaAgenda
    {
        public Contato Inicio { get; set; }
        public Contato Fim { get; set; }
        public bool Vazia()
        {
            if ((Inicio == null) && (Fim == null))
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (Vazia())
            {
                Console.WriteLine("A FILA DE CONTATOS ESTA VAZIA\n");
            }
            else
            {
                Contato aux = Inicio;
                do
                {
                    Console.WriteLine(aux.GetPhone());
                    aux = aux.Prox;
                    Console.ReadKey();

                } while (aux != null);
            }
        }
        public Contato Push(Contato aux)
        {
            if (Vazia())
            {
                Inicio = aux;
                Fim = aux;
            }
            else if (aux.Nome.CompareTo(Fim.Nome) >= 0)
            {
                Fim.Prox = aux;
                Fim = aux;

            }
            else if (aux.Nome.CompareTo(Inicio.Nome) < 0)
            {
                aux.Prox = Inicio;
                Inicio = aux;
            }
            else
            {
                aux.Ant = Inicio;
                do
                {
                    if (aux.Nome.CompareTo(aux.Ant.Prox.Nome) < 0)
                    {
                        aux.Prox = aux.Ant.Prox;
                        aux.Ant.Prox = aux;
                        break;
                    }
                    aux.Ant = aux.Ant.Prox;
                } while (aux.Ant.Prox != null);
            }
            return aux;
        }
        //public void Push(Contato novoContato)
        //{
        //    if(Vazia())
        //    {
        //        Fim = novoContato;
        //        Inicio = novoContato;
        //    }
        //    else
        //    {
        //        Fim.Prox = novoContato;
        //        Fim = novoContato;
        //    }
        //}
        //public void Ordem()
        //{
        //    Contato referencia;
        //    for (referencia = Inicio; referencia != null; referencia = referencia.Prox)
        //    {
        //        Contato comparacao;
        //        for(comparacao = referencia.Prox; comparacao != null; comparacao = comparacao.Prox)
        //        {
        //            Contato aux;
        //            if(referencia.Nome.CompareTo(comparacao.Nome) > 0)
        //            {
        //                aux = referencia;
        //                referencia = comparacao;
        //                referencia.Prox = aux;
        //            }
        //        }
        //    }
        //}
        public void Pop()
        {
            string nome = Buscar();
            Contato aux = Inicio;

            if (aux.Nome == nome)
            {
                Inicio = aux.Prox;
            }
            else
            {
                do
                {
                    if (nome == aux.Prox.Nome && aux.Prox.Prox == null)
                    {
                        Fim = aux;
                        aux.Prox = null;

                    }
                    else if (nome == aux.Ant.Prox.Nome)
                    {
                        aux = aux.Prox;
                        aux.Prox = aux.Prox.Prox;
                        break;
                    }
                    aux = aux.Prox;

                } while (aux != null);

                Console.WriteLine("\nCONTATO REMOVIDO");
            }
        }
        public string Buscar()
        {
            string nome1 = "";
            if (Vazia())
            {
                Console.WriteLine("A FILA DE CONTATOS ESTA VAZIA\n");
            }
            else
            {
                Console.WriteLine("INFORME O NOME PARA BUSCA");
                nome1 = Console.ReadLine();
                Contato aux = Inicio;
                if (nome1 == null)
                {
                    Console.WriteLine("NOME DIGITADO NÃO DEVE SER VAZIO");
                }
                else
                {
                    do
                    {
                        if (nome1.ToLower() == aux.Nome)
                        {
                            Console.WriteLine(aux.GetPhone());
                        }
                        aux = aux.Prox;
                    } while (aux != null);
                }
                Console.WriteLine("FIM DA Busca");
            }
            return nome1;
        }
        public void Editar()
        {
            if (Vazia())
            {
                Console.WriteLine("A FILA DE CONTATOS ESTA VAZIA\n");
            }
            else
            {
                Console.WriteLine("O CONTATO SELECIONADO SERA COMPLETAMENTE EDITADO");
                Console.ReadKey();
                Pop();
                Console.Clear();
                Console.WriteLine("++ EDICAO INICIADA ++");
                Push(Program.LerContato());
                Console.WriteLine("\nCONTATO EDITADO");
            }
        }
        public int Qtd()
        {
            Contato ctt = Inicio;
            int cont = 0;
            if (Vazia())
            {
                return 0;
            }
            else
            {
                do
                {
                    cont++;
                    ctt = ctt.Prox;

                } while (ctt != null);
                return cont;
            }
        }
    }
}
