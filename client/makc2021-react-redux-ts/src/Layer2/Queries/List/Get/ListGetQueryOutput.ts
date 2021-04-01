// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Выходные данные запроса на получение списка элементов.
 * @template TItem Тип элемента.
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
 * Создать выходные данные запроса на получение списка элементов.
 * @template TItem Тип элемента.
 * @returns Выходные данные запроса на получение списка элементов.
 */
export function createListGetQueryOutput<TItem>(): ListGetQueryOutput<TItem> {
  return {
    totalCount: 0
  } as ListGetQueryOutput<TItem>;
}
