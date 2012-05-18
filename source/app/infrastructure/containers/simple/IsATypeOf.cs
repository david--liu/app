using System;

namespace app.infrastructure.containers.simple
{
    public class IsATypeOf
    {
        Type the_type;

        public IsATypeOf(Type the_type)
        {
            this.the_type = the_type;
        }

        public bool matches(Type type)
        {
            return type == the_type;
        }
    }
}