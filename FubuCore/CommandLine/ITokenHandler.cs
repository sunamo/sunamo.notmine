﻿using System.Collections.Generic;

namespace FubuCore.CommandLine
{
    public interface ITokenHandler
    {
        bool Handle(object input, Queue<string> tokens);

        string ToUsageDescription();
        string Description { get; }
        string PropertyName { get; }
    }
}