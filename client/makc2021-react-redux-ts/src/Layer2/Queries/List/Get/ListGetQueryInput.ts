// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Входные данные запроса на получение списка.
 */
export interface ListGetQueryInput {
  /**
   * Номер страницы.
   */
  pageNumber: number;

  /**
   * Размер страницы.
   */
  pageSize: number;

  /**
   * Поле сортировки.
   */
  sortField: string;

  /**
   * Направление сортировки.
   */
  sortDirection: string;
}
