using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class FeedbackViewModel : BindableObject
    {
        public ICommand JointPainCommand { get; }
        public ICommand BackPumpCommand { get; }
        public ICommand BackWorkloadCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }

        private string jointPain;
        private string backPump;
        private string backWorkload;

        public FeedbackViewModel()
        {
            JointPainCommand = new Command<string>(OnJointPainSelected);
            BackPumpCommand = new Command<string>(OnBackPumpSelected);
            BackWorkloadCommand = new Command<string>(OnBackWorkloadSelected);
            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave);
        }

        private void OnJointPainSelected(string painLevel)
        {
            JointPain = painLevel;
            // Implementirajte logiko za shranjevanje ali obdelavo izbranega nivoja bolečine
        }

        private void OnBackPumpSelected(string pumpLevel)
        {
            BackPump = pumpLevel;
            // Implementirajte logiko za shranjevanje ali obdelavo izbranega nivoja pumpanja
        }

        private void OnBackWorkloadSelected(string workloadLevel)
        {
            BackWorkload = workloadLevel;
            // Implementirajte logiko za shranjevanje ali obdelavo izbranega nivoja obremenitve
        }

        private void OnCancel()
        {
            // Implementirajte logiko za preklic povratnih informacij
        }

        private void OnSave()
        {
            // Implementirajte logiko za shranjevanje povratnih informacij
        }

        public string JointPain
        {
            get => jointPain;
            set
            {
                jointPain = value;
                OnPropertyChanged();
            }
        }

        public string BackPump
        {
            get => backPump;
            set
            {
                backPump = value;
                OnPropertyChanged();
            }
        }

        public string BackWorkload
        {
            get => backWorkload;
            set
            {
                backWorkload = value;
                OnPropertyChanged();
            }
        }
    }
}
