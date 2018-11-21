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
using Windows.UI.Xaml.Controls;
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
       public DateTime LendingDateBox;
       public DateTime DueDateBox;
       public int projectNumber = 0;
       
       
    
       
     
       public Projekt EmptyProjekt = new Projekt();
          
       ObservableCollection<Projekt> projekter = new ObservableCollection<Projekt>();

     
        public ViewModel()
        {   selectedProject = new Projekt();
            projekter.Add(new Projekt("Robot", GiveNumber(), "Den overtager verden på et tidspunkt.", new ObservableCollection<Deltager>(){new Deltager("Christian", "bitchass@gmail.com")}, new ObservableCollection<Dims>(){new Dims("Skruetrækker", "keywords", DateTime.Now, DateTime.Today)}, DateTime.Now.ToString("d"), _projektEndDate));
            projekter.Add(new Projekt("PC", GiveNumber(), "Spil Crysis 4k", new ObservableCollection<Deltager>(){new Deltager("Daniel", "bitch2131ass@gmail.com")}, new ObservableCollection<Dims>(){new Dims("LoddeKolbe", "keywords", DateTime.Now, DateTime.Today)}, DateTime.Now.ToString("d"), _projektEndDate));

            EmptyProjekt.MpViewModel = this;
            AddProjectRelayCommand = new RelayCommand(EmptyProjekt.AddProject);
            AddParticipantRelayCommand = new RelayCommand(EmptyProjekt.AddParticipant);
            AddDimseRelayCommand = new RelayCommand(EmptyProjekt.AddDimse);
        }

       

        public int GiveNumber()
        {
            ProjectNumber++;
            return ProjectNumber;
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
        
        public int ProjectNumber
        {
            get { return projectNumber; }
            set { projectNumber = value; }
        }

  

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}