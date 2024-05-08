// CLOSEST PAIR OF POINTS
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

public record Point(int X, int Y)
{
    public float GetDistanceTo(Point p) =>
        (float)Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
};
