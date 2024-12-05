using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class PlanMesocycleViewModel : INotifyPropertyChanged
    {
        private string selectedMesoType;
        public string SelectedMesoType
        {
            get => selectedMesoType;
            set
            {
                if (selectedMesoType != value)
                {
                    selectedMesoType = value;
                    OnPropertyChanged();
                }
            }
        }

        // Properties for sex selection
        private bool isMale;
        public bool IsMale
        {
            get => isMale;
            set
            {
                if (isMale != value)
                {
                    isMale = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isFemale;
        public bool IsFemale
        {
            get => isFemale;
            set
            {
                if (isFemale != value)
                {
                    isFemale = value;
                    OnPropertyChanged();
                }
            }
        }

        // Properties for pickers
        public List<string> DaysOfWeek { get; } = new List<string>
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        private string selectedStartDay;
        public string SelectedStartDay
        {
            get => selectedStartDay;
            set
            {
                if (selectedStartDay != value)
                {
                    selectedStartDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> PresetOptions { get; } = new List<string>
        {
            "Strength", "Hypertrophy", "Endurance"
        };

        private string selectedPreset;
        public string SelectedPreset
        {
            get => selectedPreset;
            set
            {
                if (selectedPreset != value)
                {
                    selectedPreset = value;
                    OnPropertyChanged();
                }
            }
        }

        // Commands
        public ICommand PresetCommand { get; }
        public ICommand CustomCommand { get; }
        public ICommand ContinueCommand { get; }
        public ICommand SelectMaleCommand { get; }
        public ICommand SelectFemaleCommand { get; }

        public PlanMesocycleViewModel()
        {
            // Set default selection
            SelectedMesoType = "Preset";

            PresetCommand = new Command(OnPresetSelected);
            CustomCommand = new Command(OnCustomSelected);
            ContinueCommand = new Command(OnContinue);
            SelectMaleCommand = new Command(OnSelectMale);
            SelectFemaleCommand = new Command(OnSelectFemale);
        }

        private void OnPresetSelected()
        {
            SelectedMesoType = "Preset";
            // Additional logic for preset selection
        }

        private void OnCustomSelected()
        {
            SelectedMesoType = "Custom";
            // Log or breakpoint here
            Console.WriteLine("CustomCommand executed, message sent");
            // Send a message to navigate to CreateMesocyclePage
            MessagingCenter.Send(this, "NavigateToCreateMesocyclePage");
        }


        private void OnContinue()
        {
            // Logic to continue to the next step
            // You can add navigation or other logic here
        }

        private void OnSelectMale()
        {
            IsMale = true;
            IsFemale = false;
        }

        private void OnSelectFemale()
        {
            IsFemale = true;
            IsMale = false;
        }

        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
