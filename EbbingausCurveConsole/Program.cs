// See https://aka.ms/new-console-template for more information
using EbbingausCurveConsole.Infrastructure;
using EbbingausCurveConsole.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection()
	.AddScoped<IEbbingausService, EbbingausService>()
	.BuildServiceProvider();

var ebbingausService = services.GetRequiredService<IEbbingausService>();

var steps = ebbingausService.GetSteps();

do
{
	for (var i = 0; i < steps.Count; i++)
	{
		var message = $"{i + 1} = {String.Join(" ,", steps[i])}";

		Console.WriteLine(message);
	}

	Console.WriteLine("choose the step");
	var result = Console.ReadLine();

	if (result == null)
	{
		Console.WriteLine("input is null");
		break;
	}

	if (int.TryParse(result, out int number))
	{
		if (number <= 0 || number > steps.Count)
		{
			Console.Clear();
			continue;
		}

		var chosenStep = steps[number - 1];

		Console.WriteLine("today - t, yesterday - y, the day before yesterday - by, another - a?");
		var nowOrNot = Console.ReadLine();

		if (nowOrNot == "t")
		{
			var dates = ebbingausService.CalculateDays(chosenStep, DateTime.Now);

			foreach (var date in dates)
			{
				Console.WriteLine(date.ToString());
			}
		}
		else if (nowOrNot == "y")
		{
			var dates = ebbingausService.CalculateDays(chosenStep, DateTime.Now.AddDays(-1));

			foreach (var date in dates)
			{
				Console.WriteLine(date.ToString());
			}
		}
		else if (nowOrNot == "by")
		{
			var dates = ebbingausService.CalculateDays(chosenStep, DateTime.Now.AddDays(-2));

			foreach (var date in dates)
			{
				Console.WriteLine(date.ToString());
			}
		}
		else if (nowOrNot == "a")
		{
			Console.WriteLine("put date");
			var dateString = Console.ReadLine();

			if (DateTime.TryParse(dateString, out DateTime dateTime))
			{
				var dates = ebbingausService.CalculateDays(chosenStep, dateTime);

				Console.WriteLine("dates:");
				foreach (var date in dates)
				{
					Console.WriteLine(date.ToString());
				}

			}
			else
			{
				Console.Clear();
				continue;
			}
		}
		else
		{
			Console.Clear();
			continue;
		}
	}
	else
	{
		Console.Clear();
		continue;
	}

	Console.ReadLine();
	Console.Clear();
}
while (true);
