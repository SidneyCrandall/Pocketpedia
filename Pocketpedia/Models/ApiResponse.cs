//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Pocketpedia.Models
//{
//    public class ApiResponse
//    {
//        public string name { get; set; }
//        public int totalItems { get; set; }
//        public List<Item> items { get; set; }
//    }

//    public class Item
//    {
//        public Name name { get; set; }
//        public string id { get; set; }
//        public string fileName { get; set; }
//        public Availability availability { get; set; }
//        public string speed { get; set; }
//        public string shadow { get; set; }
//        public int price { get; set; }
//        public string catchPhrase { get; set; }
//        public string imageUrl { get; set; }
//        public string iconUrl { get; set; }
//        public string museumPhrase { get; set; }
//    }

//    public class Name
//    {
//        public string nameUSen { get; set; }
//        public string nameEUen { get; set; }
//        public string nameEUnl { get; set; }
//        public string nameEUde { get; set; }
//        public string nameEUes { get; set; }
//        public string nameUSes { get; set; }
//        public string nameEUfr { get; set; }
//        public string nameUSfr { get; set; }
//        public string nameEUit { get; set; }
//        public string nameCNzh { get; set; }
//        public string nameTWzh { get; set; }
//        public string nameJPja { get; set; }
//        public string nameKRko { get; set; }
//        public string nameEUru { get; set; }
//    }

//    public class Availability
//    {
//        public MonthArrayNorthern northernMonths { get; set; }
//        public MonthArraySouthern southernMonths { get; set; }
//        public int time { get; set; }
//        public bool isAllDay { get; set; }
//        public bool isAllYear { get; set; }
//        public string location { get; set; }
//        public string rarity { get; set; }
//    }

//    public class MonthArrayNorthern
//    {
//        public int month { get; set; }
//    }

//    public class MonthArraySouthern
//    {
//        public int month { get; set; }
//    }
//}
