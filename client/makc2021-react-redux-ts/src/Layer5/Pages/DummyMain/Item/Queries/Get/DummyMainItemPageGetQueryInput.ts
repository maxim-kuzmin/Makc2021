// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ItemGetQueryDomainInput } from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/ItemGetQueryDomainInput';

/**
 * Входные данные запроса на получение страницы сущности "DummyMain".
 */
export interface DummyMainItemPageGetQueryInput {
  /**
   * Элемент.
   */
  item: ItemGetQueryDomainInput;
}
