// FRACTAL GENERATION
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

using System.Drawing;
using System.Drawing.Drawing2D;

const int maxSize = 1000;
List<Line> lines = [];
AddLine(14, 0, 0, 500, (float)Math.PI * 1.5f);

float xMin = lines.Min(l => Math.Min(l.X1, l.X2));
float xMax = lines.Max(l => Math.Max(l.X1, l.X2));
float yMin = lines.Min(l => Math.Min(l.Y1, l.Y2));
float yMax = lines.Max(l => Math.Max(l.Y1, l.Y2));
float size = Math.Max(xMax - xMin, yMax - yMin);
float factor = maxSize / size;
int width = (int)((xMax - xMin) * factor);
int height = (int)((yMax - yMin) * factor);

#pragma warning disable CA1416
using Bitmap bitmap = new(width, height);
using Graphics graphics = Graphics.FromImage(bitmap);
graphics.Clear(Color.White);
graphics.SmoothingMode = SmoothingMode.AntiAlias;
using Pen pen = new(Color.Black, 1);
foreach (Line line in lines)
{
    pen.Width = line.GetLength() / 20;
    float sx = (line.X1 - xMin) * factor;
    float sy = (line.Y1 - yMin) * factor;
    float ex = (line.X2 - xMin) * factor;
    float ey = (line.Y2 - yMin) * factor;
    graphics.DrawLine(pen, sx, sy, ex, ey);
}
bitmap.Save($"{DateTime.Now:HH-mm-ss}.png");
#pragma warning restore CA1416

void AddLine(int level, float x, float y, float length, float angle)
{
    if (level < 0) { return; }

    float endX = x + (float)(length * Math.Cos(angle));
    float endY = y + (float)(length * Math.Sin(angle));
    lines.Add(new(x, y, endX, endY));

    AddLine(level - 1, endX, endY, length * 0.8f, angle + (float)Math.PI * 0.3f);
    AddLine(level - 1, endX, endY, length * 0.6f, angle + (float)Math.PI * 1.7f);
}

record Line(float X1, float Y1, float X2, float Y2)
{
    public float GetLength() =>
        (float)Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
}
