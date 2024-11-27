using Microsoft.Maui.Graphics;

namespace APP.Drawers
{
    public class StairDrawer2 : IDrawable
    {
        private int stepsNumber;
        private float stepHeight;
        private float stepDepth;
        private float scaleX;
        private float scaleY;

        public StairDrawer2(int stepsNumber, float stepHeight, float stepDepth, float scaleX, float scaleY)
        {
            this.stepsNumber = stepsNumber;
            this.stepHeight = stepHeight;
            this.stepDepth = stepDepth;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.DarkRed;
            canvas.StrokeSize = 4;

            float currentX = 0;
            float currentY = 0;

            for (int i = 0; i < stepsNumber; i++)
            {
                float nextX = currentX + stepDepth * scaleX;
                float nextY = currentY + stepHeight * scaleX;

                canvas.DrawLine(currentX, currentY, nextX, currentY);
                canvas.DrawLine(nextX, currentY, nextX, nextY);

                currentX = nextX;
                currentY = nextY;
            }
        }
    }
}
