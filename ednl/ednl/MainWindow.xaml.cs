using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ednl
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAL dal = new DAL();
        private Respuesta res;

        int respuestasAcertadas = 0, i = 0;
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            res = dal.getQuestion(rnd.Next(1, 20));
            question.Text = res.pregunta;
        }

        private void v_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (res.respuesta == 1)
            {
                answer.Text = "CORRECTO!";
                answer.Foreground = new SolidColorBrush(Colors.LawnGreen);
                respuestasAcertadas++;
            }
            else
            {
                answer.Text = "ERROR!";
                answer.Foreground = new SolidColorBrush(Colors.Red);
            }

            answer.Visibility = Visibility.Visible;

            c.Visibility = Visibility.Visible;
            f.Visibility = Visibility.Collapsed;
            v.Visibility = Visibility.Collapsed;
        }

        private void f_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (res.respuesta == 0)
            {
                answer.Visibility = Visibility.Visible;
                answer.Text = "CORRECTO!";
                answer.Foreground = new SolidColorBrush(Colors.LawnGreen);
                respuestasAcertadas++;
            }
            else
            {
                answer.Visibility = Visibility.Visible;
                answer.Text = "ERROR!";
                answer.Foreground = new SolidColorBrush(Colors.Red);
            }

            c.Visibility = Visibility.Visible;
            f.Visibility = Visibility.Collapsed;
            v.Visibility = Visibility.Collapsed;
        }

        private void c_Click(object sender, RoutedEventArgs e)
        {
            answer.Visibility = Visibility.Collapsed;

            if (i == 10)
            {
                c.Visibility = Visibility.Collapsed;
                f.Visibility = Visibility.Collapsed;
                v.Visibility = Visibility.Collapsed;
                answer.Text = "Has tenido " + respuestasAcertadas + " preguntas correctas!";
                question.Visibility = Visibility.Collapsed;
                answer.Visibility = Visibility.Visible;
            }
            else
            {
                c.Visibility = Visibility.Collapsed;
                f.Visibility = Visibility.Visible;
                v.Visibility = Visibility.Visible;

                Random rnd = new Random();
                int nextQuestion = rnd.Next(1, 20);

                res = dal.getQuestion(nextQuestion);
                question.Text = res.pregunta;
            }
        }
    }
}
