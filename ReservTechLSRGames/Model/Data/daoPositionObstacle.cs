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
    public class daoPositionObstacle
    {
        private DBAL _DBAL;

        public daoPositionObstacle(DBAL unDBAL)
        {
            _DBAL = unDBAL;
        }

        public void Insert(PositionObstacle unePositionObstacle)
        {
            _DBAL.Insert("INSERT INTO PositionObstacle values ('" + unePositionObstacle.NomObstacle + "', " + unePositionObstacle.IdReservation + "," + unePositionObstacle.unePositionObstacle + ");");
        }

        public void Update(PositionObstacle unePositionObstacle)
        {
            _DBAL.Update("UPDATE  PositionObstacle SET nomObstacle = '" + unePositionObstacle.NomObstacle + "', idReservation = " + unePositionObstacle.IdReservation + " , positionObstacle = " + unePositionObstacle.unePositionObstacle + " WHERE nomObstacle = '" + unePositionObstacle.NomObstacle + "';");
        }

        public void Delete(PositionObstacle unePositionObstacle)
        {
            _DBAL.Delete("DELETE FROM PositionObstacle WHERE nomObstacle = '" + unePositionObstacle.NomObstacle + "' ;");
        }


        public void InsertByFile()
        {
            using (var reader = new StreamReader("positionobstacles.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                //var records = csv.GetRecords<Pays>();
                var record = new PositionObstacle();
                var records = csv.EnumerateRecords(record);

                foreach (var item in records)
                {
                    this.Insert(item);
                }
            }
        }
    }
}
