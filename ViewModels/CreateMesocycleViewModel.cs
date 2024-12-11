using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using HypertrophyApp.Models;
using System.Linq;

namespace HypertrophyApp.ViewModels
{
    public class CreateMesocycleViewModel : INotifyPropertyChanged
    {
        private const int MinDays = 2;
        private const int MaxDays = 7;

        public List<string> ExerciseTypesList { get; }
        public ObservableCollection<DayViewModel> Days { get; set; } = new ObservableCollection<DayViewModel>();

        public ICommand ContinueCommand { get; }
        public ICommand AddDayCommand { get; }
        public ICommand RemoveDayCommand { get; }

        // Commands for Custom Exercise
        public ICommand ShowCustomExerciseCommand { get; }
        public ICommand SaveCustomExerciseCommand { get; }
        public ICommand CancelCustomExerciseCommand { get; }

        public List<string> DaysOfWeek { get; }
        public List<string> MuscleGroupsList { get; }

        // Custom Exercise Properties
        private bool isCustomExerciseVisible;
        public bool IsCustomExerciseVisible
        {
            get => isCustomExerciseVisible;
            set
            {
                if (isCustomExerciseVisible != value)
                {
                    isCustomExerciseVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        private Exercise newExercise;
        public Exercise NewExercise
        {
            get => newExercise;
            set
            {
                if (newExercise != value)
                {
                    newExercise = value;
                    OnPropertyChanged();
                    ((Command)SaveCustomExerciseCommand).ChangeCanExecute();
                }
            }
        }

        // Global Exercises Collection
        public ObservableCollection<Exercise> AllExercises { get; set; } = new ObservableCollection<Exercise>();

        public CreateMesocycleViewModel()
        {
            ContinueCommand = new Command(OnContinue);
            AddDayCommand = new Command(OnAddDay, CanAddDay);
            RemoveDayCommand = new Command<DayViewModel>(OnRemoveDay, CanRemoveDay);

            ShowCustomExerciseCommand = new Command(OnShowCustomExercise);
            SaveCustomExerciseCommand = new Command(OnSaveCustomExercise, CanSaveCustomExercise);
            CancelCustomExerciseCommand = new Command(OnCancelCustomExercise);

            DaysOfWeek = new List<string>
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };
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
                "Abs"
            };
            ExerciseTypesList = new List<string>
            {
                "Machine",
                "Barbell",
                "Smith Machine",
                "Dumbbell",
                "Cable",
                "Freemotion",
                "Bodyweight",
                "Only Bodyweight",
                "Loadable Machine Assistance"
            };
            // Initialize with minimum number of days
            for (int i = 0; i < MinDays; i++)
            {
                Days.Add(new DayViewModel(this));
            }

            // Subscribe to Days collection changes to update CanAddMoreDays and RemoveDayCommand
            Days.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(CanAddMoreDays));
                ((Command)AddDayCommand).ChangeCanExecute();
                ((Command<DayViewModel>)RemoveDayCommand).ChangeCanExecute();
            };

            // Initialize AllExercises with predefined exercises
            InitializePredefinedExercises();
        }

        private void InitializePredefinedExercises()
        {
            // Add predefined exercises to AllExercises
            // Chest
            AllExercises.Add(new Exercise { ExerciseName = "Bench Press", MuscleGroup = "Chest" });
            AllExercises.Add(new Exercise { ExerciseName = "Incline Dumbbell Press", MuscleGroup = "Chest" });
            AllExercises.Add(new Exercise { ExerciseName = "Chest Fly", MuscleGroup = "Chest" });

            // Back
            AllExercises.Add(new Exercise { ExerciseName = "Deadlift", MuscleGroup = "Back" });
            AllExercises.Add(new Exercise { ExerciseName = "Pull-ups", MuscleGroup = "Back" });
            AllExercises.Add(new Exercise { ExerciseName = "Bent Over Row", MuscleGroup = "Back" });

            // Triceps
            AllExercises.Add(new Exercise { ExerciseName = "Triceps Pushdown", MuscleGroup = "Triceps" });
            AllExercises.Add(new Exercise { ExerciseName = "Overhead Triceps Extension", MuscleGroup = "Triceps" });
            AllExercises.Add(new Exercise { ExerciseName = "Close Grip Bench Press", MuscleGroup = "Triceps" });

            // Biceps
            AllExercises.Add(new Exercise { ExerciseName = "Barbell Curl", MuscleGroup = "Biceps" });
            AllExercises.Add(new Exercise { ExerciseName = "Hammer Curl", MuscleGroup = "Biceps" });
            AllExercises.Add(new Exercise { ExerciseName = "Preacher Curl", MuscleGroup = "Biceps" });

            // Shoulders and Traps
            AllExercises.Add(new Exercise { ExerciseName = "Military Press", MuscleGroup = "Shoulders and Traps" });
            AllExercises.Add(new Exercise { ExerciseName = "Lateral Raises", MuscleGroup = "Shoulders and Traps" });
            AllExercises.Add(new Exercise { ExerciseName = "Shrugs", MuscleGroup = "Shoulders and Traps" });

            // Quads
            AllExercises.Add(new Exercise { ExerciseName = "Squats", MuscleGroup = "Quads" });
            AllExercises.Add(new Exercise { ExerciseName = "Leg Press", MuscleGroup = "Quads" });
            AllExercises.Add(new Exercise { ExerciseName = "Lunges", MuscleGroup = "Quads" });

            // Glutes
            AllExercises.Add(new Exercise { ExerciseName = "Hip Thrusts", MuscleGroup = "Glutes" });
            AllExercises.Add(new Exercise { ExerciseName = "Glute Bridges", MuscleGroup = "Glutes" });
            AllExercises.Add(new Exercise { ExerciseName = "Cable Kickbacks", MuscleGroup = "Glutes" });

            // Hamstrings
            AllExercises.Add(new Exercise { ExerciseName = "Romanian Deadlift", MuscleGroup = "Hamstrings" });
            AllExercises.Add(new Exercise { ExerciseName = "Leg Curl", MuscleGroup = "Hamstrings" });
            AllExercises.Add(new Exercise { ExerciseName = "Good Mornings", MuscleGroup = "Hamstrings" });

            // Calves
            AllExercises.Add(new Exercise { ExerciseName = "Standing Calf Raise", MuscleGroup = "Calves" });
            AllExercises.Add(new Exercise { ExerciseName = "Seated Calf Raise", MuscleGroup = "Calves" });
            AllExercises.Add(new Exercise { ExerciseName = "Donkey Calf Raise", MuscleGroup = "Calves" });

            // Traps
            AllExercises.Add(new Exercise { ExerciseName = "Barbell Shrugs", MuscleGroup = "Traps" });
            AllExercises.Add(new Exercise { ExerciseName = "Dumbbell Shrugs", MuscleGroup = "Traps" });
            AllExercises.Add(new Exercise { ExerciseName = "Upright Rows", MuscleGroup = "Traps" });

            // Forearms
            AllExercises.Add(new Exercise { ExerciseName = "Wrist Curls", MuscleGroup = "Forearms" });
            AllExercises.Add(new Exercise { ExerciseName = "Reverse Wrist Curls", MuscleGroup = "Forearms" });
            AllExercises.Add(new Exercise { ExerciseName = "Farmer's Walk", MuscleGroup = "Forearms" });

            // Abs
            AllExercises.Add(new Exercise { ExerciseName = "Crunches", MuscleGroup = "Abs" });
            AllExercises.Add(new Exercise { ExerciseName = "Planks", MuscleGroup = "Abs" });
            AllExercises.Add(new Exercise { ExerciseName = "Leg Raises", MuscleGroup = "Abs" });
        }

        // Property to determine if more days can be added
        public bool CanAddMoreDays => Days.Count < MaxDays;

        // Command execution method for adding a day
        private void OnAddDay()
        {
            if (Days.Count < MaxDays)
            {
                Days.Add(new DayViewModel(this));
            }
        }

        // Command can-execute method for adding a day
        private bool CanAddDay()
        {
            return Days.Count < MaxDays;
        }

        // Command execution method for removing a day
        private void OnRemoveDay(DayViewModel day)
        {
            if (day != null && Days.Contains(day) && Days.Count > MinDays)
            {
                Days.Remove(day);
            }
        }

        // Command can-execute method for removing a day
        private bool CanRemoveDay(DayViewModel day)
        {
            return Days.Count > MinDays;
        }

        // Custom Exercise Commands
        private void OnShowCustomExercise()
        {
            NewExercise = new Exercise
            {
                MuscleGroup = string.Empty // User will select from picker
            };
            IsCustomExerciseVisible = true;
        }

        private void OnSaveCustomExercise()
        {
            if (NewExercise != null &&
                !string.IsNullOrWhiteSpace(NewExercise.ExerciseName) &&
                !string.IsNullOrWhiteSpace(NewExercise.MuscleGroup))
            {
                AllExercises.Add(NewExercise);
                IsCustomExerciseVisible = false;
                string addedExerciseName = NewExercise.ExerciseName;
                NewExercise = null;

                // Notify the user that the exercise was added
                MessagingCenter.Send(this, "ExerciseAdded", addedExerciseName);
            }
            else
            {
                // Notify user about incomplete fields
                MessagingCenter.Send(this, "ExerciseAddFailed", "Please fill in all required fields.");
            }
        }

        private bool CanSaveCustomExercise()
        {
            return NewExercise != null &&
                   !string.IsNullOrWhiteSpace(NewExercise.ExerciseName) &&
                   !string.IsNullOrWhiteSpace(NewExercise.MuscleGroup);
        }

        private void OnCancelCustomExercise()
        {
            IsCustomExerciseVisible = false;
            NewExercise = null;
        }

        private void OnContinue()
        {
            // Logic to proceed to the next step
            // For example, navigate to another page or save the data
        }

        #region INotifyPropertyChanged Implementation


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        #endregion
    }
}
