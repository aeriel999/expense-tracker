export function createCategory(data) {
    if (!data) return null;
    return {
        id: data.id,
        name: data.name,
        icon: data.iconPath || null,
        amount: data.amount,
        items: (data.categoryItems?.$values || []).map(createCategoryItem),
    };
}

export function createCategoryItem(data) {
    if (!data) return null;
    return {
        id: data.id,
        name: data.name,
        total: data.total,
    };
}
