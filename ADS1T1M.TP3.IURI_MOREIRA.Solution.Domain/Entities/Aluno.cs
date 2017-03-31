using System;
using System.Collections.Generic;
using System.Linq;

namespace ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities
{
    public class Aluno
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string matricula { get; set; }

        public DateTime dataNascimento { get; set; }

        public string cpf { get; set; }

        public bool ativo { get; set; }
    }
}
