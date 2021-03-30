// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createItemGetQueryDomainInput,
  ItemGetQueryDomainInput
} from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/ItemGetQueryDomainInput';

/**
 * Входные данные запроса на получение страницы сущности "DummyMain".
 */
export interface DummyMainItemPageGetQueryInput {
  /**
   * Элемент.
   */
  item: ItemGetQueryDomainInput;
}

/**
 * Создать входные данные запроса на получение страницы сущности "DummyMain".
 * @returns Входные данные запроса на получение страницы сущности "DummyMain".
 */
export function createDummyMainItemPageGetQueryInput(): DummyMainItemPageGetQueryInput {
  return {
    item: createItemGetQueryDomainInput()
  } as DummyMainItemPageGetQueryInput;
}
