using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Models;

public class Product : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CurrentStock { get; set; } = 0;
    public string Sku {  get; set; } = string.Empty;
}
