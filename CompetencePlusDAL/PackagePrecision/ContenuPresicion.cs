using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetencePlus.PackagePrecision
{
    public class ContenuPresicion
    {

        string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        double duree;

        public double Duree
        {
            get { return duree; }
            set { duree = value; }
        }
        int order;

        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        public ContenuPresicion() { }
        public ContenuPresicion(string nom, string description, double duree, int order) 
        {
            this.Nom = nom;
            this.Description = description;
            this.Duree = duree;
            this.Order = order;
        }
        public override string ToString()
        {
            return this.nom;
        }
    }
}
