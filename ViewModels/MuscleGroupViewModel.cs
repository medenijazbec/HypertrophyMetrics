using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HypertrophyApp.Models;
using System.Linq;

namespace HypertrophyApp.ViewModels
{
    public class MuscleGroupViewModel : BindableObject
    {
        private string selectedMuscleGroup;
        public string SelectedMuscleGroup
        {
            get => selectedMuscleGroup;
            set
            {
                if (selectedMuscleGroup != value)
                {
                    selectedMuscleGroup = value;
                    OnPropertyChanged();
                    UpdateFilteredExercises();
                }
            }
        }

        private Exercise selectedExercise;
        public Exercise SelectedExercise
        {
            get => selectedExercise;
            set
            {
                if (selectedExercise != value)
                {
                    selectedExercise = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Exercise> Exercises { get; set; } = new ObservableCollection<Exercise>();

        // Expose MuscleGroupsList from the ParentViewModel
        public List<string> MuscleGroupsList => ParentViewModel.MuscleGroupsList;

        private CreateMesocycleViewModel ParentViewModel { get; }

        public MuscleGroupViewModel(CreateMesocycleViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;

            // Subscribe to changes in AllExercises
            ParentViewModel.AllExercises.CollectionChanged += AllExercises_CollectionChanged;

            // Initialize exercises based on selected muscle group
            UpdateFilteredExercises();
        }

        private void AllExercises_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateFilteredExercises();
        }

        private void UpdateFilteredExercises()
        {
            Exercises.Clear();
            if (string.IsNullOrEmpty(SelectedMuscleGroup))
                return;

            var filtered = ParentViewModel.AllExercises.Where(ex => ex.MuscleGroup == SelectedMuscleGroup);
            foreach (var ex in filtered)
            {
                Exercises.Add(ex);
            }
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
