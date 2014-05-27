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
			string[] args = new string[]{"get","-url","http://durant.com","-save","C:/Bonjour.txt"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsFalse(p.HadErrors,"Erreur rencontrée durant le traitement des arguments");
		}
		
		[Test]
		public void GetWithoutUrlOption(){
			string[] args = new string[]{"get","-save","C:/Bonjour.txt"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.HadErrors);
		}
		
		[Test]
		public void GetOptionUrlWithoutValue(){
			string[] args = new string[]{"get","-url"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.HadErrors);
		}
		
		[Test]
		public void TestOptionTimeWithoutValue(){
			string[] args = new string[]{"test","-url","http://blah.com","-times"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.HadErrors);
		}
		
		[Test]
		public void TestOptionTimeWithValue(){
			string[] args = new string[]{"test","-url","http://blah.com","-times","5"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsFalse(p.HadErrors);		
		}
		
		[Test]
		public void TestOptionTimeWithValueNotNumeric(){
			string[] args = new string[]{"test","-url","http://blah.com","-times","bonjour"};
			Parser p =  new Parser(args);
			p.parseArgs();
			
			Assert.IsTrue(p.HadErrors);	
		}
	}
}
