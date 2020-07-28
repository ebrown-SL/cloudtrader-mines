using System;

namespace CloudTrader.Mines.Service.Exceptions
{
    public class MineNotFoundException : Exception
    {
        public MineNotFoundException(int id) : base($"Mine with id '{id}' not found.") { }
    }
}
