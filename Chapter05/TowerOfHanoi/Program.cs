// TOWER OF HANOI
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

Game game = new(10);
Visualization vis = new(game);
game.MoveCompleted += (s, e) => vis.Show((Game)s!);
await game.MoveAsync(game.DiscsCount, game.From, game.To, game.Auxiliary);
