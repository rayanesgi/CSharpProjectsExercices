/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 26/05/2014
 * Time: 21:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Nurl
{
	/// <summary>
	/// Description of ArgumentLine.
	/// </summary>
	public class ArgumentLine
	{
		public bool useGet{
			get;
			set;
		}

		public bool useTest{
			get;
			set;
		}
		
		public bool useAvg{
			get;
			set;
		}
		
		public bool isValidUrl{
			get;
			set;
		}
		
		
		public KeyValuePair<bool,string> useSave{
			get;
			set;
		}
		
		public KeyValuePair<bool,int> useTimes{
			get;
			set;
		}
		
		public KeyValuePair<bool,string> useUrl{
			get;
			set;
		}
		
		public ArgumentLine()
		{
			useSave = useUrl = new KeyValuePair<bool, string>(false,string.Empty);
			useTimes = new KeyValuePair<bool, int>(false,0);
			useGet = useTest = useAvg = false;
		}
	}
}
