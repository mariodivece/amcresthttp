using System;
using System.Collections.Generic;
using System.Text;

namespace Amcrest.HttpApi.Models
{
    public class SnapConfig
    {
        public bool HolidayEnable { get; set; }
        public List<NestedArray> TimeSection { get; set; }
    }
}
