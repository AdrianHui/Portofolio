﻿using System;

namespace MindMap
{
    public interface IMenu
    {
        public ICurrentView CurrentView { get; set; }

        public IControl Control { get; set; }
    }
}
