using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using System;
using System.IO;

namespace ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.Log
{
    public static class LogAplicacao
    {
        private static string enderecoArquivoLog = "..\\..\\..\\Data\\exporte-alunos-log-de-carga-";

        public static string ArquivoLog
        {
            get { return enderecoArquivoLog; }
        }

        public static void alunoSemAlteracao(Aluno aluno,string dataLog)
        {
            File.AppendAllText(enderecoArquivoLog + dataLog + ".txt", "matricula > " + aluno.matricula + ";" + " nome > " + aluno.nome + "; ativo > " + ((aluno.ativo) ? "1" : "0") + "; OK" + Environment.NewLine);
        }

        public static void alunoComAlteracao(Aluno aluno, string dataLog)
        {
            File.AppendAllText(enderecoArquivoLog + dataLog + ".txt", "matricula > " + aluno.matricula + ";" + " nome > " + aluno.nome + "; alterado : ativo > " + ((aluno.ativo) ? "1" : "0") + Environment.NewLine);
        }

        public static void adicionarNovoAluno(Aluno aluno, string dataLog)
        {
            File.AppendAllText(enderecoArquivoLog + dataLog + ".txt", "matricula > " + aluno.matricula + ";" + " nome > " + aluno.nome + "; ativo > " + ((aluno.ativo) ? "1" : "0") + " Adicionado" + Environment.NewLine);
        }
    }
}
