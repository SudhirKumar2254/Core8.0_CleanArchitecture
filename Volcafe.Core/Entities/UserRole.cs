﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Volcafe.Core.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public int? UserTypeId { get; set; }

    public string Role { get; set; }

    public virtual UserType UserType { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}