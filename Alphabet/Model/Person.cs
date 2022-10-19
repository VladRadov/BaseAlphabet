using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphabet.Model
{
    public class Person
    {
        public static  List<Person> List { get; set; }

        public int Id { get; set; }

        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Index { get; set; }
        public DateTime DateExpire { get; set; }     
        public string Sex { get; set; }
        public string Country { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Additionally { get; set; }
        public string Task { get; set; }        
        public string TaskKey { get; set; }

        public DataTable DT { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMulty { get; set; }
        public int Route { get; set; }
        public int Type { get; set; }
    }
}
