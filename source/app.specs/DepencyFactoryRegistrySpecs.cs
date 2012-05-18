using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(DepencyFactoryRegistry))]
    public class DepencyFactoryRegistrySpecs
    {
        public abstract class concern : Observes<IFindAFactoryForADependency,
                                            DepencyFactoryRegistry>
        {
        }

        public class when_finding_a_factory_for_a_dependency : concern
        {
            public class and_it_has_the_dependency
            {
                Establish c = () =>
                {
                    the_factory = fake.an<ICreateASingleDependency>();
                    all_factories = new List<ICreateASingleDependency>();
                    Enumerable.Range(1, 100).each(x => all_factories.Add(fake.an<ICreateASingleDependency>()));
                    all_factories.Add(the_factory);

                    the_factory.setup(x => x.can_create(typeof(IDbConnection))).Return(true);

                    depends.on<IEnumerable<ICreateASingleDependency>>(all_factories);
                };

                Because b = () =>
                    result = sut.get_factory_that_can_create(typeof(IDbConnection));

                It should_return_the_factory_that_can_create_the_item = () =>
                    result.ShouldEqual(the_factory);

                static ICreateASingleDependency the_factory;
                static ICreateASingleDependency result;
                static List<ICreateASingleDependency> all_factories;
            }
            public class and_it_does_not_have_the_dependency
            {
                Establish c = () =>
                {

                    the_exception = new Exception();
                    all_factories = new List<ICreateASingleDependency>();
                    Enumerable.Range(1, 100).each(x => all_factories.Add(fake.an<ICreateASingleDependency>()));
                    depends.on<IEnumerable<ICreateASingleDependency>>(all_factories);
                    depends.on<FactoryNotRegisteredExceptionFactory_Behaviour>(x =>
                    {
                        x.ShouldEqual(typeof(IDbConnection));
                        return the_exception;
                    });
                };

                Because b = () =>
                    spec.catch_exception(() => sut.get_factory_that_can_create(typeof(IDbConnection)));

                It should_throw_the_exception_created_by_the_factory_not_registered_exception_behaviour = () =>
                    spec.exception_thrown.ShouldEqual(the_exception);

                static ICreateASingleDependency the_factory;
                static ICreateASingleDependency result;
                static List<ICreateASingleDependency> all_factories;
                static Exception the_exception;
            }
        }
    }
}