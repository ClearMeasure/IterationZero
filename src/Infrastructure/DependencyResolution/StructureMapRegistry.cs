using Core;
using Infrastructure.DataAccess;
using StructureMap.Configuration.DSL;

namespace Infrastructure.DependencyResolution
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<IVisitorRepository>();
                scanner.AssemblyContainingType<VisitorRepository>();

                scanner.WithDefaultConventions(); 
            });

        }
    }
}