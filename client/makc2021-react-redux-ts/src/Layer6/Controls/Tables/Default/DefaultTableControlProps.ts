// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Column, Filters } from 'react-table';

/**
 * Свойства элемента управления "Таблица по умолчанию".
 * @template TRow Тип строки.
 */
export interface DefaultTableControlProps<TRow extends object> {
  /**
   * Столбцы.
   */
  columns: Column<TRow>[];

  /**
   * Данные.
   */
  data: TRow[];

  /**
   * Фильтры.
   */
  filters: Filters<TRow>;

  /**
   * Признак загрузки.
   */
  loading: boolean;

  /**
   * Номер страницы.
   */
  pageNumber: number;

  /**
   * Размер страницы.
   */
  pageSize: number;

  /**
   * Направление сортировки.
   */
  sortDirection: 'asc' | 'desc';

  /**
   * Поле сортировки.
   */
  sortField: string;

  /**
   * Общее количество записей.
   */
  totalCount: number;

  /**
   * Создать URL страницы.
   */
  createPageUrl: (
    pageNumber: number,
    pageSize: number,
    sortDirection: 'asc' | 'desc',
    sortField: string,
    filters: Filters<TRow>
  ) => string;
}
