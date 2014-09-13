using Core;
using StructureMap.Configuration.DSL;

namespace Infrastructure
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