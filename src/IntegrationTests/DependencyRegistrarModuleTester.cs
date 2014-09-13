using Core;
using Infrastructure;
using NUnit.Framework;
using Should;
using StructureMap;

namespace IntegrationTests
{
    [TestFixture]
    public class DependencyRegistrarModuleTester
    {
        [Test]
        public void Should_resolve_interfaces()
        {
            DependencyRegistrarModule.EnsureDependenciesRegistered();
            var repository = ObjectFactory.GetInstance<IVisitorRepository>();

            repository.ShouldNotBeNull();
            repository.ShouldBeType<VisitorRepository>();
        }
    }
}