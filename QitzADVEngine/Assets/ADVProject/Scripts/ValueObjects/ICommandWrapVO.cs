using System;
using System.Collections.Generic;

namespace Qitz.ADVGame
{
    public interface ICommandWrapVO
    {
        CommandHeadVO CommandHeadVO { get; }
        List<CommandVO> CommandValues { get; }
    }
}
