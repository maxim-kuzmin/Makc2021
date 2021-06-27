// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DomainItemGetQueryOutput } from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/DomainItemGetQueryOutput';

/**
 * Выходные данные запроса на сохранение страницы примера элемента.
 */
export interface DummyMainItemPageSaveQueryOutput {
  /**
   * Элемент.
   */
  item: DomainItemGetQueryOutput;
}
