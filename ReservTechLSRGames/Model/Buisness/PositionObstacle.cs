using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames
{
    public class PositionObstacle
    {
        private int _idPositionObstacle;
        private string _nomObstacle;
        private int _idReservation;
        private int _positionObstacle;

        public PositionObstacle()
        {
            _idPositionObstacle = 0;
            _nomObstacle = "";
            _idReservation = 0;
            _positionObstacle = 0;
        }

        public PositionObstacle(int unIdPositionObstacle , string unNomObstacle, int unIdReservation, int unePositionObstacle)
        {
            _idPositionObstacle = unIdPositionObstacle;
            _nomObstacle = unNomObstacle;
            _idReservation = unIdReservation;
            _positionObstacle = unePositionObstacle;
        }

        public int IdPositionObstacle { get => _idPositionObstacle; set => _idPositionObstacle = value; }
        public string NomObstacle { get => _nomObstacle; set => _nomObstacle = value; }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }

        public int unePositionObstacle { get => _positionObstacle; set => _positionObstacle = value; }
    }
}
