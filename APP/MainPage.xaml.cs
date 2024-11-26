using APP.Drawers;
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
            var (resultText, stepsNumber, stepHeight, stepDepth, stairsMade) = CalculateStairs(Hk, Lk);

            ResultLabel.Text = resultText;
            ResultLabel.TextColor = stairsMade ? Colors.Blue : Colors.Red;
            ResultLabel.IsVisible = true;
            if (stairsMade)
            {
                DrawStairs(stepsNumber, stepHeight, stepDepth);
            }
            else
            {
                StairsLayout.IsVisible = false; 
            }
        }
        private void DrawStairs(int stepsNumber, float stepHeight, float stepDepth)
        {
            // Get the dimensions of the drawing area
            var width = StairsLayout.Width;
            var height = StairsLayout.Height;

            // Create a scaled view of the stairs
            var scaleX = width / (stepsNumber * stepDepth);  // Scale based on the width of the available space
            var scaleY = height / (stepsNumber * stepHeight); // Scale based on the height of the available space

            // Create a scaled rectangle for the stairs
            var stairsRect = new Rect(0, 0, stepsNumber * stepDepth * scaleX, stepsNumber * stepHeight * scaleY);

            // Draw the stairs
            StairsLayout.Drawable = new StairDrawer(stepsNumber, stepHeight, stepDepth, (float)scaleX, (float)scaleY);
            StairsLayout.IsVisible = true;
        }


        private (string, int, float, float, Boolean) CalculateStairs(int Hk, int Lk)
        {
            const float MinStepHeight = 155;
            const float MaxStepHeight = 190;
            const float MinStepDepth = 240;
            const float MaxStepDepth = 310;

            int stepsNumber = 0;
            float stepHeight = 0;
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

                    return (
                        $"Liczba stopni: {stepsNumber}\n" +
                        $"Wysokość stopnia: {stepHeight:F2} mm\n" +
                        $"Głębokość stopnia: {stepDepthCalculated:F2} mm\n" +
                        (remainingLength > 0
                            ? $"Pozostała wolna przestrzeń w długości: {remainingLength:F2} mm"
                            : "Cała dostępna przestrzeń została wykorzystana na schody."),
                        stepsNumber, stepHeight, stepDepthCalculated, stairsMade
                    );
                }
            }

            return ("Nie udało się stworzyć wygodnych schodów.", 0, 0f, 0f,false);
        }

    }
}
