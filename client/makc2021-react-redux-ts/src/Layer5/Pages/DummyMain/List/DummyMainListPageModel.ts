// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ListGetQueryDomainOutput } from 'src/Layer4/Domains/DummyMain/Queries/List/Get/ListGetQueryDomainOutput';

/**
 * Модель страницы сущностей "DummyMain".
 */
export interface DummyMainListPageModel {
  /**
   * Данные.
   */
  data: ListGetQueryDomainOutput;
}
