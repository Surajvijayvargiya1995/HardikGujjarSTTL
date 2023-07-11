﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class T37ClientLogginLog
{
    public string? Mobile { get; set; }

    public byte? Otp { get; set; }

    public DateTime? OtpGenTime { get; set; }

    public DateTime? OtpExpTime { get; set; }

    public DateTime? LogginTime { get; set; }

    public string? Status { get; set; }
}
