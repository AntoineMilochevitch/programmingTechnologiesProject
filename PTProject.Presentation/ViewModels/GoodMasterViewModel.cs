using PTProject.Presentation.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace PTProject.Presentation.ViewModels
{
    public class GoodMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private GoodModel _goodModel;
        private ObservableCollection<Good> _goods;
        private string _newGoodName;
        public ICommand AddGoodCommand { get; private set; }
        public string NewGoodDescription { get; set; }
        public int NewGoodPrice { get; set; }
        public GoodDetailViewModel DetailViewModel { get; set; }

        public int UserId { get; set; }

        private Good _selectedGood;
        public Good SelectedGood
        {
            get { return _selectedGood; }
            set
            {
                _selectedGood = value;
                OnPropertyChanged("SelectedGood");
                ShowGoodDetails();
            }
        }

        public GoodMasterViewModel(GoodModel goodModel)
        {
            _goodModel = goodModel;
            LoadGoods();
            AddGoodCommand = new RelayCommand(AddGood);
        }

        private void LoadGoods()
        {
            Goods = new ObservableCollection<Good>(_goodModel.GetAllGoods());
        }

        public ObservableCollection<Good> Goods
        {
            get { return _goods; }
            set
            {
                _goods = value;
                OnPropertyChanged("Goods");
            }
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
            string name = obj as string;

            if (!string.IsNullOrEmpty(name))
            {
                int lastGoodId = (_goods.Any()) ? _goods.Max(g => g.Id) : 0;
                int newGoodId = lastGoodId + 1;

                Good good = new Good
                {
                    Id = newGoodId,
                    Name = name,
                    Description = NewGoodDescription,
                    Price = NewGoodPrice
                };
                _goodModel.AddGood(good);
                LoadGoods();
            }
        }

        private void ShowGoodDetails()
        {
            DetailViewModel = new GoodDetailViewModel(SelectedGood);
            OnPropertyChanged("DetailViewModel");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
