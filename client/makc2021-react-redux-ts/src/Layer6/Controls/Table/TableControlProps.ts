// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Column } from 'react-table';

/**
 * Свойства элемента управления "Таблица".
 * @template TRow Тип строки.
 */
export interface TableControlProps<TRow extends object> {
  /**
   * Столбцы.
   */
  columns: Column<TRow>[];

  /**
   * Данные.
   */
  data: TRow[];

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
   * Общее количество записей.
   */
  totalCount: number;

  /**
   * Создать URL страницы.
   */
  createPageUrl: (pageNumber: number, pageSize: number) => string;
}
