using BinaryDataStreams;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Datenreihe datenreihe = new Datenreihe();
        string csvDateipfad = @"C:\Users\Steven\source\repos\BinaryDataStreams\BinaryDataStreams\werteliste.csv";
        datenreihe.LadeCSV(csvDateipfad);

        foreach (var messung in datenreihe.Messungen)
        {
            //Console.WriteLine(messung.ToString());
        }

        string binDateiname = "daten.bin";
        datenreihe.SpeichereBinaer(binDateiname);

        long csvFileSize = new FileInfo(csvDateipfad).Length;
        long binFileSize = new FileInfo(binDateiname).Length;

        Console.WriteLine($"Größe CSV:   {csvFileSize} Bytes");
        Console.WriteLine($"Größe Binär: {binFileSize} Bytes");

        if (csvFileSize > binFileSize)
        {
            Console.WriteLine("Die binäre Datei ist kleiner als die CSV-Datei.");
        }
        else if (csvFileSize < binFileSize)
        {
            Console.WriteLine("Die binäre Datei ist größer als die CSV-Datei.");
        }
        else
        {
            Console.WriteLine("Die Größen der beiden Dateien sind gleich.");
        }
    }
}
