// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ItemGetQueryDomainOutput } from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/ItemGetQueryDomainOutput';

/**
 * Модель страницы элемента сущности "DummyMain".
 */
export interface DummyMainItemPageModel {
  /**
   * Данные.
   */
  data: ItemGetQueryDomainOutput;
}
