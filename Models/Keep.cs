using System;
using System.Collections.Generic;


namespace keepr.Models
{

    public class Keep
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int IsPrivate {get; set;}
        public string Img {get; set;}
        public int Views {get; set;}
        public int Shares {get; set;}
        public int Keeps {get; set;}



    }
}
