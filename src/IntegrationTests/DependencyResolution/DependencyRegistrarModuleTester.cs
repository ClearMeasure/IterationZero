using Core;
using Infrastructure.DataAccess;
using Infrastructure.DependencyResolution;
using NUnit.Framework;
using Should;
using StructureMap;

namespace IntegrationTests.DependencyResolution
{
    [TestFixture]
    public class DependencyRegistrarModuleTester
    {
        [Test]
        public void Should_resolve_interfaces()
        {
            var container = DependencyRegistrarModule.EnsureDependenciesRegistered();
            var repository = container.GetInstance<IVisitorRepository>();

            repository.ShouldNotBeNull();
            repository.ShouldBeType<VisitorRepository>();
        }
    }
}