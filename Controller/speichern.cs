using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Controller
{
    [Serializable()]
    class speichern : Makro
    {
        public string row;
        static BinaryFormatter bin;
        static FileStream mystream;

        public speichern(string str)
        {
            row = str;
        }

        static void Mainstart(string[] args)
        {
            bin = new BinaryFormatter();
            Makro obj = new Makro(xa);
            SerializeObject(obj);
            //Makro oldobj = DeserializeObject();
        }
        public static void SerializeObject(object obj)
        {
            mystream = new FileStream(@"C:\\datei.dat", FileMode.Create);
            bin.Serialize(mystream, obj);
            mystream.Close();
        }

        public static Makro DeserializeObject()
        {
            FileStream fs = new FileStream(@"C:\\datei.dat", FileMode.Open);
            return (speichern)bin.Deserialize(fs);
        }
    }
}
