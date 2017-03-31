using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;

namespace ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.BaseDeDados
{
    interface IAcessoDados
    {
        void adicionarAluno(Aluno aluno);

        Aluno retornarAlunoPorMatricula(string matricula);
    }
}
