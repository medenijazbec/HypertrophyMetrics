using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.ViewModels
{
    public class MesocycleSummaryViewModel : INotifyPropertyChanged
    {
        private int completedTasks;
        public int CompletedTasks
        {
            get => completedTasks;
            set
            {
                completedTasks = value;
                OnPropertyChanged();
            }
        }

        private int skippedTasks;
        public int SkippedTasks
        {
            get => skippedTasks;
            set
            {
                skippedTasks = value;
                OnPropertyChanged();
            }
        }

        private int remainingTasks;
        public int RemainingTasks
        {
            get => remainingTasks;
            set
            {
                remainingTasks = value;
                OnPropertyChanged();
            }
        }

        public MesocycleSummaryViewModel()
        {
            // Inicializirajte vrednosti
            // To bi bilo običajno pridobivanje podatkov iz baze ali storitve
            CompletedTasks = 5;
            SkippedTasks = 2;
            RemainingTasks = 3;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
