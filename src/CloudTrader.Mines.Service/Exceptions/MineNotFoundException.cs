using System;

namespace CloudTrader.Mines.Service.Exceptions
{
    public class MineNotFoundException : Exception
    {
        public MineNotFoundException(Guid id) : base($"Mine with id '{id}' not found.") { }
    }
}
