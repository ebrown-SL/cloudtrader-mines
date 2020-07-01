using System;

namespace CloudTrader.Mines.Service.Exceptions
{
   public class MineAlreadyExistsException : Exception
    {
        public MineAlreadyExistsException(int id) : base($"Mine with id \"{id}\" already exists") { }
    }
}