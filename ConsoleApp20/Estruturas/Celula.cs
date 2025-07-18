using System;
using GerenciadordeTarefas.Models;
namespace GerenciadordeTarefas.Estruturas
{
    public class  Celula
    {
       
            private Tarefa elemento;
            private Celula prox;
            public Celula(Tarefa elemento)
            {
                this.elemento = elemento;
                this.prox = null;
            }
            public Celula()
            {
                this.elemento = new Tarefa("", "");
                this.prox = null;
            }
            public Celula Prox
            {
                get { return prox; }
                set { prox = value; }
            }
            public Tarefa Elemento
            {
                get { return elemento; }
                set { elemento = value; }
            }
        
    }
}
