﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Volcafe.Core.Entities;

public partial class ContractStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; }

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();

    public virtual ICollection<ContractStatusHistory> ContractStatusHistories { get; set; } = new List<ContractStatusHistory>();

    public virtual ICollection<WorkflowStatusMapping> WorkflowStatusMappings { get; set; } = new List<WorkflowStatusMapping>();
}