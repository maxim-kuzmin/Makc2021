// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageContext } from './Item/DummyMainItemPageContext';
import { DummyMainListPageContext } from './List/DummyMainListPageContext';

/**
 * Контекст страниц сущности "DummyMain".
 */
export class DummyMainPagesContext {
  /**
   * Элемент.
   */
  readonly Item = new DummyMainItemPageContext();

  /**
   * Список.
   */
  readonly List = new DummyMainListPageContext();
}
