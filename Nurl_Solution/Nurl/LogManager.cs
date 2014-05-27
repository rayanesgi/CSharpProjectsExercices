/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 27/05/2014
 * Time: 14:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace Nurl
{
	/// <summary>
	/// Description of LogManager.
	/// </summary>
	public class LogManager
	{
		private bool hasError;	
		private StringBuilder log;
		
		public LogManager (){
			log = new StringBuilder();
		}
		
		public bool HasError{
			get;
			set;
		}
		
		public StringBuilder Message{
			get{return log;}
		}
	}
}
