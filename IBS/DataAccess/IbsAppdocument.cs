﻿using System;
using System.Collections.Generic;

namespace IBS.DataAccess;

public partial class IbsAppdocument
{
    public int Id { get; set; }

    public string? Applicationid { get; set; }

    public int? Documentcategory { get; set; }

    public int? Documentid { get; set; }

    public string? Relativepath { get; set; }

    public string? Fileid { get; set; }

    public string? Extension { get; set; }

    public string? Filedisplayname { get; set; }

    public byte? Isotherdoc { get; set; }

    public string? Otherdocumentname { get; set; }

    public byte? Isdeleted { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Camera { get; set; }

    public DateTime? Phototakendate { get; set; }

    public string? Maker { get; set; }

    public decimal? Accuracy { get; set; }

    public byte Isvideo { get; set; }

    public string? Thumnailpath { get; set; }

    public string? Thumnailfileid { get; set; }

    public string? Thumnailextension { get; set; }

    public string? Couchdbdocid { get; set; }

    public virtual IbsDocument? Document { get; set; }
}
