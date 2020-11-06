using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames
{
    public class Reservation
    {
        private int _idReservation;
        private int _idClient;
        private int _idSalle;
        private int _idTransaction;
        private DateTime _dateReservation;
        private int _nbJoueurs;
        private int _nbObstacles;

        public Reservation()
        {
            _idReservation = 0;
            _idClient = 0;
            _idSalle = 0;
            _idTransaction = 0;
            _dateReservation = new DateTime();
            _nbJoueurs = 0;
            _nbObstacles = 0;
        }

        public Reservation (int unIdReservation, int unIdClient, int unIdSalle, int unIdTransaction, DateTime uneDateReservation,int unNbJoueurs, int unNbObstacle)
        {
            _idReservation = unIdReservation;
            _idClient = unIdClient;
            _idSalle = unIdSalle;
            _idTransaction = unIdTransaction;
            _dateReservation = uneDateReservation;
            _nbJoueurs = unNbJoueurs;
            _nbObstacles = unNbObstacle;
        }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }

        public int IdClient { get => _idClient; set => _idClient = value; }

        public int IdSalle { get => _idSalle; set => _idSalle = value; }

        public int IdTransaction { get => _idTransaction; set => _idTransaction = value; }

        public DateTime DateReservation { get => _dateReservation; set => _dateReservation = value; }
        public int NbJoueurs { get => _nbJoueurs; set => _nbJoueurs = value; }

        public int NbObstacle { get => _nbObstacles; set => _nbObstacles = value; }
    }
}
