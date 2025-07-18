using System;
using GerenciadordeTarefas.Estruturas;
namespace GerenciadordeTarefas.Models
{
    public class Tarefa
    {
      
            public string titulo { get; set; }
            public string prioridade { get; set; }
            public bool status { get; set; }

            public Tarefa(string titulo, string prioridade)
            {
                this.titulo = titulo;
                this.prioridade = prioridade;
                this.status = false;
            }

     
    }
}
