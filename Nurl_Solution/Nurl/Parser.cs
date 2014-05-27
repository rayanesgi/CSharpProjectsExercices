/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 26/05/2014
 * Time: 21:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Nurl
{
	/// <summary>
	/// Description of Parser.
	/// </summary>
	public class Parser
	{
		private string[] args;
		
		private bool hasError;
		
		private ArgumentLine line;
		
		private StringBuilder log = new StringBuilder();
		
		public Parser(string[] _args){
			args = _args;
			line = new ArgumentLine();
		}
		
		public bool HadErrors{
			get{return this.hasError;}
		}
		
		public string Log{
			get{return log.ToString();}
		}
		
		public void parseArgs(){
			int i=0;
			
			while(i<args.Length){
				if(args[i].Equals("get",StringComparison.OrdinalIgnoreCase))
					line.useGet = true;
				
				if(args[i].Equals("-url",StringComparison.OrdinalIgnoreCase)){
					if(i+1 >= args.Length){
						hasError = true;
						log.AppendLine("Veuillez entrer une valeur pour l'option -url");
						return;
					}
					line.useUrl = new KeyValuePair<bool, string>(true,args[++i]);
				}
				
				if(args[i].Equals("test",StringComparison.OrdinalIgnoreCase))
				   line.useTest = true;
				
				if(args[i].Equals("-save",StringComparison.OrdinalIgnoreCase)){
					if(i+1 >= args.Length){
						hasError = true;
						log.AppendLine("Veuillez entrer une valeur pour l'option -save");
						return;
					}
					line.useSave = new KeyValuePair<bool, string>(true,args[++i]);
				}
				
				if(args[i].Equals("-times",StringComparison.OrdinalIgnoreCase)){
					if(i+1 >= args.Length){
						hasError = true;
						log.AppendLine("Veuillez entrer une valeur pour l'option -times");
						return;
					}
					int nbTimes;
					if(int.TryParse(args[++i],out nbTimes))
						line.useTimes = new KeyValuePair<bool, int>(true,nbTimes);
					else{
					 	hasError = true;
					 	log.AppendLine("Erreur rencontrée pour l'option -times, veuillez entrer une valeur numérique.");
					}
				}
				
				i++;				
			}
			
			checkArgs();
					
		}
		
		/// <summary>
		/// Méthode permettant de vérifier la logique des arguments
		/// </summary>
		private void checkArgs(){
			if((!line.useGet && !line.useTest) || (line.useGet && line.useTest)){
				hasError = true;
				log.AppendLine("Veuillez choisir une méthode get ou test");
				return;
			}
			
			if(!line.useUrl.Key){
				hasError = true;
				log.AppendLine("Veuillez entrer une url à extraire.");
				return;
			}
				
			
			if(line.useGet){
				if(line.useTimes.Key || line.useAvg){
					hasError = true;
					log.AppendLine("Lorsque vous utilisez get, veuillez n'utilisez que les options -url et -save");
				}
			}
			else if(line.useTest){
				if(line.useSave.Key){
					hasError = true;
					log.AppendLine("L'option -save n'est pas disponible lorsque vous utilisez test");
				}
			}
			
		}
		
	}
}
