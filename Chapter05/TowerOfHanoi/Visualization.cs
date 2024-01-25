// TOWER OF HANOI
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

public class Visualization
{
    private readonly Game _game;
    private readonly int _columnSize;
    private readonly char[,] _board;

    public Visualization(Game game)
    {
        _game = game;
        _columnSize = Math.Max(6, GetDiscWidth(_game.DiscsCount) + 2);
        _board = new char[_game.DiscsCount, _columnSize * 3];
    }

    public void Show(Game game)
    {
        Console.Clear();
        if (game.DiscsCount <= 0) { return; }

        FillEmptyBoard();
        FillRodOnBoard(1, game.From);
        FillRodOnBoard(2, game.To);
        FillRodOnBoard(3, game.Auxiliary);

        Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILIARY"));
        DrawBoard();
        Console.WriteLine($"\nMoves: {game.MovesCount}");
        Console.WriteLine($"Discs: {game.DiscsCount}");
    }

    private int GetDiscWidth(int size) => (2 * size) - 1;

    private void FillEmptyBoard()
    {
        for (int y = 0; y < _board.GetLength(0); y++)
        {
            for (int x = 0; x < _board.GetLength(1); x++)
            {
                _board[y, x] = ' ';
            }
        }
    }

    private void FillRodOnBoard(int column, Stack<int> stack)
    {
        int discsCount = _game.DiscsCount;
        int margin = _columnSize * (column - 1);
        for (int y = 0; y < stack.Count; y++)
        {
            int size = stack.ElementAt(y);
            int row = discsCount - (stack.Count - y);
            int columnStart = margin + discsCount - size;
            int columnEnd = columnStart + GetDiscWidth(size);
            for (int x = columnStart; x <= columnEnd; x++)
            {
                _board[row, x] = '=';
            }
        }
    }

    private string Center(string text)
    {
        int margin = (_columnSize - text.Length) / 2;
        return text.PadLeft(margin + text.Length).PadRight(_columnSize);
    }

    private void DrawBoard()
    {
        for (int y = 0; y < _board.GetLength(0); y++)
        {
            string line = string.Empty;
            for (int x = 0; x < _board.GetLength(1); x++)
            {
                line += _board[y, x];
            }
            Console.WriteLine(line);
        }
    }
}
