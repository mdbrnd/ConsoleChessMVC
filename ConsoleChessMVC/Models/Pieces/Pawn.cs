using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Models.Pieces
{
    internal sealed class Pawn : IPiece
    {
        public char FenChar { get; set; } = 'p';
        public string NotationChar { get; set; } = "P";
        public bool IsWhite { get; set; } = true;
        public int X { get; set; }
        public int Y { get; set; }

        public Pawn(bool isWhite = true)
        {
            IsWhite = isWhite;
        }

        public List<Move> GetPseudoLegalMoves(Board board)
        {
            List<Move> moves = new List<Move>();
            if (IsWhite)
            {
                if (board.IsWhitesTurn)
                {
                    if (board.Pieces[X, Y-1].GetType() == typeof(Empty))
                    {
                        moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X, targety: Y-1));
                    }
                    if (Y == 6)
                    {
                        if (board.Pieces[X, Y-2].GetType() == typeof(Empty))
                        {
                            moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X, targety: Y-2));
                        }
                    }

                    if (board.Pieces[X+1, Y-1].GetType() != typeof(Empty))
                    {
                        moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X+1, targety: Y-1));
                    }

                    if (board.Pieces[X-1, Y-1].GetType() != typeof(Empty))
                    {
                        moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X-1, targety: Y-1));
                    }
                }
            }
            else
            {
                if (!board.IsWhitesTurn)
                {
                    // One square forward
                    if (board.Pieces[X, Y + 1].GetType() == typeof(Empty))
                    {
                        moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X, targety: Y + 1));
                    }
                    // Two squares forward if is in starting position
                    if (Y == 1)
                    {
                        if (board.Pieces[X, Y + 2].GetType() == typeof(Empty))
                        {
                            moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X, targety: Y + 2));
                        }
                    }

                    // If can eat
                    if (board.Pieces[X + 1, Y + 1].GetType() != typeof(Empty))
                    {
                        moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X + 1, targety: Y + 1));
                    }

                    if (board.Pieces[X - 1, Y + 1].GetType() != typeof(Empty))
                    {
                        moves.Add(new Move(typeOfPieceThatIsMoving: new Pawn(), startx: X, starty: Y, targetx: X - 1, targety: Y + 1));
                    }
                }
            }

            return moves;
        }
    }
}
