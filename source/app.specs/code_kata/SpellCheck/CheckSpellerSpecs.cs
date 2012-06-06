 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using app.code_kata.CheckSpeller;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace code_kata.Specs.SpellCheck
{  
    [Subject(typeof(CheckSpeller))]  
    public class CheckSpellerSpecs
    {
        public abstract class concern : Observes<ISpellCheck,
                                            CheckSpeller>
        {
        
        }

   
        public class when_spell_a_check_with_cents_only : concern
        {
            Because b = () =>
                result = sut.Spell(0.55m);


            It should_translate_cents_to_percentage = () =>
                result.ShouldEqual("55/100 Dollars");

            static string result;        
                
        }

        public class when_spell_a_check_with_cents_and_dollars : concern
        {
            Because b = () =>
                result = sut.Spell(5.55m);


            It should_translate_cents_to_percentage = () =>
                result.ShouldEqual("Five and 55/100 Dollars");

            static string result;

        }

        public class when_spell_a_check_without_cents : concern
        {

            It should_not_show_the_percentage_part_1 = () =>
                sut.Spell(1).ShouldEqual("One Dollars");
            It should_not_show_the_percentage_part_2 = () =>
                sut.Spell(2).ShouldEqual("Two Dollars");
            It should_not_show_the_percentage_part_3 = () =>
                sut.Spell(3).ShouldEqual("Three Dollars");
            It should_not_show_the_percentage_part_4 = () =>
                sut.Spell(4).ShouldEqual("Four Dollars");
            It should_not_show_the_percentage_part_5 = () =>
                sut.Spell(5).ShouldEqual("Five Dollars");
            It should_not_show_the_percentage_part_6 = () =>
                sut.Spell(6).ShouldEqual("Six Dollars");
            It should_not_show_the_percentage_part_7 = () =>
                sut.Spell(7).ShouldEqual("Seven Dollars");
            It should_not_show_the_percentage_part_8 = () =>
                sut.Spell(8).ShouldEqual("Eight Dollars");
            It should_not_show_the_percentage_part_9 = () =>
                sut.Spell(9).ShouldEqual("Nine Dollars");
            It should_not_show_the_percentage_part_10 = () =>
                sut.Spell(10).ShouldEqual("Ten Dollars");
            It should_not_show_the_percentage_part_11 = () =>
                sut.Spell(11).ShouldEqual("Eleven Dollars");
            It should_not_show_the_percentage_part_12 = () =>
                sut.Spell(12).ShouldEqual("Twelve Dollars");
            It should_not_show_the_percentage_part_13 = () =>
                sut.Spell(13).ShouldEqual("Thirteen Dollars");
            It should_not_show_the_percentage_part_14 = () =>
                sut.Spell(14).ShouldEqual("Fourteen Dollars");
            It should_not_show_the_percentage_part_15 = () =>
                sut.Spell(15).ShouldEqual("Fifteen Dollars");
            It should_not_show_the_percentage_part_16 = () =>
                sut.Spell(16).ShouldEqual("Sixteen Dollars");
            It should_not_show_the_percentage_part_17 = () =>
                sut.Spell(17).ShouldEqual("Seventeen Dollars");
            It should_not_show_the_percentage_part_18 = () =>
                sut.Spell(18).ShouldEqual("Eighteen Dollars");
            It should_not_show_the_percentage_part_19 = () =>
                sut.Spell(19).ShouldEqual("Nineteen Dollars");
            It should_not_show_the_percentage_part_20 = () =>
                sut.Spell(20).ShouldEqual("Twenty Dollars");
        }

        public class when_spell_a_check_more_than_twenty_dollars : concern
        {

            It should_concat_21 = () =>
                sut.Spell(21).ShouldEqual("Twenty-one Dollars");
            It should_concat_99 = () =>
                sut.Spell(99).ShouldEqual("Ninety-nine Dollars");
            It should_concat_99_99 = () =>
                sut.Spell(99.99m).ShouldEqual("Ninety-nine and 99/100 Dollars");
        }
        public class when_spell_a_check_more_than_one_hundred_dollars : concern
        {

            It should_spell_100 = () =>
                sut.Spell(100).ShouldEqual("One hundred Dollars");
            It should_concat_121 = () =>
                sut.Spell(121).ShouldEqual("One hundred twenty-one Dollars");
            It should_concat_99 = () =>
                sut.Spell(999).ShouldEqual("Nine hundred ninety-nine Dollars");
            It should_concat_99_99 = () =>
                sut.Spell(999.99m).ShouldEqual("Nine hundred ninety-nine and 99/100 Dollars");
        }

        public class when_spell_a_check_more_than_one_thousand_dollars : concern
        {
            It should_return_whole_1000 = () =>
                sut.Spell(1000).ShouldEqual("One thousand Dollars");

            It should_concat_1121 = () =>
                sut.Spell(1121).ShouldEqual("One thousand one hundred twenty-one Dollars");
            It should_concat_9999 = () =>
                sut.Spell(9999).ShouldEqual("Nine thousand nine hundred ninety-nine Dollars");
            It should_concat_99999_99 = () =>
                sut.Spell(99999.99m).ShouldEqual("Ninety-nine thousand nine hundred ninety-nine and 99/100 Dollars");
        }
        public class when_spell_a_check_more_than_one_millon_dollars : concern
        {

            Because b = () =>
                expression = Catch.Exception(() => sut.Spell(1000*1000));


            It should_throw_not_supported_exception = () =>
                expression.ShouldBeAn<NotSupportedException>();
            static Exception expression;
                
        }


    }

}
