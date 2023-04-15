using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace Classe
{
    [DataContract]
    public class Jeux
    {
        public Jeux(string chemin, string nom)
        {
            Chemin = chemin;
            Nom = nom;
            ListCategory = new List<Category>();
        }

        public Jeux(string chemin, string nom, List<Category> listCategory)
        {
            Chemin = chemin;
            Nom = nom;
            ListCategory = listCategory;
        }

        [DataMember]
        public string Chemin { get; set; }
        private string chemin;
        [DataMember]
        public string Nom { get; set; }
        private string nom;
        [DataMember]
        public List<Category> ListCategory { get; set; }
        private List<Category> listCategory;

        public void Launch()
        {
            Process.Start(this.Chemin);
        }

        public bool JeuxValide()
        {
            if (!Nom.Contains("Crash")
                && !Nom.Contains("crash")
                && !Nom.Contains("error")
                && !Nom.Contains("Error")
                && !Nom.Contains("tools")
                && !Nom.Contains("Win64")
                && !Nom.Contains("x86")
                && !Nom.Contains("setup")
                && !Nom.Contains("Helper")
                && !Nom.Contains("Ux")
                && !Nom.Contains("Mod")
                && !Nom.Contains("Cheat")
                && !Nom.Contains("x64")
                && !Nom.Contains("Uninstall")
                && !Nom.Contains("installer")
                && !Nom.Contains("Installer")
                && !Nom.Contains("jaccess")
                && !Nom.Contains("java")
                && !Nom.Contains("Converter")
                && !Nom.Contains("script")
                && !Nom.Contains("Script")
                && !Nom.Contains("encode")
                )
            {
                return true;
            }
            else return false;
        }

        public void MiseEnFormeNom()
        {
            this.Nom = this.Chemin.Split("\\").Last().Replace(".exe", "").Split("/").Last();
        }

        public void AjouterCategory(Category category)
        {
            if (!this.ListCategory.Contains(category))
            {
                this.ListCategory.Add(category);
            }
        }

        public string EcrireCategory()
        {
            string text = new String("");
            if( ListCategory == null)
            {
                return "Wesh";
            }
            for (int i = 0; i < ListCategory.Count(); i++)
            {
                text = text +" & "+ ListCategory[i];
            }
            return text;
        }
    }

}
