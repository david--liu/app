using System.Collections.Generic;
using Machine.Specifications;
using app.code_kata.NaturalSort;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.Specs.NaturalSort
{
    [Subject(typeof(app.code_kata.NaturalSort.NaturalSort))]
    public class NaturalSortSpecs
    {
        public abstract class concern : Observes<INaturalSort,
                                            app.code_kata.NaturalSort.NaturalSort>
        {
        }

        public class when_sort : concern
        {
            Because b = () =>
                sut.Sort(list);

            It should_sort = () =>
            {
                list[0].ShouldEqual("Alpha 2");
                list[1].ShouldEqual("Alpha 2A");
                list[2].ShouldEqual("Alpha 2A-900");
                list[3].ShouldEqual("Alpha 2A-8000");
                list[4].ShouldEqual("Alpha 100");
                list[5].ShouldEqual("Alpha 200");
            };
                
            static ILetterAndDigitParser letterAndDigitParser;

            static List<string> list = new List<string>
            {
                "Alpha 2",
                "Alpha 2A",
                "Alpha 100",
                "Alpha 200",
                "Alpha 2A-900",
                "Alpha 2A-8000"
            };
        }
    }
}