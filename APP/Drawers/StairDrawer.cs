using Microsoft.Maui.Graphics;

namespace APP.Drawers 
{
    public class StairDrawer : IDrawable
    {
        private int stepsNumber;
        private float stepHeight;
        private float stepDepth;
        private float scaleX;
        private float scaleY;

        public StairDrawer(int stepsNumber, float stepHeight, float stepDepth, float scaleX, float scaleY)
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
            canvas.FillColor = Colors.Red;
            canvas.StrokeSize = 2;

            for (int i = 0; i < stepsNumber; i++)
            {
                var x = i * stepDepth * scaleX;
                var y = i * stepHeight * scaleY;

                canvas.FillRectangle(x, y, stepDepth * scaleX, stepHeight * scaleX);
                canvas.DrawRectangle(x, y, stepDepth * scaleX, stepHeight * scaleX);
            }
        }
    }
}
