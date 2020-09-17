using System;
using System.Collections.Generic;
using Xunit;
using CovidStatsAPI.Controllers;

namespace CovidStatsAPI.Test
{
    public class UnitTest1
    {
		CovidInfoController controller = new CovidInfoController();

		[Fact]
		public void DataHeaderExists()
		{
			List<string[]> returnValue = new List<string[]>(controller.Get("ROU"));
			if (returnValue.Count == 0)
				Assert.Equal(1, 0);	// If no values, test fails
			
			string[] header = returnValue[0];
			Assert.Equal("dateRep", header[0]);
		}

		[Fact]
		public void TodayDataExists()
		{
			List<string[]> returnValue = new List<string[]>(controller.Get("ROU"));
			if (returnValue.Count == 0)
				Assert.Equal(1, 0);		// If no values, test fails
			
			string[] todayData = returnValue[1];
			
			string sep = "-";
			string expectedDate = DateTime.Now.Year.ToString() + sep + DateTime.Now.Month.ToString() + sep + DateTime.Now.Day.ToString();
			string actualDate = todayData[3] + sep + todayData[2] + sep + todayData[1];
			
			Assert.Equal(expectedDate, actualDate);
		}
    }
}
