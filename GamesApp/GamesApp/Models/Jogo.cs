using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GamesApp.Models
{
    public class Jogo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Produtora { get; set; }

        public string Genero { get; set; }
    }
}
