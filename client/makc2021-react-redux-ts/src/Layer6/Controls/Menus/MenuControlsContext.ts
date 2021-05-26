// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { TopMenuControlContext } from './Top/TopMenuControlContext';

/**
 * Контекст элементов управления "Меню".
 */
export class MenuControlsContext {
  /**
   * Верхнее.
   */
  readonly Top = new TopMenuControlContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Top.configureServices(contextOfLayer1);
  }
}
