﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    interface IPattern
    {
        IMatch Match(string text);
    }
}
