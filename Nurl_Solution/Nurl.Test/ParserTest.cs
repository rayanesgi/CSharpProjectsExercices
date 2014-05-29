/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 26/05/2014
 * Time: 22:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace Nurl.Test
{
	[TestFixture]
	public class ParserTest
	{		
	
		[Test]
		public void GetWithSaveOption()
		{
			string[] args = new string[]{"get","-url","http://horloge.parlante.online.fr/","-save","C:/Bonjour.txt"};
			Parser p =  new Parser(args);
			p.parseArgs();

			Assert.IsFalse(p.Log.HasError,"Erreur rencontrée durant le traitement des arguments");
		}
		
		[Test]
		public void GetWithFakeUrl(){
			string[] args = new string[]{"get","-url","http://horloge.parlaERREURURLnte.online.fr/","-save","C:/Bonjour.txt"};
			Parser p =  new Parser(args);
			p.parseArgs();

			Assert.AreEqual(p.Log.Message.ToString(),"L'url entrée n'existe pas.\r\n");
		}
		
		[Test]
		public void GetWithoutUrlOption(){
			string[] args = new string[]{"get","-save","C:/Bonjour.txt"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.Log.HasError);
		}
		
		[Test]
		public void GetOptionUrlWithoutValue(){
			string[] args = new string[]{"get","-url"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.Log.HasError);
		}
		
		[Test]
		public void TestOptionTimeWithoutValue(){
			string[] args = new string[]{"test","-url","http://horloge.parlante.online.fr/","-times"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.Log.HasError);
		}
		
		[Test]
		public void TestOptionTimeWithValue(){
			string[] args = new string[]{"test","-url","http://horloge.parlante.online.fr/","-times","5"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsFalse(p.Log.HasError);		
		}
		
		[Test]
		public void TestOptionTimeWithValueNotNumeric(){
			string[] args = new string[]{"test","-url","http://horloge.parlante.online.fr/","-times","bonjour"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.Log.HasError);	
		}
	}
}
