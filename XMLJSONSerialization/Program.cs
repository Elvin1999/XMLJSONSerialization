using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLJSONSerialization
{

    #region XML
    [Serializable]
    struct Car
    {
        [JsonIgnore]
        public int Year { get; set; }
        [JsonProperty("ModelOfCar")]
        public string Model { get; set; }
        [JsonRequired]
        public string Vendor { get; set; }

        public override string ToString()
        {
            return $"{Model} - {Vendor} - {Year}";
        }
    }

    //class Program
    //{
    //    static void Write()
    //    {
    //        List<Car> cars = new List<Car>
    //        {
    //            new Car
    //            {
    //                 Model="Mustang",
    //                  Vendor="Ford",
    //                   Year=1964
    //            },
    //            new Car
    //            {
    //                 Model="Charger",
    //                  Vendor="Dodge",
    //                   Year=2000
    //            },
    //            new Car
    //            {
    //                 Model="Veyron",
    //                  Vendor="Bugatti",
    //                   Year=2020
    //            },
    //            new Car
    //            {
    //                 Model="Niva",
    //                  Vendor="Chevrolet",
    //                   Year=2004
    //            },
    //            new Car
    //            {
    //                 Model="F30",
    //                  Vendor="BMW",
    //                   Year=2018
    //            },
    //            new Car
    //            {
    //                 Model="ix35",
    //                  Vendor="Hyundai",
    //                   Year=1964
    //            },
    //        };



    //        using (var writer=new XmlTextWriter("car.xml",Encoding.UTF8))
    //        {
    //            writer.Formatting = Formatting.Indented;
    //            writer.WriteStartDocument();

    //            writer.WriteStartElement("Cars");

    //            foreach (var car in cars)
    //            {
    //                writer.WriteStartElement("Car");

    //                writer.WriteAttributeString(nameof(car.Vendor), car.Vendor);
    //                writer.WriteAttributeString(nameof(car.Model), car.Model);
    //                writer.WriteAttributeString(nameof(car.Year), car.Year.ToString());

    //                writer.WriteEndElement();
    //            }


    //            writer.WriteEndElement();

    //            writer.WriteEndDocument();
    //        }



    //    }


    //    static void Read()
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        doc.Load("car.xml");
    //        var root = doc.DocumentElement;

    //        if (root.HasChildNodes)
    //        {
    //            foreach (XmlNode car_node in root.ChildNodes)
    //            {
    //                var c = new Car
    //                {
    //                    Vendor = car_node.Attributes[0].Value,
    //                    Model = car_node.Attributes[1].Value,
    //                    Year = int.Parse(car_node.Attributes[2].Value)
    //                };
    //                Console.WriteLine(c);
    //            }
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        // Write();
    //        //Read();

    //    }
    //}
    #endregion

    #region XmlSerialization


    //public class Program
    // {
    //     public static void XmlSerialize()
    //     {
    //         var army = new TranslatorArmy
    //         {
    //             Name = "Step IT Academy",
    //             Location = "Koroglu Rehimov",
    //             Translators = new List<Translator>
    //              {
    //                  new Translator("Tural", "Eliyev", 1)
    //                  {
    //                      Subjects=new List<Subject>
    //                      {
    //                          new Subject
    //                          {
    //                              Name="C++",
    //                              Degree=42,
    //                              Lessons=30
    //                          } ,
    //                           new Subject
    //                          {
    //                              Name="C#",
    //                              Degree=30,
    //                              Lessons=50
    //                          } ,
    //                      }
    //                  },
    //                  new Translator("Ehmed", "Axmedli", 20)
    //                  {
    //                      Subjects=new List<Subject>
    //                      {
    //                          new Subject
    //                          {
    //                              Name="Asp.Net",
    //                              Degree=42,
    //                              Lessons=100
    //                          } ,
    //                           new Subject
    //                          {
    //                              Name="HTML/CSS",
    //                              Degree=30,
    //                              Lessons=50
    //                          } ,
    //                      }
    //                  },
    //                  new Translator("Leyla", "Mammadova", 100)
    //                  {
    //                      Subjects=new List<Subject>
    //                      {
    //                          new Subject
    //                          {
    //                              Name="Web Design",
    //                              Degree=42,
    //                              Lessons=30
    //                          } ,
    //                           new Subject
    //                          {
    //                              Name="Photoshop",
    //                              Degree=30,
    //                              Lessons=50
    //                          } ,
    //                      }
    //                  },
    //              }
    //         };

    //         var xml = new XmlSerializer(typeof(TranslatorArmy));
    //         using (var fs=new FileStream("Translator.xml",FileMode.OpenOrCreate))
    //         {
    //             xml.Serialize(fs, army);
    //         }
    //         Console.WriteLine("Ready!");
    //     }

    //     public static void XmlDeserialize()
    //     {
    //         TranslatorArmy army = null;

    //         var xml = new XmlSerializer(typeof(TranslatorArmy));

    //         using (var fs=new FileStream("Translator.xml",FileMode.OpenOrCreate))
    //         {
    //             army = xml.Deserialize(fs) as TranslatorArmy;
    //             Console.WriteLine("Deserialized!");
    //         }
    //         Console.WriteLine(army);

    //     }

    //     static void Main(string[] args)
    //     {
    //         //XmlSerialize();
    //         XmlDeserialize();
    //     }
    // }

    #endregion


    #region BinarySerialization

    //class Program
    //{
    //    static void BinarySerialize()
    //    {
    //        var database = new Translator[]
    //        {
    //            new Translator("Akif","Akifli",1),
    //            new Translator("Leyla","Mammadova",2),
    //            new Translator("Tural","Eliyev",3),
    //            new Translator("Nergiz","Nergizli",4)
    //        };

    //        var bf = new BinaryFormatter();
    //        using (var fs=new FileStream("file.bin",FileMode.OpenOrCreate))
    //        {
    //            bf.Serialize(fs, database);
    //        }
    //        Console.WriteLine("Ready!");



    //    }
    //    static void BinaryDeserialize()
    //    {
    //        Translator[] db = null;

    //        var bf = new BinaryFormatter();
    //        using (var fs=new FileStream("file.bin",FileMode.OpenOrCreate))
    //        {
    //            db = bf.Deserialize(fs) as Translator[];
    //        }

    //        foreach (var item in db)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        // BinarySerialize();
    //        BinaryDeserialize();
    //    }
    //}
    #endregion




    #region JsonSerialization
    //class Program
    //{
    //    static void JsonSerialize()
    //    {
    //        List<Car> cars = new List<Car>
    //        {
    //            new Car
    //            {
    //                 Model="Mustang",
    //                  Vendor="Ford",
    //                   Year=1964
    //            },
    //            new Car
    //            {
    //                 Model="Charger",
    //                  Vendor="Dodge",
    //                   Year=2000
    //            },
    //            new Car
    //            {
    //                 Model="Veyron",
    //                  Vendor="Bugatti",
    //                   Year=2020
    //            },
    //            new Car
    //            {
    //                 Model="Niva",
    //                  Vendor="Chevrolet",
    //                   Year=2004
    //            },
    //            new Car
    //            {
    //                 Model="F30",
    //                  Vendor="BMW",
    //                   Year=2018
    //            },
    //            new Car
    //            {
    //                 Model="ix35",
    //                  Vendor="Hyundai",
    //                   Year=1964
    //            },
    //        };

    //        var serializer = new JsonSerializer();
    //        using (var sw=new StreamWriter("json.json"))
    //        {
    //            using (var jw=new JsonTextWriter(sw))
    //            {
    //                jw.Formatting = Newtonsoft.Json.Formatting.Indented;
    //                serializer.Serialize(jw, cars);
    //            }
    //        }
    //    }

    //    static void JsonDeserialize()
    //    {
    //        Car[] cars = null;
    //        var serializer = new JsonSerializer();

    //        using (var sr=new StreamReader("json.json"))
    //        {
    //            using (var jr=new JsonTextReader(sr))
    //            {
    //                cars = serializer.Deserialize<Car[]>(jr);
    //            }
    //            foreach (var item in cars)
    //            {
    //                Console.WriteLine(item);
    //            }
    //        }


    //    }
    //    static void Main(string[] args)
    //    {
    //        JsonSerialize();
    //       // JsonDeserialize();
    //    }
    //}
    #endregion



    #region LINQ
    class Program
    {
        static void Main(string[] args)
        {
            //1.Query
            //int[] scores = new int[] { 97, 92, 78, 81, 60, 55 };

            //var scoreQuery =
            //    from score in scores
            //    where score > 80
            //    select score;

            //foreach (var item in scoreQuery)
            //{
            //    Console.WriteLine(item);
            //}

            List<Car> cars = new List<Car>
            {
                new Car
                {
                    Model="Mustang",
                    Vendor="Ford",
                    Year=1964
                },
                 new Car
                {
                    Model="Charger",
                    Vendor="Dodge",
                    Year=2000
                },
                   new Car
                {
                    Model="Veyron",
                    Vendor="Bugatti",
                    Year=2020
                },
                     new Car
                {
                    Model="Niva",
                    Vendor="Chevrolet",
                    Year=2000
                },
                       new Car
                {
                    Model="745",
                    Vendor="BMW",
                    Year=2008
                },
                         new Car
                {
                    Model="ix35",
                    Vendor="Hyundai",
                    Year=2016
                },
                                  new Car
                {
                    Model="F12 Berlinetta",
                    Vendor="Ferrari",
                    Year=2016
                },
            };

            //2.Query
            //var newcars =
            //    from car in cars
            //    where car.Year >= 2006
            //    orderby car.Year descending
            //    select car;


            //foreach (var item in newcars)
            //{
            //    Console.WriteLine(item);
            //}



            //3.Query

            //var sameYears =
            //    from car in cars
            //    where car.Year>1900
            //    group car by car.Year into cargroup
            //    select cargroup;

            //foreach (var item in sameYears)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var c in item)
            //    {
            //        Console.WriteLine(c);
            //    }
            //}




            //Regular Expression

            //string pattern = @"\b[M]\w+";

            //Regex rg = new Regex(pattern);

            //string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";

            //MatchCollection matchedAuthors = rg.Matches(authors);

            //for (int i = 0; i < matchedAuthors.Count; i++)
            //    Console.WriteLine(matchedAuthors[i].Value);




            //Regex r = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");
            ////class Regex Repesents an immutable regular expression.  

            //string[] str = { "+91-9678967101", "9678967101", "+91-9678-967101", "+91-96789-67101", "+sss" };
            ////Input strings for Match valid mobile number.  
            //foreach (string s in str)
            //{
            //    Console.WriteLine("{0} {1} a valid mobile number.", s,
            //    r.IsMatch(s) ? "is" : "is not");
            //    //The IsMatch method is used to validate a string or  
            //    //to ensure that a string conforms to a particular pattern.  
            //}



            //sade versiyasi
            string email = "ramizgmail.com";
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(email))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
    #endregion
}
