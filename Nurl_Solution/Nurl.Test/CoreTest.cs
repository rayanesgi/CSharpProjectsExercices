/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 27/05/2014
 * Time: 11:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Nurl.Test
{
	[TestFixture]
	public class CoreTest
	{
		[Test]
		public void Should_Show_Fake_Url()
		{
			string[] args = new string[]{"get","-url","http://test"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			string result = c.executeCommand();
			
			Assert.AreEqual(result,"<h1>You're entered a fake url</h1>");
		}
		
		[Test]
		public void Should_Show_Times(){
			string[] args = new string[]{"get","-url","http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric","-times","3"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			
			List<TimeSpan> ts = c.executeTest();
			if (ts == null)
				return;
			StringBuilder sb = new StringBuilder();
			
			// On recrée le string à la main
			ts.Select((x,i)=>new{Time = x, Index = i}).ToList()
				.ForEach(x =>sb.AppendFormat("{0}) {1}sec ",x.Index,x.Time.Seconds));
			
			Assert.AreEqual(sb.ToString(),c.executeCommand());
			
		}
		
		[Test]
		public void Should_Create_File_And_Fill(){
			string[] args = new string[]{"get","-url","http://horloge.parlante.online.fr/","-save","C:/bonjour.txt"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			string result = c.executeCommand();
			
			Assert.IsTrue(File.Exists(args[4]));
			
			string content;
			
			using(FileStream fs = new FileStream(args[4],FileMode.Open)){
				using(StreamReader sr = new StreamReader(fs)){
					content = sr.ReadToEnd();
				}
			}
			
			Assert.IsNotNullOrEmpty(content);
		}
		
		public void Should_Display_Error_On_Fake_Url(){
			string[] args = new string[]{"get","-url","http://horloge.parlante.onlineERREUR.fr/"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			Assert.AreEqual("L'url entrée n'existe pas.",c.executeCommand());
		}
	}
}
