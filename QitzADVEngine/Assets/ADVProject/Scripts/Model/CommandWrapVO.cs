using System;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public class CommandHeadVO
    {
        public CommandHeadVO(CommandType commandType, string commandValue)
        {
            CommandType = commandType;
            CommandValue = commandValue;
        }
        public CommandType CommandType { get; private set; }
        public string CommandValue { get; private set; }
    }

    public class CommandWrapVO : ICommandWrapVO
    {

        public CommandWrapVO(CommandHeadVO commandHeadVO, List<CommandVO> commandValues)
        {
            this.CommandHeadVO = commandHeadVO;
            this.CommandValues = commandValues;
        }

        public CommandHeadVO CommandHeadVO { get; private set; }
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
