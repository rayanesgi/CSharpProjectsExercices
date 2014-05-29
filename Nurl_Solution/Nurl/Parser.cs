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
using System.Net;
using System.Text;

namespace Nurl
{
	/// <summary>
	/// Description of Parser.
	/// </summary>
	public class Parser
	{
		private string[] args;		
		
		private ArgumentLine line;
		
		private LogManager log;
		
		public Parser(string[] _args){
			args = _args;
			line = new ArgumentLine();
			log = new LogManager();
		}
		
		public ArgumentLine Line{
			get{return line;}
		}
		
		public LogManager Log{
			get{return log;}
		}
		
		public void parseArgs(){			
			if(args.Length == 1 && (args[0].Equals("/?") || args[0].Equals("-?"))){
				DisplayResult.displayHelp();
				return;
			}
			
			Console.WriteLine("\t\t\tLancement du programme NURL\n\n");
			
			int i=0;
			
			while(i<args.Length){
				if(args[i].Equals("get",StringComparison.OrdinalIgnoreCase))
					line.useGet = true;
				
				if(args[i].Equals("-url",StringComparison.OrdinalIgnoreCase)){
					if(i+1 >= args.Length){
						log.HasError = true;
						log.Message.AppendLine("Veuillez entrer une valeur pour l'option -url");
						return;
					}
					line.useUrl = new KeyValuePair<bool, string>(true,args[++i]);
				}
				
				if(args[i].Equals("test",StringComparison.OrdinalIgnoreCase))
				   line.useTest = true;
				
				if(args[i].Equals("-save",StringComparison.OrdinalIgnoreCase)){
					if(i+1 >= args.Length){
						log.HasError = true;
						log.Message.AppendLine("Veuillez entrer une valeur pour l'option -save");
						return;
					}
					line.useSave = new KeyValuePair<bool, string>(true,args[++i]);
				}
				
				if(args[i].Equals("-times",StringComparison.OrdinalIgnoreCase)){
					if(i+1 >= args.Length){
						log.HasError = true;
						log.Message.AppendLine("Veuillez entrer une valeur pour l'option -times");
						return;
					}
					int nbTimes;
					if(int.TryParse(args[++i],out nbTimes))
						line.useTimes = new KeyValuePair<bool, int>(true,nbTimes);
					else{
					 	log.HasError = true;
						log.Message.AppendLine("Erreur rencontrée pour l'option -times, veuillez entrer une valeur numérique.");
					}
				}
				
				if(args[i].Equals("-avg",StringComparison.OrdinalIgnoreCase))
					line.useAvg=true;
				
				i++;				
			}
			
			checkArgs();
					
		}
		
		/// <summary>
		/// Méthode permettant de vérifier la logique des arguments
		/// </summary>
		private void checkArgs(){
			if((!line.useGet && !line.useTest) || (line.useGet && line.useTest)){
				log.HasError = true;
				log.Message.AppendLine("Veuillez choisir une méthode get ou test");
				return;
			}
			
			if(!line.useUrl.Key){
				log.HasError = true;
				return;
			}
			else
				line.isValidUrl = isAnUrl();
				
			
			if(line.useGet){
				if(line.useTimes.Key || line.useAvg){
					log.HasError = true;
					log.Message.AppendLine("Lorsque vous utilisez get, veuillez n'utilisez que les options -url et -save");
				}
			}
			else if(line.useTest){
				if(line.useSave.Key){
					log.HasError = true;
					log.Message.AppendLine("L'option -save n'est pas disponible lorsque vous utilisez test");
				}
				if(!line.useTimes.Key){
					log.HasError = true;
					log.Message.AppendLine("L'option test ne peut fonctionner qu'avec l'option -times");
				}
			}
			
		}
		
		private bool isAnUrl()
		{
		    try
		    {
		    	var url = line.useUrl;
		    
		    	if(!url.Key || string.IsNullOrEmpty(url.Value))
		    		return false;
		    	
		    	Console.WriteLine("Vérification de l'url entré ....\n");
		    	
		        //Creating the HttpWebRequest
		        HttpWebRequest request = WebRequest.Create(url.Value) as HttpWebRequest;
		        //Setting the Request method HEAD, you can also use GET too.
		        request.Method = "HEAD";
		        
		        //Getting the Web Response.
		        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
		        //Returns TRUE if the Status code == 200
		        
		        response.Close();
		        return (response.StatusCode == HttpStatusCode.OK);
		    }
		    catch
		    {
		    	log.Message.AppendLine("L'url entrée n'existe pas.");
		    	// On ne met pas le processus en erreur.
		    	return false;
		    }
		}
		
	}
}
