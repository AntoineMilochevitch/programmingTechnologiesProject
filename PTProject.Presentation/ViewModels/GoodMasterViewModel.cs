using PTProject.Presentation.ViewModels;
using PTProject.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

public class GoodMasterViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private GoodService _goodService;
    private ObservableCollection<PTProject.Presentation.Models.Good> _goods; // Change type to Presentation.Models.Good
    private string _newGoodName;
    public ICommand AddGoodCommand { get; private set; }

    public string NewGoodDescription { get; set; }
    public int NewGoodPrice { get; set; }

    private PTProject.Presentation.Models.Good _selectedGood;
    public PTProject.Presentation.Models.Good SelectedGood
    {
        get { return _selectedGood; }
        set
        {
            _selectedGood = value;
            OnPropertyChanged("SelectedGood");
        }
    }

    public GoodMasterViewModel(GoodService goodService)
    {
        _goodService = goodService;
        LoadGoods();
        AddGoodCommand = new RelayCommand(AddGood);
    }

    private void LoadGoods()
    {
        Goods = new ObservableCollection<PTProject.Presentation.Models.Good>(
            _goodService.GetAllGoods().Select(g => new PTProject.Presentation.Models.Good
            {
                GoodId = g.GoodId,
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
        int lastGoodId = (_goods.Any()) ? _goods.Max(g => g.GoodId) : 0;
        int newGoodId = lastGoodId + 1;

        if (!string.IsNullOrEmpty(name)) // Check if the name is not null or empty
        {
            PTProject.Data.Good good = new PTProject.Data.Good()
            {
                GoodId = newGoodId,
                Name = name,
                Description = NewGoodDescription,
                Price = NewGoodPrice
            };
            _goodService.AddGood(good);
            LoadGoods();
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public ObservableCollection<PTProject.Presentation.Models.Good> Goods // Change type to ObservableCollection<Presentation.Models.Good>
    {
        get { return _goods; }
        set
        {
            _goods = value;
            OnPropertyChanged("Goods");
        }
    }
}
