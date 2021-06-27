// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createDomainItemGetQueryInput,
  DomainItemGetQueryInput
} from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/DomainItemGetQueryInput';

/**
 * Входные данные запроса на получение страницы сущности "DummyMain".
 */
export interface DummyMainItemPageGetQueryInput {
  /**
   * Элемент.
   */
  item: DomainItemGetQueryInput;
}

/**
 * Создать входные данные запроса на получение страницы сущности "DummyMain".
 * @returns Входные данные запроса на получение страницы сущности "DummyMain".
 */
export function createDummyMainItemPageGetQueryInput(): DummyMainItemPageGetQueryInput {
  return {
    item: createDomainItemGetQueryInput()
  } as DummyMainItemPageGetQueryInput;
}
