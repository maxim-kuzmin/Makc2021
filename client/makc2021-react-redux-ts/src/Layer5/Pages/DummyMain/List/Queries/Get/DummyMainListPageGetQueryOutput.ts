// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createDomainListGetQueryOutput,
  DomainListGetQueryOutput
} from 'src/Layer4/Domains/DummyMain/Queries/List/Get/DomainListGetQueryOutput';

/**
 * Выходные данные запроса на получение страницы сущностей "DummyMain".
 */
export interface DummyMainListPageGetQueryOutput {
  /**
   * Список.
   */
  list: DomainListGetQueryOutput;
}

/**
 * Создать выходные данные запроса на получение страницы сущностей "DummyMain"
 * @returns Выходные данные запроса на получение страницы сущностей "DummyMain".
 */
export function createDummyMainListPageGetQueryOutput() {
  return {
    list: createDomainListGetQueryOutput()
  } as DummyMainListPageGetQueryOutput;
}
