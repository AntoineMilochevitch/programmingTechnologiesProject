using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Collection.FullClient.ViewModel
{
    public class Maintenance : INotifyPropertyChanged
    {
        private PTProject.Service.EventsService serviceClient =
            new PTProject.Service.EventsService();
        public Maintenance() 
        {
            this.RefreshEvents();
        }
        private void RefreshEvents()
        {
            this.serviceClient.GetEvent += (s, e) =>
            {
                this.Events = e.Result;
            };
            this.serviceClient.GetEventsAsync();
        }
        private IEnumerable<Events> events;
        public IEnumerable<Events> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                this.OnPropertyChanged("Events");
            }
        }
        private void OnPropertyChanged (string propertyName)
        {
            if (this.PropertyChanged!=null) 
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
