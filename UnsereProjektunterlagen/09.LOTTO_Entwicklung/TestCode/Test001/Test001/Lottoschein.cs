﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Test001
{
    public class Lottoschein
    {
        
        // Lottoschein besteht aus: Losnummer, 12 Spiele, superzahl 
        public string Losnummer { get; set; }

        public string SuperZahl { get; set; }

        public ArrayList spiele = new ArrayList();

        public int[] spiel = new int[6];

        private string ans; 

        
        // Konstruktor: 

        public Lottoschein(string losnummer)
        {
            this.Losnummer = losnummer;
            this.SuperZahl = Convert.ToString(Losnummer[Losnummer.Length - 1]);  
        }

        // To do: Konsoleneingabe heraustrennen...
        public void fuelleSpiel()
        {
            do
            {          
            for (int i = 0; i < spiel.Length; i++)
            {
                Console.WriteLine("Bitte geben Sie die {0}. Zahl ein: ", i+1);
                try
                {
                    spiel[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Fehlerhafte Eingabe. Bitte erneute Eingabe: ");
                    i--;
                    continue;
                }

                if ((spiel[i] < 1) || (spiel[i] > 49))
                {
                    Console.WriteLine("Fehlerhafte Eingabe. Zahl ist nicht im Bereich.");
                    i--;
                    continue; 
                }
               
                for (int k = 0; k < i; k++)
                {
                    if (spiel[i] == spiel[k])
                    {
                        Console.WriteLine("Fehler: Zahl wurde bereits eingegeben");
                        i--; 
                    }
                   
                }
            }

            spiele.Add(spiel);
            Console.WriteLine("Wollen Sie ein weiteres Spiel tippen? (J / N)");
            spiel = new int[6]; 
            ans = Console.ReadLine();
            if (ans.ToUpper() == "J")
            {
               
            }
            else if (ans.ToUpper() == "N")
            {

            }
            else
            {
                Console.WriteLine("Fehlerhafte Eingabe");
            }
            } while (ans.ToUpper() == "J");
        }

        //public void AddSpiele(int[] spiel)
        //{
            
        //}

        public void RemoveSpiel(int pos)
        {
            spiele.RemoveAt(pos);
        }

        public void UpdateSpiel(int[] tippNeu)
        {
            spiele.RemoveAt(spiele.Count - 1);
            spiele.Add(tippNeu);
        }

        public void ZeigeSpiele()
        {
            foreach (int[] s in spiele)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    Console.Write(s[i] + ", ");
                }
                Console.WriteLine();
            }
        }
        
        
       

        public void Add(int[] spiel)
        {
            spiele.Add(spiel);
        }

          
    }
}
