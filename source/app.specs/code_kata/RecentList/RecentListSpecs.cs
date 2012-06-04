using Machine.Specifications;
using app.code_kata.RecentList;
using code_kata.Specs.NaturalSort;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace app.specs.code_kata.RecentList
{
    [Subject(typeof(RecentList<File>))]  
    public class RecentListSpecs
    {
        public abstract class concern : Observes<IRecentList<File>,
                                            RecentList<File>>
        {
        
        }

   
        public class when_the_program_is_run_for_the_first_time : concern
        {

            It the_list_should_be_empty = () =>
                sut.List.ShouldBeEmpty();
        }

        public class when_a_file_is_opened : concern
        {
            Establish c = () =>
            {
                depends.on(5);
            };
            Because b = () =>
                sut.AddToRecent(expected);


            It should_add_to_this_list = () =>
                sut.List.ShouldContain(expected);

            static File expected = new File(1);
        }

        public class when_a_files_is_existed_in_the_recent_list : concern
        {
            Establish c = () =>
            {
                depends.on(5);
            };

            Because b = () =>
            {
                sut.AddToRecent(new File(4));
                sut.AddToRecent(new File(1));
                sut.AddToRecent(new File(2));
                sut.AddToRecent(new File(3));
                sut.AddToRecent(new File(1));
            };



            It should_bump_to_the_top = () =>
                sut.List.First().ShouldEqual(expected);

            It should_not_add_to_the_list = () =>
                sut.List.Count().ShouldEqual(4);

            static File expected= new File(1);
        }

        public class when_the_recent_list_is_full : concern
        {
            Establish c = () =>
            {
                depends.on(5);
            };

            Because b = () =>
            {
                sut.AddToRecent(new File(1));
                sut.AddToRecent(new File(2));
                sut.AddToRecent(new File(3));
                sut.AddToRecent(new File(4));
                sut.AddToRecent(new File(5));
                sut.AddToRecent(new File(6));
            };

            It should_remove_the_bottom_in_the_list = () =>
            {
                sut.List.ShouldNotContain(not_expected);
                sut.List.Count().ShouldEqual(5);
            };

            static File not_expected = new File(1);
        }

    }
}