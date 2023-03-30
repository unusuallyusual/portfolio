using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class IndicatorsRepository 
{
    private readonly string path = Environment.CurrentDirectory + "\\gameData.xml";
    public List<LevelIndicators> Indicators { get; set; }


    public void DataSerialization()
    {
        List<LevelIndicators> myList = new List<LevelIndicators>();
        myList.AddRange(Indicators);

        Stream stream = File.OpenWrite(path);
        XmlSerializer xmlSer = new XmlSerializer(typeof(List<LevelIndicators>));
        xmlSer.Serialize(stream, myList);

        stream.Close();
    }

    private List<LevelIndicators> MakeList(int l)
    {
        List<LevelIndicators> Indicators = new List<LevelIndicators>();

        for (int i = 0; i < l; i++)
        {
            Indicators.Add(new LevelIndicators());
        }

        return Indicators;
    }

    private IndicatorsRepository()
    {
        Indicators = new List<LevelIndicators>();

        XmlSerializer xs = new XmlSerializer(typeof(List<LevelIndicators>));

        if (File.Exists(path))
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                Indicators = (List<LevelIndicators>)xs.Deserialize(stream);
            }
        else
        {
            Indicators = MakeList(6);

            Stream stream = File.OpenWrite(path);
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<LevelIndicators>));
            xmlSer.Serialize(stream, Indicators);

            stream.Close();
        }
    }

    public static IndicatorsRepository DataDeSerialization()
    {
        return new IndicatorsRepository();
    }
}

