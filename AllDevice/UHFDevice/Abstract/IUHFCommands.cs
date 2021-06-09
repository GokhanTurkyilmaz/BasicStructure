using System;
using System.Collections.Generic;
using System.Text;

namespace AllDevice.UHFDevice.Abstract
{
    public interface IUHFCommands
    {
        string TagRead();
        string MultiTagRead();
        string TagWrite();
    }
}
