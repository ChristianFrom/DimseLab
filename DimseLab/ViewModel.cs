using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace DimseLab
{
    class ViewModel :INotifyPropertyChanged
    {      
       public Projekt selectedProject;
       public RelayCommand AddProjectRelayCommand { get; set; }
       public RelayCommand AddParticipantRelayCommand { get; set; }
       public RelayCommand AddDimseRelayCommand { get; set; }
       public string projectBox;
       public string descriptionBox;
       public string participantBox;
       public string emailBox;
       public string dimseNameBox;
       public string keywordBox;
       public DateTime lendingDateBox;
       public DateTime dueDateBox;
          
       ObservableCollection<Projekt> projekter = new ObservableCollection<Projekt>();

     
        public ViewModel()
        {           
            projekter.Add(new Projekt("Robot", "Den overtager verden på et tidspunkt.", new ObservableCollection<Deltager>(){new Deltager("Christian", "bitchass@gmail.com")}, new ObservableCollection<Dims>(){new Dims("Skruetrækker", "keywords", DateTime.Today, DateTime.Now)}));
            projekter.Add(new Projekt("PC", "Spil Crysis 4k", new ObservableCollection<Deltager>(){new Deltager("Daniel", "bitch2131ass@gmail.com")}, new ObservableCollection<Dims>(){new Dims("LoddeKolbe", "keywords", DateTime.Today, DateTime.Now)}));
            
            AddProjectRelayCommand = new RelayCommand(AddProject);
            AddParticipantRelayCommand = new RelayCommand(AddParticipant);
            AddDimseRelayCommand = new RelayCommand(AddDimse);
        }

        //Metoder
        public void AddDimse()
        {
            SelectedProject.Dims.Add(new Dims(DimseNameBox, KeywordBox, LendingDateBox, DueDateBox));
        }
        public void AddProject()
        {
            projekter.Add(new Projekt(ProjectBox, DescriptionBox, new ObservableCollection<Deltager>(), new ObservableCollection<Dims>()));
        }
        public void AddParticipant()
        {          
           SelectedProject.Deltager1.Add(new Deltager(ParticipantBox, EmailBox));
        }

        //Properties
        public ObservableCollection<Projekt> Projekter
        {
            get { return projekter; }
            set
            {
                projekter = value; 
                OnPropertyChanged();
            }
        }
        public Projekt SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value; 
                OnPropertyChanged();
            }
        }
        public string ProjectBox
        {
            get { return projectBox; }
            set { projectBox = value; }
        }
        public string DescriptionBox
        {
            get { return descriptionBox; }
            set { descriptionBox = value; }
        }
        public string ParticipantBox
        {
            get { return participantBox; }
            set { participantBox = value; }
        }
        public string EmailBox
        {
            get { return emailBox; }
            set { emailBox = value; }
        }
        public string DimseNameBox
        {
            get { return dimseNameBox; }
            set { dimseNameBox = value; }
        }
        public string KeywordBox
        {
            get { return keywordBox; }
            set { keywordBox = value; }
        }
        public DateTime LendingDateBox
        {
            get { return lendingDateBox; }
            set { lendingDateBox = value; }
        }
        public DateTime DueDateBox
        {
            get { return dueDateBox; }
            set { dueDateBox = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
