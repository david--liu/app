 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using app.infrastructure.containers;
 using app.infrastructure.containers.simple;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

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
        }
    }
}
