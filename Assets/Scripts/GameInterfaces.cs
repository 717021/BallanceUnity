using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IGameBasePart
{
    GameBulider GameBulider { get; set; }

    void ExitGameClear();

}