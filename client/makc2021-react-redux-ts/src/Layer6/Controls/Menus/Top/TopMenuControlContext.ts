// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TopMenuControlModule } from './TopMenuControlModule';

/**
 * Контекст элемента управления "Верхнее меню".
 */
export class TopMenuControlContext {
  /**
   * Модуль.
   */
  readonly module = new TopMenuControlModule();
}
