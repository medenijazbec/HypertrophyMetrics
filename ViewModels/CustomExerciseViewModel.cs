using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class CustomExerciseViewModel : INotifyPropertyChanged
    {
        private string exerciseName;
        public string ExerciseName
        {
            get => exerciseName;
            set
            {
                exerciseName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ExerciseTypes { get; set; }
        private string selectedExerciseType;
        public string SelectedExerciseType
        {
            get => selectedExerciseType;
            set
            {
                selectedExerciseType = value;
                OnPropertyChanged();
            }
        }

        private string youTubeVideoId;
        public string YouTubeVideoId
        {
            get => youTubeVideoId;
            set
            {
                youTubeVideoId = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> MuscleGroups { get; set; }
        private string selectedMuscleGroup;
        public string SelectedMuscleGroup
        {
            get => selectedMuscleGroup;
            set
            {
                selectedMuscleGroup = value;
                OnPropertyChanged();
            }
        }

        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }

        public CustomExerciseViewModel()
        {
            // Initialize the collections
            ExerciseTypes = new ObservableCollection<string>
            {
                "Strength",
                "Hypertrophy",
                "Endurance",
                "Power",
                "Flexibility"
            };

            MuscleGroups = new ObservableCollection<string>
            {
                "Chest",
                "Back",
                "Legs",
                "Shoulders",
                "Arms",
                "Core"
            };

            // Initialize commands
            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave);
        }

        private async void OnCancel()
        {
            // Implement cancel logic, e.g., navigate back
            // Assuming you have a Navigation stack
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnSave()
        {
            // Implement save logic, e.g., save to database or collection
            // For demonstration, we'll just display an alert
            if (string.IsNullOrWhiteSpace(ExerciseName) || string.IsNullOrWhiteSpace(SelectedExerciseType) || string.IsNullOrWhiteSpace(SelectedMuscleGroup))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            // Save the exercise (implementation depends on your data storage)
            // Example:
            // var newExercise = new Exercise { Name = ExerciseName, Type = SelectedExerciseType, MuscleGroup = SelectedMuscleGroup, YouTubeVideoId = YouTubeVideoId };
            // await Database.SaveExerciseAsync(newExercise);

            await Application.Current.MainPage.DisplayAlert("Success", "Exercise saved successfully.", "OK");

            // Navigate back
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
