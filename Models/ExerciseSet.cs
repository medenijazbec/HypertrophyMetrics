using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.Models
{
    public class ExerciseSet : INotifyPropertyChanged
    {
        private int repetitions;
        public int Repetitions
        {
            get => repetitions;
            set
            {
                if (repetitions != value)
                {
                    repetitions = value;
                    OnPropertyChanged();
                }
            }
        }

        private string weight;
        public string Weight
        {
            get => weight;
            set
            {
                if (weight != value)
                {
                    weight = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Reps { get; set; }
        public string RIR { get; set; } // Reps In Reserve

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
