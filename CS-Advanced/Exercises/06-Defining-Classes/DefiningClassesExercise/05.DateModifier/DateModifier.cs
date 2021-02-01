using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int DayDifference { get; set; }
        public int CalculateDifference(string first, string second)
        {
            int[] firstDateArr = first.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondDateArr = second.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            DateTime firstDate = new DateTime(firstDateArr[0], firstDateArr[1], firstDateArr[2]);
            DateTime secondDate = new DateTime(secondDateArr[0], secondDateArr[1], secondDateArr[2]);

            DayDifference = Math.Abs((int) (secondDate - firstDate).TotalDays);
            return DayDifference;
        }
    }
}
