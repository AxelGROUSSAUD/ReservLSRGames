using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames.Model.Buisness
{
    public class daoReservation
    {
        private DBAL _DBAL;

        public daoReservation(DBAL unDBAL)
        {
            _DBAL = unDBAL;
        }

        public void Insert(Reservation uneReservation)
        {
            _DBAL.Insert("INSERT INTO Reservation VALUES (" + uneReservation.IdReservation + "," + uneReservation.IdClient+","+uneReservation.IdSalle+","+uneReservation.IdTransaction+",'"+uneReservation.DateReservation+"',"+uneReservation.NbJoueurs+","+uneReservation.NbObstacle+");");
        }

        public void Update(Reservation uneReservation)
        {
            _DBAL.Update("UPDATE Reservation SET idReservation = "+uneReservation.IdReservation+",idClient = "+uneReservation.IdClient+",idSalle = "+uneReservation.IdSalle+",idTransaction = "+uneReservation.IdTransaction+",dateReservation = " + uneReservation.DateReservation + ", nbJoueurs = " + uneReservation.NbJoueurs + ", nbObstacles = " + uneReservation.NbObstacle + "WHERE idReservation = " + uneReservation.IdReservation + ";");
        }


        public void Delete(Reservation uneReservation)
        {
            _DBAL.Delete("DELETE FROM Reservation WHERE idReservation = "+uneReservation.IdReservation + ";");
        }

        public void InsertByFile()
        {
            using (var reader = new StreamReader("réservations.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                //var records = csv.GetRecords<Pays>();
                var record = new Reservation();
                var records = csv.EnumerateRecords(record);

                foreach (var item in records)
                {
                    this.Insert(item);
                }
            }
        }

        public List<Reservation> SelectAll()
        {

        }
    }
}
