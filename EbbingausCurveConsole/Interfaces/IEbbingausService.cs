namespace EbbingausCurveConsole.Interfaces
{
	public interface IEbbingausService
	{
		public List<int[]> GetSteps();

		public DateOnly[] CalculateDays(int[] steps, DateTime date);
	}
}
