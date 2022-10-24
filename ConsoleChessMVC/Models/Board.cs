using ChessMVCWinForms.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Models
{
    public class Board
    {
        public bool IsWhitesTurn { get; set; } = true;
        public bool CanWhiteKingCastle { get; set; } = false;
        public bool CanWhiteQueenCastle { get; set; } = false;
        public bool CanBlackKingCastle { get; set; } = false;
        public bool CanBlackQueenCastle { get; set; } = false;
        public IPiece[,] Pieces { get; set; } = new IPiece[8, 8];

        /// <summary>
        /// Checks if a given tile is empty
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsEmpty(int x, int y) => Pieces[x, y].GetType() == typeof(Empty);

        public List<Move> GetLegalMoves(IPiece piece, Board board)
        {
            List<Move> pseudoLegalMoves = piece.GetPseudoLegalMoves(board);
            List<Move> moves = new List<Move>();

            return moves;
        }

        /// <summary>
        /// Generates a Board from a given FEN string
        /// </summary>
        /// <param name="fen"></param>
        /// <returns></returns>
        public static Board FromFEN(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            Board board = new Board();
            string fenBoard = fen.Split(' ')[0];
            int file = 0, rank = 0; // rank = row, file = column

            try
            {
                foreach (char symbol in fenBoard)
                {
                    if (symbol == '/')
                    {
                        file = 0;
                        rank++;
                    }
                    else
                    {
                        if (char.IsDigit(symbol))
                        {
                            // Fill that many whitespaces
                            int amountOfEmptySpaces = (int)char.GetNumericValue(symbol);
                            for (int i = 0; i < amountOfEmptySpaces; i++)
                            {
                                board.Pieces[rank, file] = new Empty();
                                file++;
                            }
                        }
                        else
                        {
                            // 0 = white (default)
                            bool pieceColor = char.IsUpper(symbol) ? true : false;
                            IPiece pieceType = PieceFactory(char.ToLower(symbol)); // Create new instance of that PieceType
                            pieceType.IsWhite = pieceColor;
                            pieceType.X = file;
                            pieceType.Y = rank;
                            board.Pieces[rank, file] = pieceType;
                            file++;
                        }
                    }
                }

                // If after loading the FEN string any element in the pieces array is null, then the FEN string was invalid
                foreach (var piece in board.Pieces)
                {
                    if (piece == null)
                    {
                        throw new Exception("Invalid FEN string");
                    }
                }

                return board;
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Invalid FEN string");
            }
        }

        /// <summary>
        /// Creates a new instance of an IPiece from a given char
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>An instance of IPiece</returns>
        private static IPiece PieceFactory(char piece)
        {
            switch (piece)
            {
                case 'r':
                    return new Rook();
                case 'b':
                    return new Bishop();
                case 'q':
                    return new Queen();
                case 'k':
                    return new King();
                case 'n':
                    return new Knight();
                case 'p':
                    return new Pawn();
                default:
                    return new Empty();
            }
        }
    }
}
