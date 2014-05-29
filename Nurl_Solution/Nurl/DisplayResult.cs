/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 27/05/2014
 * Time: 15:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Nurl
{
	/// <summary>
	/// Description of DisplayResult.
	/// </summary>
	public class DisplayResult
	{
		public DisplayResult()
		{
		}
		
		/// <summary>
		/// Formattage pour l'opton -times
		/// </summary>
		/// <param name="ts"></param>
		public static void displayTimes(double time, int i){
			StringBuilder sb = new StringBuilder();
			string end = i == 0 ? "er" : "eme";
			sb.AppendLine(String.Format("{0}{1} test) {2}ms ",i+1,end,time));
			Console.WriteLine(sb.ToString());
		}
		
		
		public static void displayMethod(EnumMethod meth){
			string toDisplay = string.Empty;
			switch(meth){
				case EnumMethod.GET:
					toDisplay = "Utilisation de la méthode GET : récupération du contenu en cours";
					break;
				case EnumMethod.TEST:
					toDisplay = "Utilisation de la méthode TEST : tests de récupération du contenu en cours";
					break;
			}
			
			Console.WriteLine("{0}\n\n",toDisplay);
		}
		
		public static void displayContent(string content){
			Console.WriteLine("Voici le contenu de l'url :\n\n{0}",content);
		}
		
		public static void displayStateSave(bool isOk){
			string finalstate = isOk ? "Le fichier a bien été crée et contient le contenu de l'url" 
				: "L'url n'est pas valide, ou l'écriture dans le fichier a rencontré un problème. Fichier créé.";
			Console.WriteLine(finalstate);
		}
		
		public static void displayAvg(double ts,int nb){
			Console.WriteLine("La récupération du contenu a été éxécuté {0} fois. \n\nLa moyenne des temps est de {1} ms",nb,Math.Round(ts, 2));
		}
		/// <summary>
		/// Affichage de l'aide
		/// </summary>
		public static void displayHelp(){
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("GET: Permet de récupérer le contenu d'une url.");
			sb.AppendLine("\nCette option ne peut être utilisé qu'avec les options suivantes :");
			sb.AppendLine("\t -url URLPATH: Permet de cibler l'url choisie");
			sb.AppendLine("\t [-save FILEPATH]: Permet de stocker le contenu du site dans un fichier");
			sb.AppendLine("\n\nTEST: Permet de tester la récupération du contenu d'une url");
			sb.AppendLine("\nCette option ne peut être utilisée qu'avec les options suivantes :");
			sb.AppendLine("\t -url URLPATH: Permet de cibler l'url choisie");
			sb.AppendLine("\t -times NUM [-avg]: Permet de tester le temps de réponse lors de la récupération, NUM est le nombre de fois de répétition");
			sb.AppendLine("\tL'option -avg permet de faire une moyenne de ces temps de réponse. Elle ne peut être utilisé qu'avec l'option -times");
			Console.WriteLine(sb.ToString());
		}
	}
}
