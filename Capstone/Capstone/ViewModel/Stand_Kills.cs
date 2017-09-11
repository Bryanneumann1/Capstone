using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.ViewModel
{
    public class Stand_Kills
    {
        public Stand stand { get; set; }

        public Kills kills { get; set; }

        public IQueryable<Kills> killsCollection { get; set; }

        public IQueryable<Stand> standCollection { get; set; }


        //bryanneumann1-facilitator @gmail.com
        //access_token$sandbox$d933bgxzjbcz5xbj$5302d0e67884c58df00a4c34bed8713a







    }
}