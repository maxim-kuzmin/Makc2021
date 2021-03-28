// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ItemGetQueryDomainOutput } from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/ItemGetQueryDomainOutput';

/**
 * Выходные данные запроса на получение страницы сущности "DummyMain".
 */
export interface DummyMainItemPageGetQueryOutput {
  /**
   * Элемент.
   */
  item: ItemGetQueryDomainOutput;
}
