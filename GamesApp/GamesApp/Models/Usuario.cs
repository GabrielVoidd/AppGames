using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesApp.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Nickname { get; set; }

        public string Senha { get; set; }

        public bool IsAdmin { get; set; }
    }
}
