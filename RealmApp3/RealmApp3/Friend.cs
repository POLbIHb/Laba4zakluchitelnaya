using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace RealmApp3
{
    public class Friend : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Exp { get; set; }
    }
}
