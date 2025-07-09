using EbbingausCurveConsole.Interfaces;

namespace EbbingausCurveConsole.Infrastructure
{
    public class EbbingausService : IEbbingausService
    {
        public DateOnly[] CalculateDays(int[] steps, DateTime date)
        {
            List<DateOnly> ebbingausCurve = new List<DateOnly>();

            var currentDay = DateOnly.FromDateTime(date);
            ebbingausCurve.Add(currentDay);

            foreach (int step in steps)
            {
                var a = ebbingausCurve.Last().AddDays(-step);

                ebbingausCurve.Add(a);
            }


            return ebbingausCurve.ToArray();
        }

        public List<int[]> GetSteps()
        {
            return new List<int[]>
            {
                new int[] { 1, 3, 5, 7, 14, 30, 60, 90, 120},
                new int[] { 1, 5, 7, 14, 30, 30, 60, 90 },
                new int[] { 1, 7, 14, 30, 60, 90 },
                new int[] { 1, 7, 14, 30 }
            };
        }
    }
}
