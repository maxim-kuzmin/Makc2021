// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DefaultTableControlModule } from './DefaultTableControlModule';

/**
 * Контекст элемента управления "Таблица по умолчанию".
 */
export class DefaultTableControlContext {
  /**
   * Модуль.
   */
  readonly module = new DefaultTableControlModule();
}
