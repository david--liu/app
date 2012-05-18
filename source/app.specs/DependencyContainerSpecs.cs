using System;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(DependencyContainer))]
    public class DependencyContainerSpecs
    {
        public abstract class concern : Observes<IFetchDependencies,
                                            DependencyContainer>
        {
        }

        public class when_fetching_a_dependency : concern
        {
            public class and_it_has_the_factory_that_can_create_the_requested_dependency
            {
                Establish c = () =>
                {
                    sql_connection = new SqlConnection();
                    factories = depends.on<IFindAFactoryForADependency>();
                    the_factory = fake.an<ICreateASingleDependency>();

                    factories.setup(x => x.get_factory_that_can_create(typeof(IDbConnection)))
                        .Return(the_factory);

                    the_factory.setup(x => x.create()).Return(sql_connection);
                };

                Because b = () =>
                    result = sut.an<IDbConnection>();

                It should_return_the_item_created_by_the_dependency_factory = () =>
                    result.ShouldEqual(sql_connection);

                static IDbConnection result;
                static IDbConnection sql_connection;
                static IFindAFactoryForADependency factories;
                static ICreateASingleDependency the_factory;
            }

            public class and_the_factory_for_the_item_throws_an_exception_on_creation
            {
                Establish c = () =>
                {
                    factories = depends.on<IFindAFactoryForADependency>();
                    the_original_exception = new Exception();
                    the_wrapped_exception = new Exception();
                    depends.on<ItemCreationExceptionFactory_Behaviour>((type, exception) =>
                    {
                        type.ShouldEqual(typeof(IDbConnection));
                        exception.ShouldEqual(the_original_exception);
                        return the_wrapped_exception;
                    });
                    the_factory = fake.an<ICreateASingleDependency>();

                    factories.setup(x => x.get_factory_that_can_create(typeof(IDbConnection)))
                        .Return(the_factory);
                    the_factory.setup(x => x.create()).Throw(the_original_exception);
                };

                Because b = () =>
                    spec.catch_exception(() => sut.an<IDbConnection>());

                It should_throw_the_exception_created_by_the_item_creation_failure_behaviour = () =>
                    spec.exception_thrown.ShouldEqual(the_wrapped_exception);

                static IFindAFactoryForADependency factories;
                static ICreateASingleDependency the_factory;
                static Exception the_original_exception;
                static Exception the_wrapped_exception;
            }

            public class at_runtime
            {
                Establish c = () =>
                {
                    sql_connection = new SqlConnection();
                    factories = depends.on<IFindAFactoryForADependency>();
                    the_factory = fake.an<ICreateASingleDependency>();

                    factories.setup(x => x.get_factory_that_can_create(typeof(IDbConnection)))
                        .Return(the_factory);

                    the_factory.setup(x => x.create()).Return(sql_connection);
                };

                Because b = () =>
                    result = sut.an(typeof(IDbConnection));

                It should_return_the_item_created_by_the_dependency_factory = () =>
                    result.ShouldEqual(sql_connection);

                static object result;
                static IDbConnection sql_connection;
                static IFindAFactoryForADependency factories;
                static ICreateASingleDependency the_factory;
            }
        }
    }
}