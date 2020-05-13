using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public  class Jedi
    {
        //Jedi nevét tárolja.
        [XmlAttribute("Nev")]
        public string Name { get; set; }
        //Jedi midi chlorian számát tárolja.
        private int midiChlorianCount;
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get { return midiChlorianCount; }
            set
            {
                if (value < 10)
                    throw new ArgumentException("You are not a true jedi!");
                midiChlorianCount = value;

            }
        }
        //Ez a függvény tudja a Jedi-t klónozni.
        public Jedi cloning()
        {
            //Kiírjuk egy txt file-ba az adott Jedi attribútumait.
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, this);
            stream.Close();
            //A txt file-ból visszaolvassuk az adott Jedi attribútumait.
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();

            return clone;

        }
    }
}
