using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Expenses;
public class Expense
{
    public Guid Id { get; set; }

    public string Item { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}
