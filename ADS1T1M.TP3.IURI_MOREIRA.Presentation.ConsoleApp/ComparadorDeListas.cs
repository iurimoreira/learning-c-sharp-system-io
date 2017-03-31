using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.BaseDeDados;
using ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADS1T1M.TP3.IURI_MOREIRA.Presentation.ConsoleApp
{
    class ComparadorDeListas
    {
        public void compararListaDeAlunos()
        {
            XmlAlunos baseDeDados = new XmlAlunos();

            List<Aluno> alunosOriginais = baseDeDados.retornarTodosAlunos(baseDeDados.XmlOriginal);
            List<Aluno> alunosNovos = baseDeDados.retornarTodosAlunos(baseDeDados.XmlNovosAlunos);

            string dataLog = DateTime.Now.ToString("yyyyMMddHHmm");

            foreach (Aluno aluno in alunosNovos)
            {
                if (alunosOriginais.Any(a => a.matricula == aluno.matricula && a.ativo == aluno.ativo))
                {
                    Console.WriteLine("O aluno " + aluno.nome + " permanece " + ((aluno.ativo) ? "ativo\n" : "inativo\n"));

                    LogAplicacao.alunoSemAlteracao(aluno, dataLog);
                }
                else if (alunosOriginais.Any(a => a.matricula == aluno.matricula && a.ativo != aluno.ativo))
                {
                    Console.WriteLine("O aluno " + aluno.nome + " mudou o seu estado. Agora ele se encontra " + ((aluno.ativo) ? "ativo\n" : "inativo\n"));

                    LogAplicacao.alunoComAlteracao(aluno, dataLog);
                }
                else
                {
                    baseDeDados.adicionarAluno(aluno);

                    Console.WriteLine(aluno.nome + " adicionado na lista.\n");

                    LogAplicacao.adicionarNovoAluno(aluno, dataLog);
                }
            }

            baseDeDados.alterarNomeXml(dataLog);

            Console.ReadKey();
        }
    }
}
