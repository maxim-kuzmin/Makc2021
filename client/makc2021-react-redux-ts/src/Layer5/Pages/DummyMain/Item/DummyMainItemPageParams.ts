// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Параметры страницы сущности "DummyMain".
 */
export interface DummyMainItemPageParams {
  /**
   * Идентификатор.
   */
  id: string;
}

/**
 * Создать параметры страницы сущности "DummyMain".
 * @returns Параметры страницы сущности "DummyMain".
 */
export function createDummyMainItemPageParams() {
  return {
    id: ''
  } as DummyMainItemPageParams;
}
