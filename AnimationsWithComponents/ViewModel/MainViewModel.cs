using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AnimationsWithComponents.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private ViewModelBase conteudo;

        public ViewModelBase Conteudo
        {
            get { return conteudo; }
            set
            {
                conteudo = value;
                RaisePropertyChanged("Conteudo");
            }
        }

        private ICommand escondeCommand;
        public ICommand EscondeCommand
        {
            get { return escondeCommand ?? (escondeCommand = new RelayCommand(MudaConteudo)); }
        }

        private void MudaConteudo()
        {
            Conteudo = conteudo is ViewModelA ? (ViewModelBase)new ViewModelB() { Texto = "ViewModel B"}
                : (ViewModelBase)new ViewModelA() {Texto = " ViewModel A"};
        }
    }
}