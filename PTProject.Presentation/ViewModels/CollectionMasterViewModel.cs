using System;
using PTProject.Service;
using PTProject.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PTProject.Presentation.ViewModels
{
    public class GoodMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private GoodService _goodService;
        private ObservableCollection<PTProject.Data.Good> _goods;
        private string _newGoodName;
        public ICommand AddGoodCommand { get; private set; }

        public GoodMasterViewModel(GoodService goodService)
        {
            _goodService = goodService;
            LoadGoods();
            AddGoodCommand = new RelayCommand(AddGood, CanAddGood);
        }

        private void LoadGoods()
        {
            Goods = new ObservableCollection<PTProject.Data.Good>(_goodService.GetAllGoods());
        }
        public string NewGoodName
        {
            get { return _newGoodName; }
            set
            {
                _newGoodName = value;
                OnPropertyChanged("NewGoodName");
            }
        }

        private void AddGood(object obj)
        {
            string name = obj as string; // Cast the object to string

            if (!string.IsNullOrEmpty(name)) // Check if the name is not null or empty
            {
                Good good = new Good()
                {
                    Name = name,
                };
                _goodService.AddGood(good);
                LoadGoods();
            }
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<PTProject.Data.Good> Goods
        {
            get { return _goods; }
            set
            {
                _goods = value;
                OnPropertyChanged("Goods");
            }
        }

        private bool CanAddGood(object parameter)
        {
            // Code to determine whether a user can be added
            return true;
        }

        public class RelayCommand : ICommand
        {
            private Action<object> execute;
            private Predicate<object> canExecute;

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return canExecute == null ? true : canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                execute(parameter);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }



    }
}
