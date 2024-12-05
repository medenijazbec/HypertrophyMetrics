using Microsoft.Maui.Controls;
using HypertrophyApp.ViewModels;

namespace HypertrophyApp.Pages
{
    public partial class CreateMesocyclePage : ContentPage
    {
        public CreateMesocyclePage()
        {
            InitializeComponent();
            BindingContext = new CreateMesocycleViewModel();
        }
    }
}
