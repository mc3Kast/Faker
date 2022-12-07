﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Intefaces
{
    public interface IGenerator
    {
        object Generate(Type type, GeneratorContext context);
        bool CanGenerate(Type type);
    }
}
