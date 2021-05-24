// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ControlsContext } from './Controls/ControlsContext';
import { PagesContext } from './Pages/PagesContext';

/**
 * Контекст.
 */
export class Context {
  /**
   * Элементы управления.
   */
  readonly Controls = new ControlsContext();

  /**
   * Страницы.
   */
  readonly Pages = new PagesContext();
}
