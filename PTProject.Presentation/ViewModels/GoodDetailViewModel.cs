using System.ComponentModel;
using PTProject.Presentation.Models;

namespace PTProject.Presentation.ViewModels
{
    public class GoodDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Good _good;
        public Good Good
        {
            get { return _good; }
            set
            {
                _good = value;
                OnPropertyChanged("Good");
            }
        }

        public GoodDetailViewModel(Good good)
        {
            Good = good;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
