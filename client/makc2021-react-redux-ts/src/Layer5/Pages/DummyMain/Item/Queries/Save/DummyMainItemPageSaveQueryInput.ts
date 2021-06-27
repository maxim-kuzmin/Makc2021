// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createDomainItemGetQueryOutput,
  DomainItemGetQueryOutput
} from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/DomainItemGetQueryOutput';

/**
 * Входные данные запроса на сохранение страницы сущности "DummyMain".
 */
export interface DummyMainItemPageSaveQueryInput {
  /**
   * Данные.
   */
  data: DomainItemGetQueryOutput;
}

/**
 * Создать входные данные запроса на сохранение страницы сущности "DummyMain".
 * @returns Входные данные запроса на сохранение страницы сущности "DummyMain".
 */
export function createDummyMainItemPageSaveQueryInput() {
  return {
    data: createDomainItemGetQueryOutput()
  } as DummyMainItemPageSaveQueryInput;
}
