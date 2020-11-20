﻿using CsvHelper;
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
    public class daoObstacle
    {
        private DBAL _DBAL;

        public daoObstacle(DBAL unDBAL)
        {
            _DBAL = unDBAL;
        }


        public void Insert(Obstacle unObstacle) //insérer une ligne

        {
            
            _DBAL.Insert(" Obstacle values (" + unObstacle.NomObstacle + ", '" + unObstacle.Definition + "','"+unObstacle.Photo +"','" + unObstacle.TypeObstacle+"');");

        }

        public void Update(Obstacle unObstacle)// mettre à jour une ligne   
        {
            _DBAL.Update(" Obstacle SET nom = '" + unObstacle.NomObstacle + "', UneDefinition = '" + unObstacle.Definition + "', Photo = '" + unObstacle.Photo + "', typeObstacle = '" + unObstacle.TypeObstacle + "' WHERE nom = '" + unObstacle.NomObstacle + "';");

        }

        public void Delete(Obstacle unObstacle) //supprimer une ligne
        {
            _DBAL.Delete("Obstacle WHERE nom = '" + unObstacle.NomObstacle + "' ;");

        }

        public void InsertByFile(string chemin)
        {
            using (var reader = new StreamReader(chemin))
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

        public List<Obstacle> SelectAll()
        {
            List<Obstacle> uneListeObstacle = new List<Obstacle>();
            DataTable uneDataTable = _DBAL.SelectAll("Obstacle");
            foreach (DataRow dtr in uneDataTable.Rows)
            {
                Obstacle unObstacle = new Obstacle((string)dtr["nom"], (string)dtr["UneDefinition"], (string)dtr["Photo"], (string)dtr["typeObstacle"]);
                uneListeObstacle.Add(unObstacle);
            }
            return uneListeObstacle;
        }

        public Obstacle SelectByName(string nomObstacle)
        {
            
            DataTable uneDataTable = _DBAL.SelectByField("Obstacle", "nomObstacle = '"+nomObstacle+"';");
            Obstacle unObstacle = new Obstacle((string)uneDataTable.Rows[0]["nom"], (string)uneDataTable.Rows[0]["UneDefinition"], (string)uneDataTable.Rows[0]["Photo"], (string)uneDataTable.Rows[0]["typeObstacle"]);
            return unObstacle;
        }
    }
}
