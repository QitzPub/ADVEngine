using System;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public class CommandWrapVO : ICommandWrapVO
    {

        public CommandWrapVO(CommandType commandType, List<CommandVO> commandValues)
        {
            this.CommandType = commandType;
            this.CommandValues = commandValues;
        }

        public CommandType CommandType { get; private set; }
        public List<CommandVO> CommandValues { get; private set; }

    }
    public class CommandVO
    {
        public CommandVO(CommandValueType commandValueType, string value)
        {
            CommandValueType = commandValueType;
            Value = value;
        }
        public CommandValueType CommandValueType { get; private set; }
        public string Value { get; private set; }
    }

}
