// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
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

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Controls.configureServices(contextOfLayer1);
    this.Pages.configureServices(contextOfLayer1);
  }
}
