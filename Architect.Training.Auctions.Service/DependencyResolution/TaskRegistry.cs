using Architect.Training.Auctions.Service.DependencyResolution;
using Architect.Training.Auctions.Service.DependencyResolution.Tasks;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Architect.Training.Auctions.Service.DependencyResolution
{
	public class TaskRegistry : Registry
	{
		public TaskRegistry()
		{
			Scan(scan =>
			{
				scan.AssembliesFromApplicationBaseDirectory(
					a => a.FullName.StartsWith("Architect.Training.Auctions.Portal"));
				scan.AddAllTypesOf<IRunAtInit>();
				scan.AddAllTypesOf<IRunAtStartup>();
				scan.AddAllTypesOf<IRunOnEachRequest>();
				scan.AddAllTypesOf<IRunOnError>();
				scan.AddAllTypesOf<IRunAfterEachRequest>();
			});
		}
	}
}