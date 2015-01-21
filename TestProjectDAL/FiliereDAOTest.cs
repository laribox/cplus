using CompetencePlus.PackageFilieres;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CompetencePlus.Tools;

namespace TestProjectDAL
{
    
    
    /// <summary>
    ///Classe de test pour FiliereDAOTest, destinée à contenir tous
    ///les tests unitaires FiliereDAOTest
    ///</summary>
    [TestClass()]
    public class FiliereDAOTest
    {


        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

       


        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)

        {
            
            
            
        }

        
        


        


        /// <summary>
        ///Test pour Constructeur FiliereDAO
        ///</summary>
        [TestMethod()]
        public void FiliereDAOConstructorTest()
        {
            FiliereDAO target = new FiliereDAO();
        }

        /// <summary>
        ///Test pour Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            FiliereDAO target = new FiliereDAO(); // TODO: initialisez à une valeur appropriée
            Filiere f = new Filiere();
            f.Titre = "Technicien spécialisé en développement informatique";
            f.Code = "TDI";
            f.Description = "Technicien spécialisé en développement informatique";
            int resultat = target.Add(f);
            Assert.AreEqual(1, resultat);
        }

        /// <summary>
        ///Test pour Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            FiliereDAO target = new FiliereDAO(); 
            int id = 0; 
            target.Delete(id);
           
        }

        /// <summary>
        ///Test pour FindByFilier
        ///</summary>
        [TestMethod()]
        public void FindByFilierTest()
        {
            FiliereDAO target = new FiliereDAO(); // TODO: initialisez à une valeur appropriée
            Filiere filier = new Filiere();
            filier.Code = "TDI";
            filier.Titre = "T";
            filier.Description = "T";
            List<Filiere> actual = target.FindByFilier(filier);
            Assert.IsNotNull(actual);

        }

        /// <summary>
        ///Test pour FindById
        ///</summary>
        [TestMethod()]
        public void FindByIdTest()
        {
            FiliereDAO target = new FiliereDAO(); 
            int id = 0; 
            Filiere expected = null;
            Filiere actual;
            actual = target.FindById(id);
        }

  
        /// <summary>
        ///Test pour Select
        ///</summary>
        [TestMethod()]
        public void SelectTest()
        {
            FiliereDAO target = new FiliereDAO();
            List<Filiere> expected = null; 
            List<Filiere> actual;
            actual = target.Select();
        }

        /// <summary>
        ///Test pour Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            FiliereDAO target = new FiliereDAO(); 
            Filiere f = null; 
            target.Update(f);
        }
    }
}
