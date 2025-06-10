using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class CategoryItem
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public Guid CategoryId { get; set; }


    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }
}
