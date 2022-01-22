using System;
using Dio.Series;

namespace DIO.Series 
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
         static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                    ListarSerie();
                    break;
                    case "2":
                    InserirSerie();
                    break;
                    case "3":
                   AtualizarSerie();
                    break;
                    case "4":
                   ExcluirSerie();
                    break;
                    case "5":
                   VisualizarSerie();
                    break;
                    case "C":
                   Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();


                }

                OpcaoUsuario = ObterOpcaoUsuario();

            }

             Console.WriteLine("Obrigado por Utilizar nossos Serviços.");
             Console.ReadLine();

            

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var Serie = repositorio.RetornoPorId(indiceSerie);

            Console.WriteLine(Serie);

        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da Série");
            int indiceSeries = int.Parse(Console.ReadLine());

            foreach (int I in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", I, Enum.GetName(typeof(Genero), I));

            }
            Console.Write("Digite o genero entre as opções a cima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie AtualizarSerie = new Serie(id: indiceSeries,
                                          genero: (Genero)entradaGenero,
                                          Titulo: entradaTitulo,
                                          Ano: entradaAno,
                                          Descricao: entradaDescricao);
            repositorio.Atualiza(indiceSeries, AtualizarSerie);

        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série Cadartrada.");
                return;
            }
            foreach(var Serie in lista)
            {
               var Excluido = Serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2} ", Serie.retornaId(), Serie.retornaTitulo(), (Excluido ? "Excluido" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int I in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", I , Enum.GetName(typeof(Genero), I));

            }
            Console.Write("Digite o genero entre as opções a cima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie  novaSerie  =  new  Serie(id: repositorio.ProximoId(),
                                              genero: (Genero)entradaGenero,
                                              Titulo: entradaTitulo,
                                              Ano:entradaAno,
                                              Descricao:entradaDescricao);
             repositorio.Insere(novaSerie);
        
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries ao Seu Dispor");
            Console.WriteLine("Informe a Opção Desejada");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
