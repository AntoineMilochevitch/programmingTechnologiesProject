using PTProject.Presentation.Views;
using PTProject.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PTProject.Presentation.Models;

namespace PTProject.Presentation.ViewModels {
    public class GoodMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IGoodService _goodService;
        private ObservableCollection<Good> _goods; // Change type to Presentation.Models.Good
        private string _newGoodName;
        public ICommand AddGoodCommand { get; private set; }
        public string NewGoodDescription { get; set; }
        public int NewGoodPrice { get; set; }
        public GoodDetailView DetailView { get; set; }

        private Good _selectedGood;
        public int UserId { get; set; }


        private IProcessStateService _processStateService;
        public Good SelectedGood
        {
            get { return _selectedGood; }
            set
            {
                _selectedGood = value;
                OnPropertyChanged("SelectedGood");
            }
        }

        public ICommand ShowGoodDetailsCommand { get; private set; }

        public GoodMasterViewModel(IGoodService goodService, IProcessStateService processStateService)
        {
            _goodService = goodService;
            _processStateService = processStateService;
            LoadGoods();
            AddGoodCommand = new RelayCommand(AddGood);
            ShowGoodDetailsCommand = new RelayCommand(ShowGoodDetails);
        }
        private void ShowGoodDetails(object obj)
        {
            GoodDetailView detailView = new GoodDetailView();
            detailView.DataContext = SelectedGood;
            DetailView = detailView;
            OnPropertyChanged("DetailView");
        }
        private void LoadGoods()
        {
            Goods = new ObservableCollection<Good>(
                _goodService.GetAllGoods().Select(g => new Good
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    Price = g.Price
                }));
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
            int lastGoodId = (_goods.Any()) ? _goods.Max(g => g.Id) : 0;
            int newGoodId = lastGoodId + 1;

            if (!string.IsNullOrEmpty(name)) // Check if the name is not null or empty
            {
                Good good = new Good()
                {
                    Id = newGoodId,
                    Name = name,
                    Description = NewGoodDescription,
                    Price = NewGoodPrice
                };
                _goodService.AddGood(MapToDTO(good));
                LoadGoods();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Good> Goods // Change type to ObservableCollection<Presentation.Models.Good>
        {
            get { return _goods; }
            set
            {
                _goods = value;
                OnPropertyChanged("Goods");
            }
        }

        private GoodDTO MapToDTO(Good good)
        {
            return new GoodDTO
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price,
            };
        }

        private Good MapToEntity(GoodDTO goodDTO)
        {
            return new Good
            {
                Id = goodDTO.Id,
                Name = goodDTO.Name,
                Description = goodDTO.Description,
                Price = goodDTO.Price,
            };
        }
    }
}

