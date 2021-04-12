// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Входные данные запроса на получение элемента.
 */
export interface ItemGetQueryInput {
  /**
   * Идентификатор сущности.
   */
  entityId: number;
}

/**
 * Создать входные данные запроса на получение элемента.
 * @returns Входные данные запроса на получение элемента.
 */
export function createItemGetQueryInput() {
  return {
    entityId: 0
  } as ItemGetQueryInput;
}
