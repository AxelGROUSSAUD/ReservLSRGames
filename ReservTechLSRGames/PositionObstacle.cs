using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames
{
    class PositionObstacle
    {
        private string _nomObstacle;
        private int _idReservation;
        private int _positionObstacle;

        public PositionObstacle(string unNomObstacle, int unIdReservation, int unePositionObstacle)
        {
            _nomObstacle = unNomObstacle;
            _idReservation = unIdReservation;
            _positionObstacle = unePositionObstacle;
        }

        public string NomObstacle { get => _nomObstacle; set => _nomObstacle = value; }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }

        public int unePositionObstacle { get => _positionObstacle; set => _positionObstacle = value; }
    }
}
