using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Models.Pieces
{
    internal class Empty : IPiece
    {
        //public char FenChar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public char FenChar { get; set; } = ' ';
        public string NotationChar { get; set; } = "";
        public bool IsWhite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public List<Move> GetPseudoLegalMoves(Board board)
        {
            return new List<Move>();
        }
    }
}
