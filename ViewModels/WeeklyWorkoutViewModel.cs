using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using HypertrophyApp.Models;

namespace HypertrophyApp.ViewModels
{
    public class WeeklyWorkoutViewModel : INotifyPropertyChanged
    {
        private string currentDay;
        public string CurrentDay
        {
            get => currentDay;
            set
            {
                currentDay = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> DaysOfWeek { get; set; }

        private string selectedDay;
        public string SelectedDay
        {
            get => selectedDay;
            set
            {
                selectedDay = value;
                OnPropertyChanged();
                LoadExercisesForDay();
            }
        }

        public ObservableCollection<Exercise> Exercises { get; set; }

        // Sample data, in real app this would come from database or API
        private Dictionary<string, List<Exercise>> exercisesByDay;

        public ICommand ShowDayPickerCommand { get; }
        public ICommand LogSetCommand { get; }

        public WeeklyWorkoutViewModel()
        {
            DaysOfWeek = new ObservableCollection<string>
            {
                "Week 1 Day 1 - Monday",
                "Week 1 Day 2 - Tuesday",
                "Week 1 Day 3 - Wednesday",
                "Week 1 Day 4 - Thursday",
                "Week 1 Day 5 - Friday",
                "Week 1 Day 6 - Saturday",
                "Week 1 Day 7 - Sunday",
                "Week 2 Day 1 - Monday",
                "Week 2 Day 2 - Tuesday",
                "Week 2 Day 3 - Wednesday",
                "Week 2 Day 4 - Thursday",
                "Week 2 Day 5 - Friday",
                "Week 2 Day 6 - Saturday",
                "Week 2 Day 7 - Sunday",
                // Add more weeks as needed
            };

            // Initialize sample exercises
            exercisesByDay = new Dictionary<string, List<Exercise>>
            {
                {
                    "Week 2 Day 5 - Saturday", new List<Exercise>
                    {
                        new Exercise
                        {
                            MuscleGroup = "Glutes",
                            ExerciseName = "Deadlift",
                            Equipment = "Barbell",
                            Instructions = "Perform deadlifts with proper form.",
                            Sets = new ObservableCollection<ExerciseSet>
                            {
                                new ExerciseSet { Weight = "100", Reps = "5", RIR = "2" },
                                new ExerciseSet { Weight = "105", Reps = "5", RIR = "2" },
                                new ExerciseSet { Weight = "110", Reps = "5", RIR = "2" },
                            }
                        },
                        new Exercise
                        {
                            MuscleGroup = "Hamstrings",
                            ExerciseName = "Romanian Deadlift",
                            Equipment = "Barbell",
                            Instructions = "Keep your back straight and lower the bar.",
                            Sets = new ObservableCollection<ExerciseSet>
                            {
                                new ExerciseSet { Weight = "80", Reps = "8", RIR = "1" },
                                new ExerciseSet { Weight = "85", Reps = "8", RIR = "1" },
                                new ExerciseSet { Weight = "90", Reps = "8", RIR = "1" },
                            }
                        },
                        new Exercise
                        {
                            MuscleGroup = "Calves",
                            ExerciseName = "Standing Calf Raise",
                            Equipment = "Calf Raise Machine",
                            Instructions = "Raise your heels as high as possible.",
                            Sets = new ObservableCollection<ExerciseSet>
                            {
                                new ExerciseSet { Weight = "50", Reps = "15", RIR = "0" },
                                new ExerciseSet { Weight = "55", Reps = "15", RIR = "0" },
                                new ExerciseSet { Weight = "60", Reps = "15", RIR = "0" },
                            }
                        }
                    }
                },
                // Add more days and exercises as needed
            };

            Exercises = new ObservableCollection<Exercise>();

            // Initialize commands
            ShowDayPickerCommand = new Command(OnShowDayPicker);
            LogSetCommand = new Command<ExerciseSet>(OnLogSet);
        }

        private async void OnShowDayPicker()
        {
            // Implement a day picker, for simplicity using DisplayActionSheet
            string action = await Application.Current.MainPage.DisplayActionSheet("Select Day", "Cancel", null, DaysOfWeek.ToArray());

            if (action != "Cancel" && !string.IsNullOrEmpty(action))
            {
                SelectedDay = action;
            }
        }

        private void LoadExercisesForDay()
        {
            Exercises.Clear();

            if (exercisesByDay.ContainsKey(SelectedDay))
            {
                foreach (var exercise in exercisesByDay[SelectedDay])
                {
                    Exercises.Add(exercise);
                }
            }
            else
            {
                // If no exercises for the selected day, optionally show a message
                // For example, you could add a dummy exercise indicating no exercises
                // Or simply leave the list empty
            }

            // Update CurrentDay
            CurrentDay = SelectedDay;
        }

        private async void OnLogSet(ExerciseSet set)
        {
            // Implement logging logic, npr. shranjevanje v bazo
            await Application.Current.MainPage.DisplayAlert("Set Logged", $"Weight: {set.Weight} lbs, Reps: {set.Reps}", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
