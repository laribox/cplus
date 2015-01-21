﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompetencePlus.Outils;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.IO;
using CompetencePlus.Tools;
namespace CompetencePlus.PackageDB
{
   public class IncrementDB_DAO
   {
       
       private string db_query_pathe = "db_query/";

       #region facilitateur
       /// <summary>
       /// Enregistrer l'objet IncrementationDB sans un fichier XML
       /// </summary>
       /// <param name="incrementation"></param>
       public void SaveIncrementationDBToFile(IncrementationDB incrementation) {
           XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
           StreamWriter wr = new StreamWriter("db_query/" + incrementation.Code + ".xml");
           xs.Serialize(wr, incrementation);
           wr.Dispose();
       }
       public IncrementationDB RedIncrementationDB(String nomFichierXML) {
           XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
           StreamReader rd = new StreamReader("db_query/" + nomFichierXML);
           IncrementationDB incrementation = xs.Deserialize(rd) as IncrementationDB;
           rd.Dispose();
           return incrementation;
       }
       public IncrementationDB RedIncrementationDBFromFile(String CheminFichier)
       {
           XmlSerializer xs = new XmlSerializer(typeof(IncrementationDB));
           StreamReader rd = new StreamReader(CheminFichier);
           IncrementationDB incrementation = xs.Deserialize(rd) as IncrementationDB;
           rd.Dispose();
           return incrementation;
       }
       /// <summary>
       /// Exécuter la requête et Incrementation de la version de la base de données
       /// </summary>
       /// <param name="increment"></param>
       public void ExecutInDataBase(IncrementationDB increment)
       {
           MyConnection.ExecuteNonQuery(increment.Increment);
           string query = "Insert into VersionDB(Version) values('" + increment.Code + "');";
           MyConnection.ExecuteNonQuery(query);
       }
       /// <summary>
       /// Vérifier la validation de la reuqête SQL
       /// </summary>
       /// <param name="incrementation"></param>
       public bool ValidateQuery(IncrementationDB incrementation)
       {
           DataBaseCreator db = new DataBaseCreator("db_cplus_validation");
           db.InitialisationDatabase();
           try
           {
               db.ExecutIncrementation(incrementation);
               this.SaveIncrementationDBToFile(incrementation);
               return true;

           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
           
       }
      
       #endregion


       private void CopyDbQuery(string DestinationPath)
       {
           //Now Create all of the directories
           foreach (string dirPath in Directory.GetDirectories(db_query_pathe, "*",SearchOption.AllDirectories))
               Directory.CreateDirectory(dirPath.Replace(db_query_pathe, DestinationPath));

           //Copy all the files & Replaces any files with the same name
           foreach (string newPath in Directory.GetFiles(db_query_pathe, "*.*",SearchOption.AllDirectories))
               File.Copy(newPath, newPath.Replace(db_query_pathe, DestinationPath), true);
       
       
       }



       #region Action
       /// <summary>
       /// Exécuter la requête sur la base de donénes actuel puis l'enregistrer en XML
       /// </summary>
       /// <param name="Incrementation"></param>
       public void Execut(IncrementationDB incrementation)
       {
           this.ExecutInDataBase(incrementation);
           this.SaveIncrementationDBToFile(incrementation);
       }
       /// <summary>
       /// Enregistrer la requête dans le ficier XML sans l'excuter 
       /// </summary>
       /// <param name="incrementation"></param>
       public void SaveWithOutExecut(IncrementationDB incrementation)
       {

           this.ValidateQuery(incrementation);
           this.SaveIncrementationDBToFile(incrementation);
       }
       public IEnumerable<IncrementationDB> SelectFromXML()
       {

           // Copiage des requêtes SQL sans le répertoire de test
           //if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, this.db_query_pathe)))
           //{
           //    this.CopyDbQuery(Environment.CurrentDirectory);
           //}


           List<IncrementationDB> List = new List<IncrementationDB>();
           System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"db_query/");
           IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.xml", System.IO.SearchOption.TopDirectoryOnly).OrderByDescending(f => f.Name);
           foreach (var file in fileList)
           {
               IncrementationDB incrementation = RedIncrementationDB(file.Name);
               List.Add(incrementation);

           }

           return List.OrderByDescending(i => i.DateCreation).ToList<IncrementationDB>();
       }
       public IEnumerable<IncrementationDB> SelectFromDB()
       {

           List<IncrementationDB> listIncrementationDB = new List<IncrementationDB>();
           string query = "Select * from VersionDB";
           OleDbDataReader listeRox = MyConnection.ExecuteReader(query);
           while (listeRox.Read())
           {
               IncrementationDB incrementationDB = new IncrementationDB();
               incrementationDB.Code = (string) listeRox["Version"];
               listIncrementationDB.Add(incrementationDB);
           }

           return listIncrementationDB;
       }
       public void Delete(IncrementationDB incrementation)
       {
           System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"db_query/");
           System.IO.File.Delete(@"db_query/" + incrementation.Code + ".xml");
       }
       #endregion


       #region Recherche 
       public IncrementationDB findByCode(string code) {
           return this.RedIncrementationDB(code + ".xml");
       }
       #endregion


       #region Template
       public IncrementationDB TemplteCreateTable()
        {
            return this.RedIncrementationDBFromFile(@"db_query/Templates/CREATE-TABLE.xml");
        }
       #endregion





       public void Update(IncrementationDB incrementation)
       {
           this.SaveIncrementationDBToFile(incrementation);
       }
   }
}
