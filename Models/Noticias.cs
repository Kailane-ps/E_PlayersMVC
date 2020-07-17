using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersMVC.Interfaces;

namespace E_PlayersMVC.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticias n)
        {
            string[] linhas = { PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
        }

        private string PrepararLinha(Noticias n){
            return $"{n.IdNoticias};{n.Titulo};{n.Texto};{n.Imagem}";
        }
        public void Delete(int IdNoticias)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticias> ReadAll()
        {
            List<Noticias> News = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas)
            {
                string[] linha    = item.Split(";");
                Noticias report   = new Noticias();
                report.IdNoticias = Int32.Parse(linha[0]);
                report.Titulo     = linha[1];
                report.Texto      = linha[2];
                report.Imagem     = linha[3];

                News.Add(report);
            }
            return News;
        }

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas);
        }
    }
}