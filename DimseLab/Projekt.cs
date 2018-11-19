using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DimseLab
{
    class Projekt :INotifyPropertyChanged
    {
        //Skal have en instans af hver deltagere, en liste(OC).'

        public string Name { get; set; }
        public string Description { get; set; }
        

        ObservableCollection<Deltager> deltager = new ObservableCollection<Deltager>();
        ObservableCollection<Dims> dims = new ObservableCollection<Dims>();


        public Projekt(string name, string description, ObservableCollection<Deltager> deltagere, ObservableCollection<Dims> dimser)
        {
            Name = name;
            Description = description;
            deltager = deltagere;
            dims = dimser;
        }

        public ObservableCollection<Deltager> Deltager1
        {
            get { return deltager; }
            set
            {
                deltager = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Dims> Dims
        {
            get { return dims; }
            set
            {
                dims = value; 
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
