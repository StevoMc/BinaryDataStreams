using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryDataStreams
{
    public class Datenreihe
    {
        private List<Messung> messungen;

        public Datenreihe()
        {
            messungen = new List<Messung>();
        }

        public List<Messung> Messungen { get => messungen; set => messungen = value; }

        public void LadeCSV(string dateipfad)
        {
            messungen.Clear();

            using (var reader = new StreamReader(dateipfad))
            {
                string line;
                bool isFirstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    var parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        var messung = new Messung();
                        messung.Messwert1 = long.Parse(parts[0]);
                        messung.Messwert2 = double.Parse(parts[1].Replace(',', '.'));
                        messung.Messwert3 = ushort.Parse(parts[2]);
                        messung.Messwert4 = bool.Parse(parts[3]);
                        messungen.Add(messung);
                    }
                }
            }
        }

        public void SpeichereBinaer(string dateiname)
        {
            using (var stream = new FileStream(dateiname, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    foreach (var messung in messungen)
                    {
                        writer.Write(messung.Messwert1);
                        writer.Write(messung.Messwert2);
                        writer.Write(messung.Messwert3);
                        writer.Write(messung.Messwert4);
                    }
                }
            }
        }
    }
}
