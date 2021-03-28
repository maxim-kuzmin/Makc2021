// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ListGetQueryDomainOutput } from 'src/Layer4/Domains/DummyMain/Queries/List/Get/ListGetQueryDomainOutput';

/**
 * Выходные данные запроса на получение страницы сущностей "DummyMain".
 */
export interface DummyMainListPageGetQueryOutput {
  /**
   * Список.
   */
  List: ListGetQueryDomainOutput;
}
