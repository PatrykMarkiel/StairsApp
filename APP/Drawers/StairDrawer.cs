using Microsoft.Maui.Graphics;

namespace APP.Drawers  // Use the appropriate namespace for your project
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
            // Set drawing color and properties
            canvas.StrokeColor = Colors.Black;
            canvas.FillColor = Colors.Gray;
            canvas.StrokeSize = 2;

            // Draw each step
            for (int i = 0; i < stepsNumber; i++)
            {
                // Calculate the position for each step
                var x = i * stepDepth * scaleX;
                var y = i * stepHeight * scaleY;

                // Draw a rectangle for each step (a step has both width and height)
                canvas.FillRectangle(x, y, stepDepth * scaleX, stepHeight * scaleY);
                canvas.DrawRectangle(x, y, stepDepth * scaleX, stepHeight * scaleY);
            }
        }
    }
}
