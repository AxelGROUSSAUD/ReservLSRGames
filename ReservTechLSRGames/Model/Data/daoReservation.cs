using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
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
            List<Reservation> uneListeReservation = new List<Reservation>();
            DataTable uneDataTable = _DBAL.SelectAll("Reservation");
            foreach(DataRow dtr in uneDataTable.Rows )
            {
                Reservation uneReservation = new Reservation((int)dtr["idReservation"], (int)dtr["idClient"], (int)dtr["idSalle"], (int)dtr["idTransaction"], (DateTime)dtr["dateReservation"], (int)dtr["nbJoueurs"], (int)dtr["nbObstacles"]);
                uneListeReservation.Add(uneReservation);
            }
            return uneListeReservation;
        }

        public Reservation SelectById(int idReservation)
        {
            DataRow UneDataRow = _DBAL.SelectById("Reservation", idReservation);
            Reservation uneReservation = new Reservation((int)UneDataRow["idReservation"], (int)UneDataRow["idClient"], (int)UneDataRow["idSalle"], (int)UneDataRow["idTransaction"], (DateTime)UneDataRow["dateReservation"], (int)UneDataRow["nbJoueurs"], (int)UneDataRow["nbObstacles"]);
            return uneReservation;
        }
    }
}
