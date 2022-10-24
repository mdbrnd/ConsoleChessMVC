using ChessMVCWinForms.Models;
using ConsoleChessMVC.Views;

Board b = Board.FromFEN("rnbqkbnr/pp1ppppp/8/3p4/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2 ");
Console.WriteLine(View.BoardToString(b));
Console.WriteLine($"Piece: {b.Pieces[4, 4]}, IsWhite: {b.Pieces[4, 4].IsWhite}");
foreach (var item in b.Pieces[4, 4].GetPseudoLegalMoves(b))
{
    Console.WriteLine(Move.MoveToChessNotation(item, b));
    //Console.WriteLine($"Start: {item.StartMoveX}, {item.StartMoveY}, Target: {item.TargetMoveX}, {item.TargetMoveY}");
}