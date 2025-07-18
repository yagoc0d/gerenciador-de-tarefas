using System;
using GerenciadordeTarefas.Models;
using GerenciadordeTarefas.Estruturas;

namespace GerenciadordeTarefas
{
    class Menu
    {
        ListaTarefas gerenciarTarefas;
        public Menu()
        {
            gerenciarTarefas = new ListaTarefas();
        }
        public void ExibirMenu()
        {

            Console.WriteLine("===================================");
            Console.WriteLine("       GERENCIADOR DE TAREFAS      ");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Adicionar Nova Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Buscar Tarefas por Palavra-Chave");
            Console.WriteLine("4. Filtrar Tarefas por Status");
            Console.WriteLine("5. Marcar Tarefa como Concluída");
            Console.WriteLine("6. Atualizar Tarefa");
            Console.WriteLine("7. Remover Tarefa do Início");
            Console.WriteLine("8. Remover Tarefa por Posição");
            Console.WriteLine("9. Remover Todas as Tarefas Concluídas");
            Console.WriteLine("10. Ordenar Tarefas (A-Z)");
            Console.WriteLine("11. Ordenar Tarefas por Prioridade");
            Console.WriteLine("0. Sair");
            Console.WriteLine("===================================");
            Console.Write("Escolha uma opção: ");
        }
        public void IniciarMenu()
        {
            bool validar = true;

            while (validar)
            {
                ExibirMenu();
                int opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        {
                            Console.WriteLine("Digite o nome da nova tarefa");
                            string nometarefa = Console.ReadLine();
                            Console.WriteLine("Qual a prioridade da tarefa?");
                            Console.WriteLine("1.Baixa");
                            Console.WriteLine("2.Media");
                            Console.WriteLine("3.Alta");
                            int valor = int.Parse(Console.ReadLine());
                            while (valor <= 0 || valor > 3)
                            {
                                Console.WriteLine("Opção invalida , Gentileza digitar uma de opção 1 a 3");
                                valor = int.Parse(Console.ReadLine());
                            }
                            string prioridade = "";
                            switch (valor)
                            {
                                case 1:
                                    {
                                        prioridade = "Baixa";
                                        break;
                                    }
                                case 2:
                                    {
                                        prioridade = "Media";
                                        break;
                                    }
                                case 3:
                                    {
                                        prioridade = "Alta";
                                        break;
                                    }
                            }

                            gerenciarTarefas.AdicionarTarefaInicio(new Tarefa(nometarefa, prioridade));
                            break;
                        }
                    case 2:
                        {
                            gerenciarTarefas.ListarTarefas();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Digite a palavra a qual deseja buscar na lista");
                            String tarefa = Console.ReadLine();
                            gerenciarTarefas.BuscaPorPalavraChave(tarefa);


                            break;
                        }
                    case 4:
                        {

                            Console.WriteLine("Qual filtro deseja aplicar?");
                            Console.WriteLine("1.Tarefas Concluidas");
                            Console.WriteLine("2.Tarefas Pendentes");
                            bool verificador = int.Parse(Console.ReadLine()) == 1 ? true : false;
                            gerenciarTarefas.FiltrarPorStatus(verificador);

                            break;
                        }


                    case 5:
                        {
                            gerenciarTarefas.ListarTarefas();
                            Console.WriteLine("Digite o número da tarefa que deseja marcar como concluida");
                            int numero = int.Parse(Console.ReadLine());
                            int tamanhoMax = gerenciarTarefas.TamanhoLista();
                            while (numero <= 0 || numero > tamanhoMax)
                            {
                                Console.WriteLine($"Opção invalida , Gentileza digitar uma de opção 1 a {numero}");
                                numero = int.Parse(Console.ReadLine());
                            }

                            gerenciarTarefas.MarcarComoConcluida(numero);
                            break;
                        }
                    case 6:
                        {
                            gerenciarTarefas.ListarTarefas();
                            Console.WriteLine("Digite o número da tarefa que deseja Atualizar");
                            int numero = int.Parse(Console.ReadLine());
                            int tamanhoMax = gerenciarTarefas.TamanhoLista();
                            while (numero <= 0 || numero > tamanhoMax)
                            {
                                Console.WriteLine($"Opção invalida , Gentileza digitar uma de opção 1 a {numero}");
                                numero = int.Parse(Console.ReadLine());
                            }
                            gerenciarTarefas.AtualizarTarefa(numero);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Tarefa removida do inicio");
                            Tarefa temp = gerenciarTarefas.RemoverTarefaInicio();
                            break;

                        }
                    case 8:
                        {
                            gerenciarTarefas.ListarTarefas();
                            Console.WriteLine();
                            Console.WriteLine("Digite a posição que deseja remover a tarefa");
                            int posicao = int.Parse(Console.ReadLine());
                            gerenciarTarefas.RemoverPelaPosicao(posicao);

                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("As tarefas concluidas foram excluidas");
                            gerenciarTarefas.RemoverTarefasStatusConcluido();
                            break;

                        }
                    case 10:
                        {
                            Console.WriteLine("Lista de tarefas Ordenada");
                            gerenciarTarefas.Ordenar();
                            gerenciarTarefas.ListarTarefas();
                            break;
                        }
                    case 11:
                        {
                            gerenciarTarefas.OrdenarPorPrioridade();
                            break;
                        }
                    case 0:
                        {
                            validar = false;
                            break;
                        }
                }
                Console.WriteLine();
                gerenciarTarefas.ListarTarefas();


            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Menu menu = new Menu(); 
            menu.IniciarMenu();
        }
    }
}
