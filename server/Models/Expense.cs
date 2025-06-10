namespace server.Models;

public class Expense
{
    public Guid Id { get; set; }

    public string Item { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}
