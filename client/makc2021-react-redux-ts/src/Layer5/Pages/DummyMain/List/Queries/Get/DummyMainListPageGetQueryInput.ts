// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createDomainListGetQueryInput,
  DomainListGetQueryInput
} from 'src/Layer4/Domains/DummyMain/Queries/List/Get/DomainListGetQueryInput';

/**
 * Входные данные запроса на получение страницы сущностей "DummyMain".
 */
export interface DummyMainListPageGetQueryInput {
  /**
   * Список.
   */
  list: DomainListGetQueryInput;
}

export function createDummyMainListPageGetQueryInput() {
  return {
    list: createDomainListGetQueryInput()
  } as DummyMainListPageGetQueryInput;
}
