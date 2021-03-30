// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Выходные данные запроса на получение списка элементов типа TItem.
 */
export interface ListGetQueryOutput<TItem> {
  /**
   * Элементы.
   */
  items: TItem;

  /**
   * Общее число элементов.
   */
  totalCount: number;
}

/**
 * Создать выходные данные запроса на получение списка элементов типа TItem.
 * @returns Выходные данные запроса на получение списка элементов типа TItem.
 */
export function createListGetQueryOutput<TItem>(): ListGetQueryOutput<TItem> {
  return {
    totalCount: 0
  } as ListGetQueryOutput<TItem>;
}
