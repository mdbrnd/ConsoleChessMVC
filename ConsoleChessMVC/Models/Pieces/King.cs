using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Models.Pieces
{
    internal sealed class King : IPiece
    {
        public char FenChar { get; set; } = 'k';
        public string NotationChar { get; set; } = "K";
        public bool IsWhite { get; set; } = true;
        public int X { get; set; }
        public int Y { get; set; }

        public King(bool isWhite = true)
        {
            IsWhite = isWhite;
        }

        public List<Move> GetPseudoLegalMoves(Board board)
        {
            return new List<Move>();
        }
    }
}
