// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createItemGetQueryInput,
  ItemGetQueryInput
} from 'src/Layer2/Queries/Item/Get/ItemGetQueryInput';

/**
 * Входные данные запроса на получение элемента в домене.
 */
export interface DomainItemGetQueryInput extends ItemGetQueryInput {
  /**
   * Имя сущности.
   */
  entityName: string;
}

/**
 * Создать входные данные запроса на получение элемента в домене.
 * @returns Входные данные запроса на получение элемента в домене.
 */
export function createDomainItemGetQueryInput() {
  return {
    entityName: '',
    ...createItemGetQueryInput()
  } as DomainItemGetQueryInput;
}
