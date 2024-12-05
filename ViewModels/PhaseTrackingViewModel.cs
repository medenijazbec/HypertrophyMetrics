using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.ViewModels
{
    public class PhaseTrackingViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PhaseDetail> PhaseDetails { get; set; }

        public PhaseTrackingViewModel()
        {
            PhaseDetails = new ObservableCollection<PhaseDetail>
            {
                new PhaseDetail { PhaseName = "Phase 1: Foundation" },
                new PhaseDetail { PhaseName = "Phase 2: Strength" },
                new PhaseDetail { PhaseName = "Phase 3: Hypertrophy" },
                new PhaseDetail { PhaseName = "Phase 4: Deload" }
                // Dodajte več faz po potrebi
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PhaseDetail
    {
        public string PhaseName { get; set; }
    }
}
