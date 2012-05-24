 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using app.code_kata.MultiMap;
 using code_kata.integer_stack;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace code_kata.Specs
{  
           /* Map<KeyType, List<KeyType>>
            * put(key, value)
            * get returns a list of KeyType objects
            * throw exception on null key
            * answers size (# of keys)
            * answers total # of values (across all keys)
            * answers isEmpty
            * */

    [Subject(typeof(MultiMap<Key>))]  
    public class MultiMapSpecs
    {
        public abstract class concern : Observes<IMultiMap<Key>,
                                            MultiMap<Key>>
        {
        
        }

        public class when_put_a_valid_key : concern
        {
            Establish c = () =>
            {
                map = depends.@on<Dictionary<Key, List<Key>>>();
            };
            Because b = () =>
                sut.Put(key, expected_value);

            It should_store_key_value_in_the_map = () =>
                map[key].ShouldEqual(expected_value);

            static Dictionary<Key, List<Key>> map;
            static Key key = new Key();
            static List<Key> expected_value = new List<Key>();
        }

   
        public class when_put_a_null_key : concern
        {
            Because b = () =>
                expected_exception = Catch.Exception(() => sut.Put(null, new List<Key>()));


            It should_throw_exception = () =>
                expected_exception.ShouldBeAn<InvalidOperationException>();

            static Exception expected_exception;

        }

        public class when_get_values_from_map : concern
        {
            Establish c = () =>
            {
                map = new Dictionary<Key, List<Key>>();
                map.Add(key, expected_value);
                depends.on(map);
            };

            Because b = () =>
                result = sut.Get(key);

            It should_return_correct_value = () =>
                result.ShouldEqual(expected_value);
 
            static Dictionary<Key, List<Key>> map;
            static Key key = new Key();
            static List<Key> expected_value = new List<Key>();
            static List<Key> result;
        }

        public class when_get_size : concern
        {
            Because b = () =>
            {
                sut.Put(new Key(), null);
                sut.Put(new Key(), null);
                sut.Put(new Key(), null);

                result = sut.Size;
            };

            It should_return_key_counts = () =>
                result.ShouldEqual(expected_size);
            static int expected_size = 3;
            static int result;
        }

        public class when_get_isEmpty : concern
        {

            It should_return_true_if_no_element_is_added = () =>
                sut.IsEmpty.ShouldBeTrue();

            It should_return_false_after_adding_one_or_more_elements = () =>
            {
                sut.Put(new Key(), new List<Key>());
                sut.IsEmpty.ShouldBeFalse();
            };
        }

        public class when_get_total_items : concern
        {
            Because b = () =>
            {
                sut.Put(new Key(), new List<Key>{new Key(), new Key()});
                sut.Put(new Key(), new List<Key>{new Key(), new Key(), new Key()});
                result = sut.TotalItems;
            };


            It should_count_all_values_in_the_map = () =>
                result.ShouldEqual(expected_total);


            static int expected_total = 5;
            static int result;
        }


        
    }

   
    public class Key
    {
    }
}
