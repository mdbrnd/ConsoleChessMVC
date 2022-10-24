using ChessMVCWinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVCWinForms.Controllers
{
    public class MoveController
    {
        private LogicModel Model =  new LogicModel();

        public void TryMove(Move move)
        {
            Model.TryMove(move);
        }
    }
}
