using GerenciadordeTarefas.Models;
using System;

namespace GerenciadordeTarefas.Estruturas
{
    public class ListaTarefas
    {
             private Celula primeiro, ultimo;
            public ListaTarefas()
            {
                primeiro = new Celula();
                ultimo = primeiro;
            }
            public void AdicionarTarefaInicio(Tarefa tarefa)
            {
                Celula temporaria = new Celula(tarefa);
                temporaria.Prox = primeiro.Prox;
                primeiro.Prox = temporaria;
                if (primeiro == ultimo)
                {
                    ultimo = temporaria;
                }
                temporaria = null;
            }
            public void ListarTarefas()
            {
                int cont = 0;
                Console.WriteLine("As Tarefas São:");
                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    cont++;
                    Console.WriteLine(cont + ". " + i.Elemento.titulo + "   |" + i.Elemento.prioridade + "| Status: " + (i.Elemento.status ? "Concluido" : "Pendente"));
                }
            }
            public void RemoverPelaPosicao(int posicao)
            {
                int cont = 0;
                if (posicao == 1)
                {
                    Celula tmp = primeiro.Prox;
                    primeiro.Prox = null;
                    primeiro.Prox = tmp.Prox;
                    tmp = null;
                    tmp.Prox = null;

                }

                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    cont++;
                    if (cont == posicao - 1)
                    {
                        Celula tmp = i.Prox;
                        i.Prox = null;
                        i.Prox = tmp.Prox;
                        tmp = null;
                        break;

                    }

                }
            }
            public Tarefa RemoverTarefaInicio()
            {
                if (ultimo == primeiro)
                    throw new Exception("Lista de Tarefas Vazia");
                Celula temporaria = primeiro;
                primeiro = primeiro.Prox;
                Tarefa element = primeiro.Elemento;
                temporaria.Prox = null;
                temporaria = null;
                return element;
            }

            public void BuscaPorPalavraChave(string chave)
            {
                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    if (i.Elemento.titulo == chave)
                    {
                        Console.WriteLine("O elemento está na lista de tarefas");
                    }
                    else
                    {
                        Console.WriteLine("Não contém na lista");
                    }
                }
            }
            public int TamanhoLista()
            {
                int cont = 0;

                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    cont++;

                }
                return cont;

            }
            public void Ordenar()
            {
                if (primeiro == null || primeiro.Prox == null)
                    return;

                bool trocou;
                do
                {
                    trocou = false;
                    Celula atual = primeiro;

                    while (atual.Prox != null)
                    {
                        if (string.Compare(atual.Elemento.titulo, atual.Prox.Elemento.titulo) > 0)
                        {
                            Tarefa temp = atual.Elemento;
                            atual.Elemento = atual.Prox.Elemento;
                            atual.Prox.Elemento = temp;

                            trocou = true;
                        }

                        atual = atual.Prox;
                    }

                } while (trocou);
            }
            public void OrdenarPorPrioridade()
            {
                if (primeiro.Prox == null)
                {
                    Console.WriteLine("Lista de Tarefas Vazia.");
                    return;
                }
                ListaTarefas TarefasPrioridadeBaixa = new ListaTarefas();
                ListaTarefas TarefasPrioridadeMedia = new ListaTarefas();
                ListaTarefas TarefasPrioridadeAlta = new ListaTarefas();

                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    if (i.Elemento.prioridade == "Baixa")
                    {
                        TarefasPrioridadeBaixa.AdicionarTarefaInicio(i.Elemento);


                    }
                    else if (i.Elemento.prioridade == "Media")
                    {

                        TarefasPrioridadeMedia.AdicionarTarefaInicio(i.Elemento);

                    }
                    else
                    {
                        TarefasPrioridadeAlta.AdicionarTarefaInicio(i.Elemento);
                    }
                }

                RefazendoListaOrdenada(TarefasPrioridadeBaixa, TarefasPrioridadeMedia, TarefasPrioridadeAlta);
            }
            public void RefazendoListaOrdenada(ListaTarefas TarefasPrioridadeBaixa, ListaTarefas TarefasPrioridadeMedia, ListaTarefas TarefasPrioridadeAlta)
            {
                TarefasPrioridadeAlta.Ordenar();
                TarefasPrioridadeMedia.Ordenar();
                TarefasPrioridadeBaixa.Ordenar();


                if (TarefasPrioridadeAlta.TamanhoLista() == 0 && TarefasPrioridadeMedia.TamanhoLista() != 0)
                {
                    primeiro.Prox = null;
                    primeiro.Prox = TarefasPrioridadeMedia.primeiro.Prox;
                    TarefasPrioridadeMedia.ultimo.Prox = TarefasPrioridadeBaixa.primeiro.Prox;

                }
                else if (TarefasPrioridadeMedia.TamanhoLista() == 0 && TarefasPrioridadeAlta.TamanhoLista() != 0)
                {
                    primeiro.Prox = null;
                    primeiro.Prox = TarefasPrioridadeAlta.primeiro.Prox;
                    TarefasPrioridadeAlta.ultimo.Prox = TarefasPrioridadeBaixa.primeiro.Prox;
                }
                else if (TarefasPrioridadeAlta.TamanhoLista() != 0 && TarefasPrioridadeMedia.TamanhoLista() != 0)
                {
                    primeiro.Prox = null;
                    primeiro.Prox = TarefasPrioridadeAlta.primeiro.Prox;
                    TarefasPrioridadeAlta.ultimo.Prox = TarefasPrioridadeMedia.primeiro.Prox;
                    TarefasPrioridadeMedia.ultimo.Prox = TarefasPrioridadeBaixa.primeiro.Prox;

                }
                else
                {
                    primeiro.Prox = null;
                    primeiro.Prox = TarefasPrioridadeBaixa.primeiro.Prox;
                }

            }
            public void MarcarComoConcluida(int posicao)
            {

                int cont = 0;

                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    cont++;
                    if (cont == posicao)
                    {
                        i.Elemento.status = true;
                        break;

                    }


                }

            }
            public void AtualizarTarefa(int posicao)
            {
                int cont = 0;

                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    cont++;
                    if (cont == posicao)
                    {
                        Console.WriteLine("Oque deseja alterar na tarefa: " + i.Elemento.titulo);
                        Console.WriteLine("1.Titulo da Tarefa");
                        Console.WriteLine("2.Prioridade");
                        Console.WriteLine("3.Status");
                        Console.WriteLine("4.Todos os itens da tarefa");
                        int op = int.Parse(Console.ReadLine());
                        while (op < 1 || op > 4)
                        {
                            Console.WriteLine("Valor Invalido Digite novamente uma das opções 1, 2, 3,4 ");
                            op = int.Parse(Console.ReadLine());
                        }
                        switch (op)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Digite o novo titulo para a tarefa");
                                    string titulo = Console.ReadLine();
                                    i.Elemento.titulo = titulo;
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Digite o numero da nova prioridade para a tarefa");
                                    Console.WriteLine("1.Baixa");
                                    Console.WriteLine("2.Media");
                                    Console.WriteLine("3.Alta");
                                    int prioridade = int.Parse(Console.ReadLine());
                                    while (prioridade < 1 || prioridade > 3)
                                    {
                                        Console.WriteLine("Valor Invalido Digite novamente uma das opções 1, 2, 3");
                                        prioridade = int.Parse(Console.ReadLine());
                                    }
                                    if (prioridade == 1)
                                    {
                                        i.Elemento.prioridade = "Baixa";

                                    }
                                    else if (prioridade == 2)
                                    {
                                        i.Elemento.prioridade = "Media";
                                    }
                                    else
                                    {
                                        i.Elemento.prioridade = "Alta";
                                    }

                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Qual o novo status da tarefa");
                                    Console.WriteLine("1.Pendente");
                                    Console.WriteLine("2.Concluido");
                                    int status = int.Parse(Console.ReadLine());
                                    while (status < 1 || status > 2)
                                    {
                                        Console.WriteLine("Valor Invalido Digite novamente uma das opções 1 ou 2");
                                        status = int.Parse(Console.ReadLine());
                                    }
                                    if (status == 1)
                                    {
                                        i.Elemento.status = false;

                                    }
                                    else
                                    {
                                        i.Elemento.status = true;
                                    }

                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Digite o novo titulo para a tarefa");
                                    string titulo = Console.ReadLine();
                                    i.Elemento.titulo = titulo;
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Digite o numero da nova prioridade para a tarefa");
                                    Console.WriteLine("1.Baixa");
                                    Console.WriteLine("2.Media");
                                    Console.WriteLine("3.Alta");
                                    int prioridade = int.Parse(Console.ReadLine());
                                    while (prioridade < 1 || prioridade > 3)
                                    {
                                        Console.WriteLine("Valor Invalido Digite novamente uma das opções 1, 2, 3");
                                        prioridade = int.Parse(Console.ReadLine());
                                    }
                                    if (prioridade == 1)
                                    {
                                        i.Elemento.prioridade = "Baixa";

                                    }
                                    else if (prioridade == 2)
                                    {
                                        i.Elemento.prioridade = "Media";
                                    }
                                    else
                                    {
                                        i.Elemento.prioridade = "Alta";
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Qual o novo status da tarefa");
                                    Console.WriteLine("1.Pendente");
                                    Console.WriteLine("2.Concluido");
                                    int status = int.Parse(Console.ReadLine());
                                    while (status < 1 || status > 2)
                                    {
                                        Console.WriteLine("Valor Invalido Digite novamente uma das opções 1 ou 2");
                                        status = int.Parse(Console.ReadLine());
                                    }
                                    if (status == 1)
                                    {
                                        i.Elemento.status = false;

                                    }
                                    else
                                    {
                                        i.Elemento.status = true;
                                    }


                                    break;
                                }
                        }

                        break;
                    }


                }

            }
            public void RemoverTarefasStatusConcluido()
            {
                ListaTarefas TarefasPendentes = new ListaTarefas();
                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    if (i.Elemento.status == false)
                    {
                        TarefasPendentes.AdicionarTarefaInicio(i.Elemento);
                    }

                }
                primeiro.Prox = null;
                primeiro.Prox = TarefasPendentes.primeiro.Prox;
            }
            public void FiltrarPorStatus(bool verificador)
            {
                int cont = 0;
                Console.WriteLine("As Tarefas São:");
                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    if (i.Elemento.status == verificador)
                    {
                        Console.WriteLine(cont + ". " + i.Elemento.titulo + "   |" + i.Elemento.prioridade + "| Status: " + (i.Elemento.status ? "Concluido" : "Pendente"));
                        cont++;
                    }

                }

            }
        
    }
}
