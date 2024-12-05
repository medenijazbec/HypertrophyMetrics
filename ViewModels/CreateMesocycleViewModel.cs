using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class CreateMesocycleViewModel : BindableObject
    {
        private int numberOfDays;
        public int NumberOfDays
        {
            get => numberOfDays;
            set
            {
                if (numberOfDays != value)
                {
                    numberOfDays = value;
                    OnPropertyChanged();
                    GenerateDays();
                }
            }
        }

        public ObservableCollection<DayViewModel> Days { get; set; } = new ObservableCollection<DayViewModel>();

        public ICommand ContinueCommand { get; }

        public List<int> NumberOfDaysOptions { get; }
        public List<string> DaysOfWeek { get; }
        public List<string> MuscleGroupsList { get; }

        public CreateMesocycleViewModel()
        {
            ContinueCommand = new Command(OnContinue);

            NumberOfDaysOptions = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            DaysOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            MuscleGroupsList = new List<string> 
            { 
                "Chest", 
                "Back", 
                "Triceps", 
                "Biceps", 
                "Shoulders and Traps", 
                "Quads", 
                "Glutes", 
                "Hamstrings", 
                "Calves", 
                "Traps", 
                "Forearms", 
                "Abs" };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void GenerateDays()
        {
            Days.Clear();
            for (int i = 0; i < NumberOfDays; i++)
            {
                Days.Add(new DayViewModel(this));
            }
        }

        private void OnContinue()
        {
            // Logic to proceed to the next step
        }
    }
}
