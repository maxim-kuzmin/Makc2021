// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Выходные данные запроса на получение списка.
 * @param <TItem> Тип элемента.
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
