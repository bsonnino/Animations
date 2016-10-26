using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interactivity;

namespace WpfApplication4
{
    //
    // If you want your Action to target elements other than its parent, extend your class
    // from TargetedTriggerAction instead of from TriggerAction
    //
    public class TransitionControlAction : TargetedTriggerAction<FrameworkElement>
    {
        public TransitionControlAction()
        {
            // Insert code required on object creation below this point.
        }

        protected override void Invoke(object o)
        {
            AnimaControle(Target, Duracao, Tipo);
        }

        public enum TipoAnimacao
        {
            Direita,
            Esquerda,
            Cima,
            Baixo
        }

        [Category("Common Properties")]
        public TipoAnimacao Tipo
        {
            get { return (TipoAnimacao)GetValue(TipoProperty); }
            set { SetValue(TipoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tipo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipoProperty =
            DependencyProperty.Register("Tipo", typeof(TipoAnimacao), typeof(TransitionControlAction));


        [Category("Common Properties")]
        public TimeSpan Duracao
        {
            get { return (TimeSpan)GetValue(DuracaoProperty); }
            set { SetValue(DuracaoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Duracao.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DuracaoProperty =
            DependencyProperty.Register("Duracao", typeof(TimeSpan), typeof(TransitionControlAction), new UIPropertyMetadata(TimeSpan.FromMilliseconds(500)));


        private void AnimaControle(FrameworkElement controle, TimeSpan duração, TipoAnimacao tipo)
        {
            double xFinal = 0;
            double yFinal = 0;
            if (tipo == TipoAnimacao.Esquerda)
                xFinal = -controle.ActualWidth;
            else if (tipo == TipoAnimacao.Direita)
                xFinal = controle.ActualWidth;
            else if (tipo == TipoAnimacao.Cima)
                yFinal = -controle.ActualHeight;
            else if (tipo == TipoAnimacao.Baixo)
                yFinal = controle.ActualHeight;
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