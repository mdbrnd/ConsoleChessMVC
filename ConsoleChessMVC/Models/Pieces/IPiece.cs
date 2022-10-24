using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Models.Pieces
{

    public interface IPiece
    {
        char FenChar { get; set; }
        string NotationChar { get; set; }
        bool IsWhite { get; set; }
        int X { get; set; }
        int Y { get; set; }

        List<Move> GetPseudoLegalMoves(Board board);
    }
}
