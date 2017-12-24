using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace ASPAP
{
    class Way
    {
        public  LinkedList<Stripe> stripes { get; set; }
        public string way { get; set; }

        public Way() { } 

        public Way(string way)
        {
            this.way = way; 
            stripes = new LinkedList<Stripe>();
        }

        public Way(LinkedList<Stripe> stripes)
        {
            this.stripes = stripes;
        }

        

        public void addStripe(Stripe newStripe)
        {
            stripes.AddLast(newStripe);
        }
        
    }
}
