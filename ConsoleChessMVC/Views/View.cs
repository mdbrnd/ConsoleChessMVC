using ChessMVCWinForms.Models;
using ChessMVCWinForms.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessMVC.Views
{
    internal class View
    {
        public static string BoardToString(Board board)
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

            string res = "";

            res += "  +---+---+---+---+---+---+---+---+" + Environment.NewLine;
            for (int i = 0; i < 8; i++)
            {
                res += $"{8 - i} | ";
                for (int j = 0; j < 8; j++)
                {
                    IPiece piece = board.Pieces[i, j];
                    res += $"{Convert.ToString(piece.IsWhite ? char.ToUpper(piece.FenChar) : piece.FenChar)} | ";
                }
                res += Environment.NewLine + "  +---+---+---+---+---+---+---+---+" + Environment.NewLine;
            }

            res += "    ";
            foreach (KeyValuePair<int, char> kvp in letters)
            {
                res += $"{kvp.Value}   ";
            }

            return res;
        }
    }
}
