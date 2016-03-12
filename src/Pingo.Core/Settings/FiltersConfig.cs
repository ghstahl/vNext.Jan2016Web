﻿using System.Collections.Generic;

namespace Pingo.Core.Settings
{
    public class FiltersConfig
    {
        public const string WellKnown_FilterSectionName = "Filters";
        public SimpleManyConfig SimpleMany { get; set; }
        public GlobalPathConfig GlobalPath { get; set; }
        public MiddleWareConfig MiddleWare { get; set; }
    }

    public class MiddleWareConfig
    {
        public ProtectLocalOnlyConfig ProtectLocalOnly { get; set; }
    }

    public class ProtectLocalOnlyConfig
    {
        public List<string> Paths { get; set; }
    }
}
