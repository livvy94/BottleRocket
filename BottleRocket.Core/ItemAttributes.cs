﻿using System;

namespace BottleRocket.Core
{
    //https://stackoverflow.com/a/6336196/1329396
    [Flags]
    public enum ItemAttributes : byte
    {
        NintenUsable = 0b00000001,
        AnaUsable    = 0b00000010,
        LloydUsable  = 0b00000100,
        TeddyUsable  = 0b00001000,
        Unknown1     = 0b00010000,
        Unknown2     = 0b00100000,
        Edible       = 0b01000000,
        Permanent    = 0b10000000,
    }
}
