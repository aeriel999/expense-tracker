using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Categories;

public class CategoryItem
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public Guid CategoryId { get; set; }


    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }
}