using System;

namespace EFSimpleExample
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new MyDbContext())
			{
				var panelID = new ControlPanelNodeId(0);

				Console.WriteLine("Inserting new ZoneState");
				var zoneState1 = new ZoneState()
				{
					ZoneKey = Guid.NewGuid().ToString(),
					NodeId = panelID
				};
				context.Add(zoneState1);

				context.SaveChanges();

				Console.WriteLine("Inserting another new ZoneState");
				var zoneState2 = new ZoneState()
				{
					ZoneKey = Guid.NewGuid().ToString(),
					NodeId = panelID
				};
				context.Add(zoneState2);

				context.SaveChanges();
			}
		}
	}
}
