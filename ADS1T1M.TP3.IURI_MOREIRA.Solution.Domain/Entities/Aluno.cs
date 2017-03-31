using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool? validarSituacaoAluno(string matricula, List<Aluno> alunos)
        {
            bool? situacaoAluno = null;

            foreach (Aluno aluno in alunos)
            {
                if (alunos.Any(a => a.matricula == matricula && a.ativo == true))
                {
                    situacaoAluno = true;
                }
                else if (alunos.Any(a => a.matricula == matricula && a.ativo == false))
                {
                    situacaoAluno = false;
                }
            }

            return situacaoAluno;
        }
    }
}
