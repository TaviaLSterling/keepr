using System;
using System.Collections.Generic;


namespace keepr.Models
{

    public class Vault
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string UserId {get; set;}

          public Vault(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }
        public Vault()
        {

        }


    }
}
