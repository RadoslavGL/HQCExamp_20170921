using System.Collections.Generic;

namespace Traveller.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
