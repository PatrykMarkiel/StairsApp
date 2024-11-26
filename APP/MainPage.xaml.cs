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
            int Hk;
            int Lk;
            Hk = int.Parse(HkEntry.Text);
            Lk = int.Parse(LkEntry.Text);
            var (resultText, stepsNumber, stepHeight, stepDepth, stairsMade) = CalculateStairs(Hk, Lk);

            ResultLabel.Text = resultText;
            ResultLabel.TextColor = stairsMade ? Colors.White : Colors.Red;
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
            var width = StairsLayout.Width;
            var height = StairsLayout.Height;

            var scaleX = width / (stepsNumber * stepDepth);
            var scaleY = height / (stepsNumber * stepHeight);

            var stairsRect = new Rect(0, 0, stepsNumber * stepDepth * scaleX, stepsNumber * stepHeight * scaleY);

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

            return ("Nie udało się stworzyć wygodnych schodów.", 0, 0f, 0f, false);
        }
    }
}
