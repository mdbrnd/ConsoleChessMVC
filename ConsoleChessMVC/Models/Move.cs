using ChessMVCWinForms.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Models
{
    public class Move
    {
        public IPiece TypeOfPieceThatIsMoving { get; set; }
        public int StartMoveX { get; set; }
        public int StartMoveY { get; set; }
        public int TargetMoveX { get; set; }
        public int TargetMoveY { get; set; }

        public Move(IPiece typeOfPieceThatIsMoving, int startx, int starty, int targetx, int targety)
        {
            TypeOfPieceThatIsMoving = typeOfPieceThatIsMoving;
            StartMoveX = startx;
            StartMoveY = starty;
            TargetMoveX = targetx;
            TargetMoveY = targety;
        }

        public static string MoveToChessNotation(Move move, Board board)
        {
            Dictionary<int, char> letters = new Dictionary<int, char>() {
                {0, 'a'},
                {1, 'b'},
                {2, 'c'},
                {3, 'd'},
                {4, 'e'},
                {5, 'f'},
                {6, 'g'},
                {7, 'h'}
            };

            bool isTargetEmpty = board.IsEmpty(move.TargetMoveX, move.TargetMoveY);

            return $"{move.TypeOfPieceThatIsMoving.NotationChar}{(isTargetEmpty ? "" : "x")}{letters[move.TargetMoveX]}{8 - move.TargetMoveY}";
        }
    }
}
