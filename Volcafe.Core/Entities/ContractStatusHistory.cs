﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Volcafe.Core.Entities;

public partial class ContractStatusHistory
{
    public int Id { get; set; }

    public int ContractId { get; set; }

    public int WorkflowStatusMappingId { get; set; }

    public int StatusId { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public virtual ContractDetail Contract { get; set; }

    public virtual ContractStatus Status { get; set; }

    public virtual WorkflowStatusMapping WorkflowStatusMapping { get; set; }
}