using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;
        public delegate bool Predicate<T>(T obj);
        //Jedi-ket tároló lista.
        List<Jedi> members = new List<Jedi>();
        //Új Jedi-t ad a members listához.
        public void Add(Jedi newJedi)
        {
            if (CouncilChanged != null)
                CouncilChanged("Új taggal bővültünk");
            members.Add(newJedi);
        }
        //A listában lévő utolsó Jedi-t eltávolítja.
        public void Remove()
        {
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else
                    CouncilChanged("A tanács elesett!");
            }
        }
        //Azt vizsgálja meg, hogy a paraméterként kapott Jedi-nek kisebb e a midi chlori-án értéke mint 300.
        static bool JediFilter(Jedi j)
        {
            if (j.MidiChlorianCount <= 300)
                return true;
            else return false;
        }
        //Visszaad egy listát, amiben olyan Jedi-k szerepelnek, melyek kezdők (midiChlorianCount <= 300).
        public List<Jedi> getBeginners()
        {
            List<Jedi> beginners = new List<Jedi>();
            beginners = members.FindAll(JediFilter);
            return beginners;
        }

    }
}
