

using System;

namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos

        public Serie(Genero genero, string titulo, string descricao, int ano, bool excluido) 
        {
            this.Genero = genero;
                this.Titulo = titulo;
                this.Descricao = descricao;
                this.Ano = ano;
                this.Excluido = excluido;
               
        }
                private Genero Genero{get; set;}

        private string Titulo {get; set;}

        private string Descricao {get; set;}

        private int Ano {get; set;}

        private bool Excluido {get; set;}

        //Metodos

        public Serie(int id, Genero genero, string Titulo, string Descricao, int Ano)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano; 
            this.Excluido = false;

         }

         public override string ToString()
         {
             //Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-31
             string retorno ="";
             retorno += "Genero: " + this.Genero + Environment.NewLine; 
             retorno += "Titulo: " + this.Titulo + Environment.NewLine; 
             retorno += "Descricao: " + this.Descricao + Environment.NewLine; 
             retorno += "Ano de inicio: " + this.Ano + Environment.NewLine; 
             retorno += "Excluido: " + this.Excluido;
             return retorno;

         }

         public string retornaTitulo()
         {
             return this.Titulo;
         }
        
         public bool retornaExcluido()
         {
             return this.Excluido;
         }

         public int retornaId()
         {
             return this.id;
         }

         public void Excluir()
         {
             this.Excluido = true;
         }
        
 
    }
}