/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 26/05/2014
 * Time: 20:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Nurl.Parser
{
	public class Parser
	{
		private string[] args;
		
		private bool useGet;

		private bool useTest;
		
		private bool useAvg;

		private KeyValuePair<bool,string> useSave;
		
		private KeyValuePair<bool,int> useTimes;
		
		private KeyValuePair<bool,string> useUrl;
		
		public Parser(string[] _args){
			args = _args;
			useSave = useUrl = new KeyValuePair<bool, string>(false,string.Empty);
			useTimes = new KeyValuePair<bool, int>(false,0);
			useGet = useTest = useAvg = false;
		}
		
		public void parseArgs(){
			int i=0;
			bool error = false;
			StringBuilder log = new StringBuilder();
			
			while(i<args.Length){
				if(args[i].Equals("get",StringComparison.OrdinalIgnoreCase))
					useGet = true;
				if(args[i].Equals("-url",StringComparison.OrdinalIgnoreCase))
					useUrl = new KeyValuePair<bool, string>(true,args[++i]);
				if(args[i].Equals("test",StringComparison.OrdinalIgnoreCase))
				   useTest = true;
				if(args[i].Equals("-save",StringComparison.OrdinalIgnoreCase))
					useSave = new KeyValuePair<bool, string>(true,args[++i]);
				if(args[i].Equals("-times",StringComparison.OrdinalIgnoreCase)){
					int nbTimes;
					if(int.TryParse(args[++i],out nbTimes))
						useTimes = new KeyValuePair<bool, int>(true,nbTimes);
					else{
					 	error = true;
					 	log.Append("Erreur rencontrée pour l'option -times, veuillez entrer un chiffre");
					}
				}
				
				i++;				
			}
		}
		
	}
}