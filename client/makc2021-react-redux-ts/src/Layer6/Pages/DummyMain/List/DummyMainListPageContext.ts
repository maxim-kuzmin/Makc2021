// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainListPageModule } from './DummyMainListPageModule';

/**
 * Контекст страницы сущностей "DummyMain".
 */
export class DummyMainListPageContext {
  /**
   * Модуль.
   */
  readonly module = new DummyMainListPageModule();
}
