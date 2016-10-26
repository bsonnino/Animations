using GalaSoft.MvvmLight;

namespace AnimationsWithComponents.ViewModel
{
    public class ViewModelA : ViewModelBase
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
