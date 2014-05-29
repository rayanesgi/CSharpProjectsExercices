/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 27/05/2014
 * Time: 12:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace Nurl
{
	/// <summary>
	/// Description of Core.
	/// </summary>
	public class Core : ICore
	{
		
		private ArgumentLine line;
		
		private LogManager log;
		
		private Stopwatch sw;
				
		public LogManager Log{
			get{return log;}
		}
		
		public Core(ArgumentLine _line)
		{
			line = _line;
			log = new LogManager();
			sw = new Stopwatch();
		}
		
		public void executeCommand(){
			if(line.useGet){
				
				DisplayResult.displayMethod(EnumMethod.GET);
				
				if(line.useSave.Key)
					DisplayResult.displayStateSave(this.executeSave());
				else
					DisplayResult.displayContent(this.executeGet());
			}
			
			if(line.useTest){
				
				DisplayResult.displayMethod(EnumMethod.TEST);
				
				List<double> times = this.executeTest();
				
				if(line.useAvg)
					DisplayResult.displayAvg(this.executeAvg(times),line.useTimes.Value);
			}
		}
		
		public string executeGet(){
			try{
				string result = null;
				
				if(!line.isValidUrl)
					return "<h1>You're entered a fake url</h1>";
						
				using (var webClient = new System.Net.WebClient())
				{
				    result = webClient.DownloadString(line.useUrl.Value);
				}
				
				return result;
			}
			catch(Exception exp){
				log.Message.AppendLine("Une erreur a été rencontrée lors du téléchargement du contenu de l'url");
				return null;
			}
		}
		
		public List<double> executeTest(){
			try{
				if(!line.useTimes.Key)
					return null;

				List<double> ts = new List<double>();
				
				for(int i=0;i<line.useTimes.Value;i++){
					sw.Reset();				
					sw.Start();
					executeGet();
					sw.Stop();
					var time = sw.ElapsedMilliseconds;
					DisplayResult.displayTimes(time,i);
					ts.Add(time);
				}
				
				return ts;
			}
			catch(Exception exp){
				log.Message.AppendLine("Une erreur a été rencontrée lors du téléchargement du contenu de l'url");
				return null;
			}
		}
		
		public bool executeSave(){
			FileStream fs = null;
			StreamWriter sw = null;
			try{
				using(fs = new FileStream(line.useSave.Value,FileMode.OpenOrCreate)){
					using(sw = new StreamWriter(fs)){
						if(line.isValidUrl)
							sw.Write(this.executeGet());
						else{
							sw.Write("<h1>You're entered a fake url</h1>");
							return false;
						}
					}
				}
				
				return true;
			}
			catch(Exception exp){
				log.Message.AppendLine("Une erreur a été rencontrée lors de la sauvegarde du fichier");
				log.HasError = true;
				if(fs!=null)
					fs.Dispose();
				
				if(sw!=null)
					sw.Dispose();
				return false;
			}
		}
		
		public double executeAvg(List<double> times){
			return times.Average(x=>x);
		}
	
		
		}
	}
