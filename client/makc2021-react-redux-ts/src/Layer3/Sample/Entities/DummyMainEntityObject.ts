// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Объект сущности "DummyMain".
 */
export interface DummyMainEntityObject {
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
 * Создать объект сущности "DummyMain".
 * @returns Объект сущности "DummyMain".
 */
export function createDummyMainEntityObject(): DummyMainEntityObject {
  return {
    id: 0,
    name: ''
  } as DummyMainEntityObject;
}
