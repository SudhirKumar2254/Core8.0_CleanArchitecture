﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Volcafe.Core.Entities;

public partial class ContractDocument
{
    public int ContractDocId { get; set; }

    public int? ContractId { get; set; }

    public string DocName { get; set; }

    public string DocPath { get; set; }

    public int? DocumentId { get; set; }

    public virtual ContractDetail Contract { get; set; }

    public virtual AgentCategoryDocument Document { get; set; }
}