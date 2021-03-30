// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createListGetQueryDomainInput,
  ListGetQueryDomainInput
} from 'src/Layer4/Domains/DummyMain/Queries/List/Get/ListGetQueryDomainInput';

/**
 * Входные данные запроса на получение страницы сущностей "DummyMain".
 */
export interface DummyMainListPageGetQueryInput {
  /**
   * Список.
   */
  list: ListGetQueryDomainInput;
}

export function createDummyMainListPageGetQueryInput(): DummyMainListPageGetQueryInput {
  return {
    list: createListGetQueryDomainInput()
  } as DummyMainListPageGetQueryInput;
}
