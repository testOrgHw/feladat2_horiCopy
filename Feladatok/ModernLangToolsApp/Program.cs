using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    //Ezt a delegátot arra használjuk, hogy kiírjuk ha a JediCouncil változott(Új tag/Tag eltávolítása/Tanács elesett).
    public delegate void CouncilChangedDelegate(string message);
    class Program
    {
        static void Main(string[] args)
        {
          
            CloneTest();

            JediCouncilTest();

            JediFilterTest();
        }
        //A függvény először egy új Jedi-t hoz létre, majd az attribútumainak megadása után kiírja azokat.
        //Ezután a clone() függvénnyel leklónozza az adott Jedi-t és kiírja annak az attribútumait is.
        [Description("Feladat2")]
        static void CloneTest()
        {
            Jedi jedi = new Jedi();
            jedi.Name = "Anakin";
            jedi.MidiChlorianCount = 20001;
            Console.WriteLine(jedi.Name + " " + jedi.MidiChlorianCount);

            Jedi cloneJedi = jedi.cloning();
            Console.WriteLine(cloneJedi.Name + " " + cloneJedi.MidiChlorianCount);
        }
        //A delegációt működését mutatja be.
        //Egy JediCouncil példányt hoz létre és ehhez Jedi-ket ad hozzá és távolít el.
        [Description("Feladat3")]
        static void JediCouncilTest()
        {
            JediCouncil council = new JediCouncil();
            council.CouncilChanged += MessageReceived;

            Jedi jedi1 = new Jedi();
            Jedi jedi2 = new Jedi();

            jedi1.Name = "Obi-Wan";
            jedi1.MidiChlorianCount = 11234;
            jedi2.Name = "Yoda";
            jedi2.MidiChlorianCount = 18263;

            council.Add(jedi1);
            council.Add(jedi2);

            council.Remove();
            council.Remove();
        }

        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }
        //Jedi-k hozzáadása a paraméterként kapott JediCouncil-hez.
        static void addMembers(JediCouncil council)
        {

            Jedi jedi1 = new Jedi();
            Jedi jedi2 = new Jedi();
            Jedi jedi3 = new Jedi();

            jedi1.Name = "Obi-Wan";
            jedi1.MidiChlorianCount = 11234;
            jedi2.Name = "Yoda";
            jedi2.MidiChlorianCount = 100;
            jedi3.Name = "Anakin";
            jedi3.MidiChlorianCount = 21223;

            council.Add(jedi1);
            council.Add(jedi2);
            council.Add(jedi3);
        }
		
        [Description("Feladat4")]
        static void JediFilterTest()
        {
            JediCouncil council = new JediCouncil();

            addMembers(council);

            List<Jedi> lowMidiClorian = new List<Jedi>();
            lowMidiClorian = council.getBeginners();

            foreach (Jedi jedi in lowMidiClorian)
            {
                Console.WriteLine(jedi.Name);
            }

        }
    }
}

