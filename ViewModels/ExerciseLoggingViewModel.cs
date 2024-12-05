using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class ExerciseLoggingViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ExerciseLog> Exercises { get; set; }

        public ICommand SaveLogCommand { get; }

        public ExerciseLoggingViewModel()
        {
            // Initialize the collection with some exercises
            Exercises = new ObservableCollection<ExerciseLog>
            {
                new ExerciseLog { Name = "Bench Press" },
                new ExerciseLog { Name = "Pull-Ups" },
                new ExerciseLog { Name = "Squats" },
                new ExerciseLog { Name = "Overhead Press" }
                // Dodajte več vaj po potrebi
            };

            SaveLogCommand = new Command(OnSaveLog);
        }

        private async void OnSaveLog()
        {
            // Implement save logic, e.g., save to database or collection
            // For demonstration, we'll just display an alert
            // Check if all entries have values
            foreach (var exercise in Exercises)
            {
                if (string.IsNullOrWhiteSpace(exercise.Weight) || string.IsNullOrWhiteSpace(exercise.Reps))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Please fill in all fields for {exercise.Name}.", "OK");
                    return;
                }
            }

            // Save the log (implementation depends on your data storage)
            // Example:
            // foreach (var exercise in Exercises)
            // {
            //     await Database.SaveExerciseLogAsync(exercise);
            // }

            await Application.Current.MainPage.DisplayAlert("Success", "Exercise log saved successfully.", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExerciseLog : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private string weight;
        public string Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }

        private string reps;
        public string Reps
        {
            get => reps;
            set
            {
                reps = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
