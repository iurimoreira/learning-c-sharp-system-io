using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.BaseDeDados;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ADS1T1M.TP3.IURI_MOREIRA.Presentation.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buscarMatricula(object sender, RoutedEventArgs e)
        {
            string matricula = matriculaCaixaDeTexto.Text;

            XmlAlunos baseDeDados = new XmlAlunos();

            List<Aluno> alunos = baseDeDados.retornarTodosAlunos(baseDeDados.XmlOriginal);

            Aluno aluno = null;
         
            bool? situacaoAluno = Aluno.validarSituacaoAluno(matricula, alunos);

            if (!situacaoAluno.HasValue)
            {
                statusTexto.Text = "Aluno não encontrado";
                mudarCorStatusTexto("inexistente");
            }
            else if (situacaoAluno == false)
            {
                statusTexto.Text = "Aluno suspenso";
                aluno = baseDeDados.retornarAlunoPorMatricula(matricula);
                exibirInformacoesAluno(aluno);
                mudarCorStatusTexto("suspenso");
            }
            else
            {
                statusTexto.Text = "Aluno liberado";
                aluno = baseDeDados.retornarAlunoPorMatricula(matricula);
                exibirInformacoesAluno(aluno);
                mudarCorStatusTexto("liberado");
            }    
        }

        private void exibirInformacoesAluno(Aluno aluno)
        {
            nomeTexto.Text = aluno.nome;
            matriculaTexto.Text = aluno.matricula;
            dataNascimentoTexto.Text = aluno.dataNascimento.ToString("dd/MM/yyyy");
            cpfTexto.Text = aluno.cpf;
        }

        private void mudarCorStatusTexto(string status)
        {
            statusTexto.Visibility = Visibility.Visible;

            switch (status)
            {
                case "inexistente":
                    statusTexto.Background = Brushes.DodgerBlue;
                    break;
                case "liberado":
                    statusTexto.Background = Brushes.Lime;
                    break;
                case "suspenso":
                    statusTexto.Background = Brushes.Red;
                    break;
                default:
                    break;
            }
        }

        private void matricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            nomeTexto.Text = "";
            matriculaTexto.Text = "";
            cpfTexto.Text = "";
            dataNascimentoTexto.Text = "";

            statusTexto.Visibility = Visibility.Hidden;
        }
    }
}
