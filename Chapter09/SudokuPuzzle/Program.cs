// SUDOKU PUZZLE
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

int[,] board = new int[,]
{
    { 0, 5, 0, 4, 0, 1, 0, 0, 6 },
    { 1, 0, 0, 9, 5, 0, 8, 0, 0 },
    { 9, 0, 4, 0, 6, 0, 0, 0, 1 },
    { 6, 2, 0, 0, 0, 5, 3, 0, 4 },
    { 0, 9, 0, 0, 7, 0, 2, 0, 5 },
    { 5, 0, 7, 0, 0, 0, 0, 8, 9 },
    { 8, 0, 0, 5, 1, 9, 0, 0, 2 },
    { 2, 3, 0, 0, 0, 6, 5, 0, 8 },
    { 4, 1, 0, 2, 0, 8, 6, 0, 0 }
};
if (Solve()) { Print(); }

bool Solve()
{
    (int row, int col) = GetEmpty();
    if (row < 0 && col < 0) { return true; }

    for (int i = 1; i <= 9; i++)
    {
        if (IsCorrect(row, col, i))
        {
            board[row, col] = i;
            if (Solve()) { return true; }
            else { board[row, col] = 0; }
        }
    }

    return false;
}

(int, int) GetEmpty()
{
    for (int r = 0; r < 9; r++)
    {
        for (int c = 0; c < 9; c++)
        {
            if (board[r, c] == 0) { return (r, c); }
        }
    }
    return (-1, -1);
}

bool IsCorrect(int row, int col, int num)
{
    for (int i = 0; i < 9; i++)
    {
        if (board[row, i] == num) { return false; }
        if (board[i, col] == num) { return false; }
    }

    int rs = row - row % 3;
    int cs = col - col % 3;
    for (int r = rs; r < rs + 3; r++)
    {
        for (int c = cs; c < cs + 3; c++)
        {
            if (board[r, c] == num) { return false; }
        }
    }

    return true;
}

void Print()
{
    for (int row = 0; row < 9; row++)
    {
        for (int col = 0; col < 9; col++)
        {
            Console.Write($"{board[row, col]} ");
        }

        Console.WriteLine();
    }
}
