// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TopMenuControlContext } from './Top/TopMenuControlContext';

/**
 * Контекст элементов управления "Меню".
 */
export class MenuControlsContext {
  /**
   * Верхнее.
   */
  readonly Top = new TopMenuControlContext();
}
