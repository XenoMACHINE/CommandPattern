﻿using System;
namespace CommandPattern
{
    abstract class Command

    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}
