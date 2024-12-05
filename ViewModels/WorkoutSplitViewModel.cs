using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HypertrophyApp.Pages;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class WorkoutSplitViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WorkoutDay> WorkoutDays { get; set; }

        public ICommand PlanNewMesocycleCommand { get; }

        public WorkoutSplitViewModel()
        {
            WorkoutDays = new ObservableCollection<WorkoutDay>
            {
                new WorkoutDay
                {
                    DayName = "Day 1: Chest & Back",
                    Exercises = new ObservableCollection<string>
                    {
                        "Chest: Bench Press",
                        "Back: Pull-Ups"
                    }
                },
                new WorkoutDay
                {
                    DayName = "Day 2: Legs & Shoulders",
                    Exercises = new ObservableCollection<string>
                    {
                        "Legs: Squats",
                        "Shoulders: Overhead Press"
                    }
                },
                new WorkoutDay
                {
                    DayName = "Day 3: Arms & Core",
                    Exercises = new ObservableCollection<string>
                    {
                        "Arms: Bicep Curls",
                        "Core: Planks"
                    }
                },
                // Dodajte več dni po potrebi
            };

            PlanNewMesocycleCommand = new Command(OnPlanNewMesocycle);
        }

        private async void OnPlanNewMesocycle()
        {
            // Implement logic to plan a new mesocycle
            // For demonstration, we'll display an alert
            await Application.Current.MainPage.DisplayAlert("Info", "Planning a new mesocycle...", "OK");

            // Navigate to PlanMesocyclePage
            await Application.Current.MainPage.Navigation.PushAsync(new PlanMesocyclePage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class WorkoutDay
    {
        public string DayName { get; set; }
        public ObservableCollection<string> Exercises { get; set; }
    }
}
