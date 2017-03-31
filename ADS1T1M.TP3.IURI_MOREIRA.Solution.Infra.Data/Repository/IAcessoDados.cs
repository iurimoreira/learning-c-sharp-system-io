using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using System.Collections.Generic;

namespace ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.Repository
{
    interface IAcessoDados
    {
        List<Aluno> retornarTodosAlunos(string caminhoDoArquivo);

        void adicionarAluno(Aluno aluno);

        Aluno retornarAluno(string matricula);
    }
}
