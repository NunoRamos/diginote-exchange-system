﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public abstract class IClient: MarshalByRefObject
    {
        public abstract void UpdateQuote(float newValue);
    }
}
