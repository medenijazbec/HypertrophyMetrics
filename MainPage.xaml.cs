using Microsoft.Maui.Controls;
using HypertrophyApp.Pages;
using HypertrophyApp.ViewModels;

namespace HypertrophyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Nastavite začetno stran
            NavigateToPage(new CustomExercisePage());


            // Subscribe to the message
            MessagingCenter.Subscribe<PlanMesocycleViewModel>(this, "NavigateToCreateMesocyclePage", (sender) =>
            {
                NavigateToPage(new CreateMesocyclePage());
            });
        }

        private void NavigateToPage(ContentPage page)
        {
            // Clear the current content
            MainContent.Content = null;

            // Add the new page's content
            MainContent.Content = page.Content;

            // Set the BindingContext of the new content
            if (MainContent.Content != null)
            {
                MainContent.Content.BindingContext = page.BindingContext;
            }
        }


        private void OnExercisesClicked(object sender, EventArgs e)
        {
            NavigateToPage(new CustomExercisePage());
        }

        private void OnLoggingClicked(object sender, EventArgs e)
        {
            NavigateToPage(new ExerciseLoggingPage());
        }

        private void OnFeedbackClicked(object sender, EventArgs e)
        {
            NavigateToPage(new FeedbackPage());
        }

        private void OnSummaryClicked(object sender, EventArgs e)
        {
            NavigateToPage(new MesocycleSummaryPage());
        }

        private void OnMuscleStatsClicked(object sender, EventArgs e)
        {
            NavigateToPage(new MuscleGroupStatsPage());
        }

        private void OnPhaseClicked(object sender, EventArgs e)
        {
            NavigateToPage(new PhasePage());
        }

        private void OnTrackingClicked(object sender, EventArgs e)
        {
            NavigateToPage(new PhaseTrackingPage());
        }

        private void OnPlannerClicked(object sender, EventArgs e)
        {
            NavigateToPage(new PlanMesocyclePage());
        }

        private void OnRecoveryClicked(object sender, EventArgs e)
        {
            NavigateToPage(new GainingMusclePage());
        }

        private void OnScheduleClicked(object sender, EventArgs e)
        {
            NavigateToPage(new ScheduleOverviewPage());
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            NavigateToPage(new StartDatePage());
        }

        private void OnWeeklyPlanClicked(object sender, EventArgs e)
        {
            NavigateToPage(new WeekPlanPage());
        }

        private void OnWeighInClicked(object sender, EventArgs e)
        {
            NavigateToPage(new WeighInTimesPage());
        }

        private void OnWorkoutSplitClicked(object sender, EventArgs e)
        {
            NavigateToPage(new WorkoutSplitPage());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<PlanMesocycleViewModel>(this, "NavigateToCreateMesocyclePage");
        }


        // Dodajte več metod za druge strani po potrebi
    }
}
