using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompetencePlus.Tools;

namespace TestProjectDAL
{
    [TestClass()]
    public class Config
    {
        [ClassInitialize()]
        public void SetUp()
        {
            new DataBaseCreator(MyConnection.DataBaseName).InitialisationDatabase();
        }

       [ClassCleanup()]
        public void TearDown()
        {
        }
    }
}
