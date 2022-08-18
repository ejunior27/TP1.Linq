using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace TP1.Linq
{
    class Program
    {
        //FONTE DE DADOS
        private static List<Produto> listaProdutos = new()
        {
            new Produto { Id = 2, Nome = "Camiseta", Valor = 52, Ativo = true},
            new Produto { Id = 8, Nome = "Guarda-Chuva", Valor = 19, Ativo = true},
            new Produto { Id = 4, Nome = "Celular", Valor = 8500, Ativo = true },
            new Produto { Id = 3, Nome = "Arroz", Valor = 21, Ativo = true },
            new Produto { Id = 1, Nome = "Geladeira", Valor = 1900, Ativo = true },
            new Produto { Id = 9, Nome = "Panela", Valor = 41, Ativo = true },
            new Produto { Id = 5, Nome = "Chinelo", Valor = 11, Ativo = true },
            new Produto { Id = 7, Nome = "TV", Valor = 2350, Ativo = true },
            new Produto { Id = 6, Nome = "Patins", Valor = 66, Ativo = true },
        };

        static void Main(string[] args)
        {
            /*LINQ
                * Acrônimo para Language Integrated Query, ou Consulta Integrada à Linguagem
                * É um “framework” do .NET que auxilia na escrita de expressões de consulta em C#
                * Consegue trabalhar em cima de várias fontes de dados diferentes*/

            var retorno = RetornaProdutoDto();

            foreach (ProdutoDto prodDto in retorno)
            {
                WriteLine(prodDto.ToString());
            }

            //listaProdutos.Min(prod => prod.Valor);
            //listaProdutos.Max(prod => prod.Valor);
            //listaProdutos.Average(prod => prod.Valor);
            //listaProdutos.Any();
            //listaProdutos.ToArray();

            //WriteLine(retorno);

            listaProdutos.Count(prod => prod.Ativo);

            var resposta = 0 < 1 ? "Ok" : "Não";

            ReadKey();
        }

        public static string RetornaPrimeiroNome()
        {
            return listaProdutos.Select(prod => prod.Nome).FirstOrDefault();
        }

        public static List<ProdutoDto> RetornaProdutoDto()
        {
            return listaProdutos
                .Where(prod => prod.Valor < 50)
                .Select(prod => new ProdutoDto()
                {
                    NomeProduto = prod.Nome,
                    ValorProduto = prod.Valor
                })
                .ToList();
        }

        public static List<Produto> RetornaListaOrdenada()
        {
            return listaProdutos.OrderBy(prod => prod.Nome).ThenBy(prod => prod.Id).ThenBy(prod => prod.Valor).ToList();
        }

        public static List<Produto> RetornaProdutoInicioLetraC(string letraInicial)
        {
            return listaProdutos
                .Where(prod => prod.Nome.ToLower().StartsWith(letraInicial.ToLower()))
                .OrderBy(prod => prod.Id)
                .ToList();
        }
        
        public static Produto RetornaPrimeiroProduto()
        {
            return listaProdutos.FirstOrDefault();
        }

        public static Produto RetornaUltimoProduto()
        {
            return listaProdutos.LastOrDefault();
        }

        public static Produto RetornaUnicoProduto()
        {
            return listaProdutos.SingleOrDefault(prod => prod.Id == 2);
        }
    }

    public class ProdutoDto
    {
        public string NomeProduto { get; set; }

        public decimal ValorProduto { get; set; }

        public override string ToString()
        {
            return $"Nome: {NomeProduto} | Valor: {ValorProduto}";
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Nome: {Nome} | Valor: R$ {Valor}";
        }
    }

    
}
