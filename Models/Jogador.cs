using System;
using System.Collections.Generic;
using System.IO;

namespace EPlayersMVC.Models
{
    public class Jogador : EPlayersBase
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }
        public string IdEquipe { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }


        private const string CAMINHO = "Database/equipe.csv";

        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasAsLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(Preparar(j));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Jogador j)
        {
            string[] linha = { Preparar(j) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasAsLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();

                jogador.IdJogador = Int32.Parse(linha[0]);
            }
            
            return jogadores;
        }

    }
}