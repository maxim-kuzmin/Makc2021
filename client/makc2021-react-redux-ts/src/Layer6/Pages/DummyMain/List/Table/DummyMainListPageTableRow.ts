// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Строка таблицы на странице сущностей "DummyMain".
 */
export interface DummyMainListPageTableRow {
  /**
   * Действие.
   */
  action: string;

  /**
   * Идентификатор.
   */
  id: number;

  /**
   * Имя.
   */
  name: string;
}

/**
 * Создать строку таблицы на странице сущностей "DummyMain".
 * @returns Строка таблицы на странице сущностей "DummyMain".
 */
export function createDummyMainListPageTableRow() {
  return {
    action: '',
    id: 0,
    name: ''
  } as DummyMainListPageTableRow;
}
