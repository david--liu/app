using System;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app
{
    [Subject(typeof(DependencyFactory))]
    public class DependencyFactorySpecs
    {
        public abstract class concern : Observes<ICreateASingleDependency,
                                            DependencyFactory>
        {
        }

        public class when_determining_if_it_can_create_a_dependency : concern
        {
            Establish c = () =>
            {
                depends.on<Predicate<Type>>(x => x == typeof(IDbConnection));
            };

            Because b = () =>
                result = sut.can_create(typeof(IDbConnection));

            It should_decide_by_using_its_type_specification = () =>
                result.ShouldEqual(true);

            static bool result;
        }
        public class when_creating_the_item : concern
        {
            Establish c = () =>
            {
                the_item = new SqlConnection();
                real_factory = depends.on<ICreateADependency>();
                real_factory.setup(x => x.create()).Return(the_item);
            };

            Because b = () =>
                result = sut.create();

            It should_return_the_item_created_by_the_item_factory = () =>
                result.ShouldEqual(the_item);

            static object result;
            static IDbConnection the_item;
            static ICreateADependency real_factory;
        }
    }
}