﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    internal class Kerattavat
    {
        public void PickUp(string juttu)
        {
            // store
            var dico = new Dictionary<string, Delegate>();
            dico["ReppuPB"] = new Func<string, string>(Func1);
            dico["TakkiPB"] = new Func<string, string>(Func2);
            dico["KengatPB"] = new Func<string, string>(Func3);
            dico["HuiviPB"] = new Func<string, string>(Func4);
            dico["TaskulamppuPB"] = new Func<string, string>(Func5);
            dico["MankkaPB"] = new Func<string, string>(Func6);
            dico["SprayPB"] = new Func<string, string>(Func7);
            dico["SipsitPB"] = new Func<string, string>(Func8);
            dico["EsPB"] = new Func<string, string>(Func9);

            // and later invoke
            var res = dico[juttu].DynamicInvoke(juttu);
        }

        
         //Esimerkki funktio mihin voi laittaa haluamansa tekstin mikä tavara
         /*
          * 
        private string Func1(string arg)
        {
            MessageBox.Show("Tähän tulee teksti mikä tavara")
            return null;
        }

        */

        private string Func1(string arg)
        {
            return null;
        }

        private string Func2(string arg)
        {
            return null;
        }
        private string Func3(string arg)
        {
            return null;
        }
        private string Func4(string arg)
        {
            return null;
        }
        private string Func5(string arg)
        {
            return null;
        }
        private string Func6(string arg)
        {
            return null;
        }
        private string Func7(string arg)
        {
            return null;
        }
        private string Func8(string arg)
        {
            return null;
        }
        private string Func9(string arg)
        {
            return null;
        }
        private string Func10(string arg)
        {
            return null;
        }
        private string Func11(string arg)
        {
            return null;
        }
    }
}
