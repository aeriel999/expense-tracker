export function createCategory(data) {
    return {
        id: data.id,
        name: data.name,
        icon: data.iconPath || null,
        items: (data.categoryItems?.$values || []).map(createCategoryItem),
    };
}

export function createCategoryItem(data) {
    return {
        id: data.id,
        name: data.name,
        description: data.description || null,
    };
}
