﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservTechLSRGames.Model.Buisness
{
    public class daoObstacle
    {
        private DBAL _DBAL;

        public daoObstacle(DBAL unDBAL)
        {
            _DBAL = unDBAL;
        }


        public void Insert(Obstacle unObstacle) //insérer une ligne

        {
            
            _DBAL.Insert("INSERT INTO Obstacle values (" + unObstacle.NomObstacle + ", '" + unObstacle.Definition + "','"+unObstacle.Photo +"','" + unObstacle.TypeObstacle+"');");

        }

        public void Update(Obstacle unObstacle)// mettre à jour une ligne   
        {
            _DBAL.Update("UPDATE  Obstacle SET nomObstacle = '" + unObstacle.NomObstacle + "', definition = '" + unObstacle.Definition + "', photo = '" + unObstacle.Photo + "', typeObstacle = '" + unObstacle.TypeObstacle + "' WHERE nomObstacle = '" + unObstacle.NomObstacle + "';");

        }

        public void Delete(Obstacle unObstacle) //supprimer une ligne
        {
            _DBAL.Delete("DELETE FROM Obstacle WHERE nomObstacle = '" + unObstacle.NomObstacle + "' ;");

        }

        public void InsertByFile()
        {
            using (var reader = new StreamReader("obstacles.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                //var records = csv.GetRecords<Pays>();
                var record = new Obstacle();
                var records = csv.EnumerateRecords(record);

                foreach (var item in records)
                {
                    this.Insert(item);
                }
            }
        }
    }
}
