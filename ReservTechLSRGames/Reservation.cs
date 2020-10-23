using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames
{
    class Reservation
    {
        private int _idReservation;
        private int _idClient;
        private int _idSalle;
        private int _idTransaction;
        private DateTime _jour;
        private DateTime _heure;
        private int _nbJoueurs;
        private int _nbObstacle;

        public Reservation()
        {
            _idReservation = 0;
            _idClient = 0;
            _idSalle = 0;
            _idTransaction = 0;
            _jour = new DateTime();
            _heure = new DateTime();
            _nbJoueurs = 0;
            _nbObstacle = 0;
        }

        public Reservation (int unIdReservation, int unIdClient, int unIdSalle, int unIdTransaction, DateTime unJour, DateTime uneHeure,int unNbJoueurs, int unNbObstacle)
        {
            _idReservation = unIdReservation;
            _idClient = unIdClient;
            _idSalle = unIdSalle;
            _idTransaction = unIdTransaction;
            _jour = unJour;
            _heure = uneHeure;
            _nbJoueurs = unNbJoueurs;
            _nbObstacle = unNbObstacle;
        }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }

        public int IdClient { get => _idClient; set => _idClient = value; }

        public int IdSalle { get => _idSalle; set => _idSalle = value; }

        public int IdTransaction { get => _idTransaction; set => _idTransaction = value; }

        public DateTime getJour()
        {
            return _jour;
        }

        public void setJour(DateTime unJour)
        {
            _jour = unJour;
        }

        public int NbJoueurs { get => _nbJoueurs; set => _nbJoueurs = value; }

        public int NbObstacle { get => _nbObstacle; set => _nbObstacle = value; }
    }
}
