﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace Lotto
{
	class GewinnklassenRechner
	{
		// Zusammengesetzte Strings mittels Stringbuilder werden in ArrayLists gespeichert und 
		// an der GUI ausgegeben.
		public ArrayList ErgebnisArr = new ArrayList();
		public ArrayList AktuelleZiehungList = new ArrayList();
		StringBuilder aktuelleZiehungBuilder = new StringBuilder();
		StringBuilder myStringBuilder = new StringBuilder();

	    /// <summary>
		/// Dem Konstruktor der Klasse Gewinnklassenrechner werden 3 Parameter übergeben. Innerhalb des Konstruktors 
		/// werden die gespeicherten Lottoscheine mit der aktuellen Ziehung verglichen, ausgewertet und die Ergebnisse 
		/// jeweils als String formatiert einer Arraylist übergeben.
		/// </summary>
		/// <param name="lottoschein"></param>
		/// <param name="aktuelleZiehung"></param>
		/// <param name="ziehungSuperzahl"></param>
		public GewinnklassenRechner(Lottoschein lottoschein, int[] aktuelleZiehung, int ziehungSuperzahl)
		{
			// Mit StringBuilder Klasse wird ein String für die Ausgabe an der GUI kreiert, der die aktuelle Ziehung
			// in einer ArrayList speichert.  
	        aktuelleZiehungBuilder.Append("Ziehung: ");

			for (int i = 0; i < aktuelleZiehung.Length; i++)
			{
				if (i == 0)
				{
					aktuelleZiehungBuilder.Append(aktuelleZiehung[i]);
				}
				else
				{
					aktuelleZiehungBuilder.Append("," + aktuelleZiehung[i]); 
				}
			}
			aktuelleZiehungBuilder.Append(" - (" + ziehungSuperzahl + ")\n");
			AktuelleZiehungList.Add(aktuelleZiehungBuilder.ToString());

			// Jedes Spiel eines Lottoscheins wird mit den aktuellen Ziehungszahlen verglichen und das Ergebnis
			// und die Gewinnstufen als Strings formatiert in einer ArrayList gespeichert. 
		    foreach (KeyValuePair<int, SortedSet<int>> spiel in lottoschein.Spiele)
			{
				var fuegeKommaEin = false;
			    myStringBuilder.Clear();
				var counter = 0;
				myStringBuilder.Append(spiel.Key + "." + "  ");

			    foreach (int i in spiel.Value)
			    {
					if (aktuelleZiehung.Contains(i))
					{
						if (fuegeKommaEin)
						{
							
							myStringBuilder.Append(",");
						}
						else
						{
							fuegeKommaEin = true;                             
						}
						myStringBuilder.Append(i);
						counter++;
					}
					
				}

				if (counter > 1)
				{
					myStringBuilder.Append("         Getroffen " + counter);
					if (lottoschein.SuperZahl == ziehungSuperzahl)
					{
						myStringBuilder.Append(" + Superzahl " + ziehungSuperzahl); 
					}
				}
				ErgebnisArr.Add(myStringBuilder.ToString());       
			}		   
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string[] GetErgebnisse()
		{
			string[] hilfsvariable = new string[ErgebnisArr.Count];

			for (int i = 0; i < ErgebnisArr.Count; i++)
			{
				hilfsvariable[i] = (string)ErgebnisArr[i]; 
			}
			
			return hilfsvariable; 
		}

	}
}
