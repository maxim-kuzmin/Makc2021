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
   * Функция получения данных.
   */
  fetchData: Function;

  /**
   * Признак загрузки.
   */
  loading: boolean;

  /**
   * Число страниц.
   */
  pageCount: number;
}
