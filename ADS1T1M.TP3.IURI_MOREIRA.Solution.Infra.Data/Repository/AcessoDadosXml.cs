using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.Repository
{
    public class AcessoDadosXml : IAcessoDados
    {
        private string enderecoXmlOriginal = @"..\..\..\XML-Original\exporte-alunos-01.xml";
        private string enderecoXmlNovosAlunos = @"..\..\..\Data\exporte-alunos.xml";
       
        public string XmlOriginal
        {
            get { return enderecoXmlOriginal; }
        }

        public string XmlNovosAlunos
        {
            get { return enderecoXmlNovosAlunos; }
        }

        public List<Aluno> retornarTodosAlunos(string caminhoDoArquivo)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(@caminhoDoArquivo);

            XmlNodeList xnList = xmlDoc.GetElementsByTagName("aluno");

            Aluno aluno = null;
            var alunos = new List<Aluno>();

            foreach (XmlNode xn in xnList)
            {
                aluno = new Aluno();
                aluno.matricula = xn["matricula"].InnerText;
                aluno.nome = xn["nome"].InnerText;

                string dataNascimentoString = xn["datadenascimento"].InnerText;
                DateTime dataNascimento = Convert.ToDateTime(dataNascimentoString);
                aluno.dataNascimento = dataNascimento;

                aluno.cpf = xn["cpf"].InnerText;

                string ativoString = xn["ativo"].InnerText;
                aluno.ativo = (ativoString == "1") ? true : false;

                alunos.Add(aluno);
            }

            return alunos;
        }

        public void adicionarAluno(Aluno aluno)
        {
            XElement elementoXml = new XElement("aluno");

            elementoXml.Add(new XElement("matricula", aluno.matricula));
            elementoXml.Add(new XElement("nome", aluno.nome));
            elementoXml.Add(new XElement("datadenascimento", aluno.dataNascimento.ToString("dd/MM/yyyy")));
            elementoXml.Add(new XElement("cpf", aluno.cpf));
            elementoXml.Add(new XElement("ativo", (aluno.ativo) ? "1" : "0"));

            XElement xml = XElement.Load(enderecoXmlOriginal);
            xml.Add(elementoXml);
            xml.Save(enderecoXmlOriginal);
        }

        public Aluno retornarAluno(string matricula)
        {
            List<Aluno> todosAlunos = retornarTodosAlunos(enderecoXmlOriginal);

            foreach (Aluno aluno in todosAlunos)
            {
                if (aluno.matricula == matricula)
                {
                    return aluno;
                }
            }

            return null;
        }

        public void alterarNomeXml(string dataLog)
        {
            string novoNomeXml = @"..\..\..\Data\exporte-alunos" + "-" + dataLog + ".xml";
            File.Move(enderecoXmlNovosAlunos, novoNomeXml);
        }
    }
}
