using System;
using Books;

namespace ParameterForSearching
{
    public interface IFinder
    {
        Book FindBookByTeg();
    }
}
