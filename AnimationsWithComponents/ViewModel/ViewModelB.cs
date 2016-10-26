using GalaSoft.MvvmLight;

namespace AnimationsWithComponents.ViewModel
{
    class ViewModelB : ViewModelBase
    {
        private string texto;

        public string Texto
        {
            get { return texto; }
            set
            {
                texto = value;
                RaisePropertyChanged("Texto");
            }
        }
    }
}
