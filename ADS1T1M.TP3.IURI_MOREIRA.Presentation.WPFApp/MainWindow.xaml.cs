using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.Repository;
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

        private void buscarAlunoPorMatricula(object sender, RoutedEventArgs e)
        {
            string matricula = matriculaCaixaDeTexto.Text;

            AcessoDadosXml baseDeDados = new AcessoDadosXml();

            Aluno aluno = baseDeDados.retornarAluno(matricula);

            if (aluno == null)
            {
                statusTexto.Text = "Aluno não encontrado";
                mudarCorStatusTexto("inexistente");
            }
            else
            {
                validarStatusAluno(aluno);
            }
        }

        private void validarStatusAluno(Aluno aluno)
        {
            if (aluno.ativo)
            {
                statusTexto.Text = "Aluno liberado";
                exibirInformacoesAluno(aluno);
                mudarCorStatusTexto("liberado");
            }
            else
            {
                statusTexto.Text = "Aluno suspenso";
                exibirInformacoesAluno(aluno);
                mudarCorStatusTexto("suspenso");
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
