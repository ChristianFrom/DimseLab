using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DimseLab
{
    class Projekt :INotifyPropertyChanged
    {
        //Skal have en instans af hver deltagere, en liste(OC).'

        public string Name { get; set; }
        public string Description { get; set; }
        public ViewModel MpViewModel;

        ObservableCollection<Deltager> deltager = new ObservableCollection<Deltager>();
        ObservableCollection<Dims> dims = new ObservableCollection<Dims>();


        public Projekt(string name, string description, ObservableCollection<Deltager> deltagere, ObservableCollection<Dims> dimser)
        {
            Name = name;
            Description = description;
            deltager = deltagere;
            dims = dimser;
        }

        public Projekt()
        {
            
        }


        //Metoder
        public void AddDimse()
        {
            MpViewModel.SelectedProject.Dims.Add(new Dims(MpViewModel.DimseNameBox, MpViewModel.KeywordBox, MpViewModel.LendingDateBox, MpViewModel.DueDateBox));
        }
        public void AddProject()
        {
            MpViewModel.Projekter.Add(new Projekt(MpViewModel.ProjectBox, MpViewModel.DescriptionBox, new ObservableCollection<Deltager>(), new ObservableCollection<Dims>()));
        }
        public void AddParticipant()
        {          
            MpViewModel.SelectedProject.Deltager1.Add(new Deltager(MpViewModel.ParticipantBox, MpViewModel.EmailBox));
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