// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainPagesContext } from './DummyMain/DummyMainPagesContext';

/**
 * Контекст страниц.
 */
export class PagesContext {
  /**
   * Сущность "DummyMain".
   */
  readonly DummyMain = new DummyMainPagesContext();
}
