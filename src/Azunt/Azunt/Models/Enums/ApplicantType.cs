﻿using System;
using System.ComponentModel;

namespace Azunt.Models.Enums
{
    [Flags]
    public enum ApplicantType
    {
        [Description("Vendor")]
        Vendor = 1, // 0001

        [Description("Employee")]
        Employee = 2 // 0010
    }
}
