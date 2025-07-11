﻿using ExpenseTracker.Application.Categories.Results;
using ExpenseTracker.Core.Categories;
using Mapster;

namespace ExpenseTracker.Application.Common.Mapping;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryItem, CategoryItemResult>()
           .Map(desp => desp.Id, src => src.Id)
           .Map(desp => desp.Name, src => src.Name)
           .Map(desp => desp.Total, src => src.Expenses != null ? src.Expenses.Sum(e => e.Amount) : 0);

        config.NewConfig<List<CategoryItem>, List<CategoryItemResult>>();

        config.NewConfig<Category, CategoryResult>()
             .Map(desp => desp.Id, src => src.Id)
             .Map(desp => desp.Name, src => src.Name)
             .Map(desp => desp.IconPath, src => src.IconPath)
             .Map(desp => desp.Amount,
                 src => src.CategoryItems != null
                     ? src.CategoryItems.Sum(item =>
                         item.Expenses != null
                             ? item.Expenses.Sum(e => e.Amount)
                             : 0)
                     : 0)
             .Map(desp => desp.CategoryItems, src => src.CategoryItems);  


        config.NewConfig<List<Category>, List<CategoryResult>>();
    }
}
