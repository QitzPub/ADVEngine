using System;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface ICommandWrapVO
    {
        CommandType CommandType { get; }
        List<CommandVO> CommandValues { get; }
    }
}
