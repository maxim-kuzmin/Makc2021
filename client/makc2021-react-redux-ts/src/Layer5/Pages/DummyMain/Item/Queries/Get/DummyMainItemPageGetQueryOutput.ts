// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DomainItemGetQueryOutput } from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/DomainItemGetQueryOutput';

/**
 * Выходные данные запроса на получение страницы сущности "DummyMain".
 */
export interface DummyMainItemPageGetQueryOutput {
  /**
   * Элемент.
   */
  item: DomainItemGetQueryOutput;
}
