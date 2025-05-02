﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Models;

public class Category : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
