using System;

namespace SalaryCard
{
	public class Card
	{
		public Card()
		{
		}

		public DateTime EndTime { get; set; }
		public int HourlySalary { get; set; }
		public DateTime StartTime { get; set; }

		public double CalculateSalary()
		{
			double workingHour = GetWorkingHour();
			var result = workingHour * this.HourlySalary;
			return result;
		}

		private double GetWorkingHour()
		{
			var morningWorkingHour = GetHour(this.StartTime, new DateTime(this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, 12, 0, 0));
			var afternoonWorkingHour = GetHour(new DateTime(this.EndTime.Year, this.EndTime.Month, this.EndTime.Day, 13, 0, 0), this.EndTime);

			return morningWorkingHour + afternoonWorkingHour;
		}

		private double GetHour(DateTime startTime, DateTime endTime)
		{
			var result = new TimeSpan(endTime.Ticks - startTime.Ticks).TotalHours;
			return result;
		}
	}
}