using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCard;

namespace SalaryCardTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Test_Without_Overtime_HourlySalary_100_Should_Be_800()
		{
			//#12:00~13:00 不算薪資

			//			Scenario: 沒有加班，正常上班8小時，時薪100乘以8，薪資應為800
			//				Given 正常上班一小時薪資為 100
			//    And 上班時間為 "2014/8/30 08:00:00"
			//    And 下班時間為 "2014/8/30 17:00:00"
			//    When 呼叫CalculateSalary方法
			//    Then 薪資計算結果應為 800

			var target = new Card();
			target.HourlySalary = 100;
			target.StartTime = new DateTime(2014, 8, 30, 8, 0, 0);
			target.EndTime = new DateTime(2014, 8, 30, 17, 0, 0);

			double actual = target.CalculateSalary();

			var expected = 800;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_WorkingHour_10_FirstOvertimeRatio_1dot66_Should_Be_1132()
		{
			//			Scenario: 加班2小時：
			//上班8小時，時薪100乘以8，加班2小時，加班費100乘以1.66乘以2，薪資應為1132
			//	Given 正常上班一小時薪資為 100
			//    And 加班薪資頭2小時，時薪比例為 1.66
			//    And 上班時間為 "2014/8/30 08:00:00"
			//    And 下班時間為 "2014/8/30 19:00:00"
			//    When 呼叫CalculateSalary方法
			//    Then 薪資計算結果應為 1132

			var target = new Card();
			target.FirstOvertimeRatio = 1.66;
			target.HourlySalary = 100;
			target.StartTime = new DateTime(2014, 8, 30, 8, 0, 0);
			target.EndTime = new DateTime(2014, 8, 30, 19, 0, 0);

			var actual = target.CalculateSalary();

			var expected = 1132;

			Assert.AreEqual(expected, actual);

		}
	}
}
