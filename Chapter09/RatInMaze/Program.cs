// RAT IN A MAZE
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

int size = 8;
bool t = true;
bool f = false;
bool[,] maze =
{
    { t, f, t, f, f, t, t, t },
    { t, t, t, t, t, f, t, f },
    { t, t, f, t, t, f, t, t },
    { f, t, t, f, t, f, f, t },
    { f, t, t, t, t, t, t, t },
    { t, f, t, f, t, f, f, t },
    { t, t, t, t, t, t, t, t },
    { f, t, f, f, f, t, f, t }
};
bool[,] solution = new bool[size, size];
if (Go(0, 0)) { Print(); }

bool Go(int row, int col)
{
    if (row == size - 1 && col == size - 1 && maze[row, col])
    {
        solution[row, col] = true;
        return true;
    }
    if (row >= 0 && row < size
        && col >= 0 && col < size
        && maze[row, col])
    {
        if (solution[row, col]) { return false; }
        solution[row, col] = true;
        if (Go(row + 1, col)) { return true; }
        if (Go(row, col + 1)) { return true; }
        if (Go(row - 1, col)) { return true; }
        if (Go(row, col - 1)) { return true; }
        solution[row, col] = false;
        return false;
    }

    return false;
}

void Print()
{
    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            Console.Write(solution[row, col] ? "x" : "-");
        }
        Console.WriteLine();
    }
}
