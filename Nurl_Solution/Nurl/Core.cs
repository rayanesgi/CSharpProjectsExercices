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
using System.Linq;
using System.Net;

namespace Nurl
{
	/// <summary>
	/// Description of Core.
	/// </summary>
	public class Core
	{
		
		private ArgumentLine parseResult;
		
		public Core(ArgumentLine p)
		{
			parseResult = p;
		}
		
		public string executeCommand(){
			// TO IMPLEMENT
			//if(parseResult.useTimes.Key)
				return string.Empty;
		}
		
		public string executeGet(){
			return null;
		}
		
		public List<TimeSpan> executeTest(){
			return null;
		}
		
		public void executeSave(string filename){
			
		}
		
		public TimeSpan executeAvg(List<TimeSpan> times){
			return new TimeSpan((long)times.Select(ts => ts.Seconds).Average());
		}
		
		private bool isAnUrl()
		{
		    try
		    {
		    	var url = parseResult.useUrl.Value;
		    
		    	if(!parseResult.useUrl.Key || string.IsNullOrEmpty(url))
		    		return false;
		    	
		        //Creating the HttpWebRequest
		        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
		        //Setting the Request method HEAD, you can also use GET too.
		        request.Method = "HEAD";
		        //Getting the Web Response.
		        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
		        //Returns TRUE if the Status code == 200
		        return (response.StatusCode == HttpStatusCode.OK);
		    }
		    catch
		    {
		        return false;
		    }
		}
		
		}
	}
