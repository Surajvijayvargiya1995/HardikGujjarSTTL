﻿using System;
using System.Collections.Generic;

namespace IBS.DataAccess;

public partial class T08IeControllOfficer
{
    public int CoCd { get; set; }

    public string? CoName { get; set; }

    public int? CoDesig { get; set; }

    public string? CoRegion { get; set; }

    public string? CoPhoneNo { get; set; }

    public string? CoEmail { get; set; }

    public string? CoStatus { get; set; }

    public DateTime? CoStatusDt { get; set; }

    public string? CoType { get; set; }

    public byte? Isdeleted { get; set; }

    public int? Createdby { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? Createddate { get; set; }

    public DateTime? Updateddate { get; set; }

    public virtual T07RitesDesig? CoDesigNavigation { get; set; }

    public virtual T01Region? CoRegionNavigation { get; set; }

    public virtual ICollection<T09Ie> T09Ies { get; set; } = new List<T09Ie>();
}
