/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 26/05/2014
 * Time: 16:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Nurl
{
	class Program
	{
		public static void Main(string[] args)
		{
			Parser p = new Parser(args);
			p.parseArgs();
			
			if(p.HadErrors)
				Console.WriteLine(p.Log);
			
			Console.WriteLine("Finish");
			Console.ReadKey();
		}
	}
}