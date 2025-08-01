﻿using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Categories;
using ExpenseTracker.Core.Expenses;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class ExpenseRepository(AppDbContext context) : IExpenseRepository
{
    private readonly DbSet<Expense> _dbSet = context.Set<Expense>();

    //public async Task<List<CategoryItem>?> GetListAsync(Guid categoryItemId)
    //{
    //    return await _dbSet
    //     .Include(c => c.Expenses)
    //     .Where(e => e.)
    //     .ToListAsync();
    //}

    //public async Task<CategoryItem?> AddAsync(CategoryItem entity)
    //{
    //    await _dbSet.AddAsync(entity);

    //    return entity;
    //}
    public async Task<Expense?> AddAsync(Expense expense)
    {
        await _dbSet.AddAsync(expense);

        await context.SaveChangesAsync();

        return expense;
    }


}
