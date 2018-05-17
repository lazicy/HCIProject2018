using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HCI2018PZ4._3EURA78_2015.Model
{
    [Serializable]
    public class Kolekcije
    {
        public ObservableCollection<Vrsta> Vrste = new ObservableCollection<Vrsta>();
        public ObservableCollection<Tip> Tipovi = new ObservableCollection<Tip>();
        public ObservableCollection<Etiketa> Etikete = new ObservableCollection<Etiketa>();

        public Kolekcije()
        {

        }

        private static Kolekcije instancaKolekcije = null;
        public static Kolekcije InstancaKolekcije
        {
            get
            {
                if (instancaKolekcije == null)
                {
                    instancaKolekcije = new Kolekcije();
                }
                return instancaKolekcije;
                    
            }
            set
            {
                instancaKolekcije = value;
             }
        }

        public static void Sacuvaj()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML Files |*.xml";
            if (saveDialog.ShowDialog() == true)
            {
                /*  FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create);
                  BinaryFormatter formatter = new BinaryFormatter();
                  try
                  {
                      formatter.Serialize(fs, InstancaKolekcije);
                  } catch
                  {
                      Console.WriteLine("Failed to serialize.");
                      throw;
                  } finally
                  {
                      fs.Close();
                  }*/

                using (var stream = new FileStream(saveDialog.FileName, FileMode.Create))
                {
                    var Xml = new XmlSerializer(typeof(Kolekcije));
                    Xml.Serialize(stream, Kolekcije.InstancaKolekcije);
                }
            }
        }
        
        public static void Ucitaj()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "XML Files |*.xml";
            if (openDialog.ShowDialog() == true)
            {

                using (var stream = new FileStream(openDialog.FileName, FileMode.Open))
                {
                    var Xml = new XmlSerializer(typeof(Kolekcije));
                    InstancaKolekcije =(Kolekcije) Xml.Deserialize(stream);
                }
            }
        }

        public void PrintVrsta()
        {
            foreach (Vrsta v in Vrste)
            {
                Console.WriteLine("IDvrste: {0} | Naziv vrste: {1}", v.Id, v.Naziv);
            }
        }

        public void PrintTipova()
        {
            foreach (Tip t in Tipovi)
            {
                Console.WriteLine("IDtipa: {0} | Naziv tipa: {1}", t.Id, t.Naziv);
            }
        }

        public void PrintEtiketa()
        {
            foreach (Etiketa e in Etikete)
            {
                Console.WriteLine("IDetikete: {0} | Boja etikete: {1}", e.Id, e.Boja);
            }
        }



    }
}
