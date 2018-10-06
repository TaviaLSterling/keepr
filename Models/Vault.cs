using System;
using System.Collections.Generic;


namespace keepr.Models
{

    public class Vault
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int UserId {get; set;}

          public Vault(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Vault()
        {

        }


    }
}
