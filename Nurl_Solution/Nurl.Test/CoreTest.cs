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
		public void Should_Create_File_And_Fill(){
			string[] args = new string[] {"get","-url","http://horloge.parlante.online.fr/","-save","C:/bonjour.txt"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			c.executeCommand();
			
			Assert.AreEqual(File.Exists(args[4]),true);
			
			string content;
			
			using(FileStream fs = new FileStream(args[4],FileMode.Open)){
				using(StreamReader sr = new StreamReader(fs)){
					content = sr.ReadToEnd();
				}
			}
			
			Assert.IsNotNullOrEmpty(content);
		}
		
		[Test]
		public void Should_Display_Error_On_Fake_Url(){
			string[] args = new string[]{"get","-url","http://horloge.parlante.onlineERREUR.fr/"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			Assert.AreEqual("<h1>You're entered a fake url</h1>",c.executeGet());
		}
		
		[Test]
		public void Should_Display_Good_Text(){
			string[] args = new string[]{"get","-url","http://webbdoger93.free.fr/testNurl/hello.html"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			Assert.AreEqual("<h1>Hello test<h1>",c.executeGet());
			
		}
		
		[Test]
		public void Should_Fill_File_With_Good_Text(){
			string[] args = new string[]{"get","-url","http://webbdoger93.free.fr/testNurl/hello.html","-save","C:/Bonjour.txt"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			Assert.IsTrue(c.executeSave());
			
			Assert.AreEqual(File.Exists(args[4]),true);
			string content = String.Empty;
			using(FileStream fs = new FileStream(args[4],FileMode.Open)){
				using(StreamReader sr = new StreamReader(fs)){
					content=sr.ReadToEnd();
				}
			}
			
			Assert.AreEqual("<h1>Hello test<h1>",content);
		}
		
		[Test]
		public void Should_Have_Good_Number_Of_Results(){
			string[] args = new string[]{"test","-url","http://horloge.parlante.online.fr/","-times","5"};
			Parser p = new Parser(args);
			p.parseArgs();
			
			Core c = new Core(p.Line);
			Assert.AreEqual(Int32.Parse(args[4]),c.executeTest().Count);
		}
		
	}
}
