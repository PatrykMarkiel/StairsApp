namespace APP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnSubmitClicked(object sender, EventArgs e)
        {

            if (!int.TryParse(HkEntry.Text, out int Hk) || !int.TryParse(LkEntry.Text, out int Lk))
            {
                ResultLabel.Text = "Podaj poprawne wartości liczbowe dla Hk i Lk.";
                ResultLabel.TextColor = Colors.Red;
                ResultLabel.IsVisible = true;
                return;
            }

            // Obliczanie schodów
            ResultLabel.Text = CalculateStairs(Hk, Lk);
            ResultLabel.TextColor = Colors.Blue;
            ResultLabel.IsVisible = true;
        }

        private string CalculateStairs(int Hk, int Lk)
        {
            const float MinStepHeight = 155;
            const float MaxStepHeight = 190;
            const float MinStepDepth = 240;
            const float MaxStepDepth = 310;

            int stepsNumber = 0;
            float stepHeight = 0f;
            bool stairsMade = false;

            for (stepsNumber = (int)Math.Ceiling((float)Hk / MaxStepHeight);
                 stepsNumber <= (int)Math.Ceiling((float)Hk / MinStepHeight);
                 stepsNumber++)
            {
                stepHeight = (float)Hk / stepsNumber;

                if (stepHeight < MinStepHeight || stepHeight > MaxStepHeight)
                {
                    continue;
                }

                float stepDepthCalculated = (float)Lk / stepsNumber;

                if (stepDepthCalculated < MinStepDepth)
                {
                    stepDepthCalculated = MinStepDepth;
                }
                if (stepDepthCalculated > MaxStepDepth)
                {
                    stepDepthCalculated = MaxStepDepth;
                }

                if ((2 * stepHeight + stepDepthCalculated) >= 590 &&
                    (2 * stepHeight + stepDepthCalculated) <= 670)
                {
                    stairsMade = true;
                    float remainingLength = Lk - (stepsNumber * stepDepthCalculated);

                    return $"Liczba stopni: {stepsNumber}\n" +
                           $"Wysokość stopnia: {stepHeight:F2} mm\n" +
                           $"Głębokość stopnia: {stepDepthCalculated:F2} mm\n" +
                           (remainingLength > 0
                               ? $"Pozostała wolna przestrzeń w długości: {remainingLength:F2} mm"
                               : "Cała dostępna przestrzeń została wykorzystana na schody.");
                }
            }

            return "Nie udało się stworzyć wygodnych schodów.";
        }
    }

}
