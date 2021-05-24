// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageModule } from './DummyMainItemPageModule';

/**
 * Контекст страницы сущности "DummyMain".
 */
export class DummyMainItemPageContext {
  /**
   * Модуль.
   */
  readonly module = new DummyMainItemPageModule();
}
