﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Volcafe.Core.Entities;

public partial class WorkflowStatusMapping
{
    public int MappingId { get; set; }

    public int WorkflowId { get; set; }

    public int StatusId { get; set; }

    public int? Sequence { get; set; }

    public virtual ICollection<ContractStatusHistory> ContractStatusHistories { get; set; } = new List<ContractStatusHistory>();

    public virtual ContractStatus Status { get; set; }
}