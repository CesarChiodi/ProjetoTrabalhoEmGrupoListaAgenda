using System;

namespace ReexecuçaoTrablalhoEmGrupoLista
{
    internal class Program 
    {
        static ListaAgenda minhalista = new ListaAgenda();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Menu();

        }
        public static void Menu()
        {

            int opc = -1;
            while (opc != 0)
            {
                Console.WriteLine("++++++++menu++++++++");
                Console.WriteLine("0 - sair");
                Console.WriteLine("1 - cadastrar um novo contato");
                Console.WriteLine("2 - localizar um contato na agenda");
                Console.WriteLine("3 - remover um contato da agenda");
                Console.WriteLine("4 - editar um contato da agenda");
                Console.WriteLine("5 - imprimir contatos da agenda");
                string value = Console.ReadLine();
                bool flag = int.TryParse(value, out opc);

                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine("Insira uma opcao valida");
                }
                else
                {
                    switch (opc)
                    {

                        case 0:
                            Console.WriteLine("PROGRAMA ENCERRADO");
                            break;
                        case 1:
                            Console.Clear();
                            minhalista.Push(LerContato());
                            //minhalista.Ordem();
                            Console.WriteLine("\nCONTATO ADICIONADO");
                            VoltaMenu();
                            break;
                        case 2:
                            Console.Clear();
                            minhalista.Buscar();
                            VoltaMenu();
                            break;
                        case 3:
                            Console.Clear();
                            minhalista.Pop();
                            //minhalista.Ordem();
                            VoltaMenu();
                            break;
                        case 4:
                            Console.Clear();
                            minhalista.Editar();
                            //minhalista.Ordem();
                            VoltaMenu();
                            break;
                        case 5:
                            Console.Clear();
                            minhalista.Print();
                            Console.WriteLine("\nIMPRESSAO CONCLUIDA");
                            VoltaMenu();
                            break;
                    }
                }
            }
        }
        public static Contato LerContato()
        {
            string nome, email, tipo;
            int ddd, telefone, i, quantidadeContatosTelefonicos;


            Console.WriteLine("INFORME O NOME DO CONTATO");
            nome = Console.ReadLine();
            Console.WriteLine("INFORME O E-MAIL DO CONTATO");
            email = Console.ReadLine();
            do
            {

                Console.WriteLine("* QUANTOS TELEFONES SERAO ATRIBUIDOS A ESTE CONTATO? *");
                quantidadeContatosTelefonicos = int.Parse(Console.ReadLine());

                if (quantidadeContatosTelefonicos <= 0)
                {
                    Console.WriteLine("TODO CONTATO DEVE TER NO MINIMO UM TELEFONE\nTENTE NOVAMENTE E INSIRA UM VALOR VALIDO");
                }

            } while (quantidadeContatosTelefonicos <= 0);

            ContatoTelefone[] listaContatoTelefone = new ContatoTelefone[quantidadeContatosTelefonicos];

            for (i = 0; i < quantidadeContatosTelefonicos; i++)
            {

                Console.WriteLine("\nINFORME O DDD DO TELEFONE");
                ddd = int.Parse(Console.ReadLine());
                Console.WriteLine("INFORME O NUMERO TELEFONICO");
                telefone = int.Parse(Console.ReadLine());
                Console.WriteLine("INFORME O TIPO DO TELEFONE DO CONTATO");
                tipo = Console.ReadLine();
                listaContatoTelefone[i] = new ContatoTelefone(ddd, telefone, tipo);
            }

            return new Contato(nome, email, listaContatoTelefone);
        }

        public static void VoltaMenu()
        {
            Console.WriteLine("PRESSIONE QUALQUER TECLA PARA VOLTAR AO MENU");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

    }
}
