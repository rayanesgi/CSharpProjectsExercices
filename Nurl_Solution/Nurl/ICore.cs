/*
 * Created by SharpDevelop.
 * User: Rayane
 * Date: 29/05/2014
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Nurl
{
	/// <summary>
	/// Description of ICore.
	/// </summary>
	public interface ICore
	{
		void executeCommand();
		
		bool executeSave();
		
		string executeGet();
		
		List<double> executeTest();
		
		double executeAvg(List<double> times);
	
	}
}
