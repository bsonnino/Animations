using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimationInCode
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

        public enum TipoAnimacao
        {
            Direita,
            Esquerda,
            Cima,
            Baixo
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AnimaControle(gridLogin, TimeSpan.FromMilliseconds(1000), TipoAnimacao.Esquerda);
        }

        private void AnimaControle(UIElement controle, TimeSpan duração, TipoAnimacao tipo)
        {
            double xFinal = 0;
            double yFinal = 0;
            if (tipo == TipoAnimacao.Esquerda)
                xFinal = -ActualWidth;
            else if (tipo == TipoAnimacao.Direita)
                xFinal = ActualWidth;
            else if (tipo == TipoAnimacao.Cima)
                yFinal = -ActualHeight;
            else if (tipo == TipoAnimacao.Baixo)
                yFinal = ActualHeight;
            // cria a transformação e atribui ao controle
            var translate = new TranslateTransform(0, 0);
            controle.RenderTransform = translate;
            // cria a animação e anima-a
            if (tipo == TipoAnimacao.Esquerda || tipo == TipoAnimacao.Direita)
            {
                var da = new DoubleAnimation(0, xFinal, new Duration(duração));
                translate.BeginAnimation(TranslateTransform.XProperty, da);
            }
            else
            {
                var da = new DoubleAnimation(0, yFinal, new Duration(duração));
                translate.BeginAnimation(TranslateTransform.YProperty, da);
            }
        }
    }
}
