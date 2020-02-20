using HashCode.Entities;
using System.Collections.Generic;

namespace HashCode.Bussiness
{
    public class Algorithm
    {
        public static Output Apply(Input container)
        {
            Output output = new Output();
            output.Libraries = new LinkedList<Library>();

            return output;
        }
    }
}