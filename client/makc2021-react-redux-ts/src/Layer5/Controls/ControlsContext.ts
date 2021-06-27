// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { MenuControlsContext } from './Menus/MenuControlsContext';

/**
 * Контекст элементов управления.
 */
export class ControlsContext {
  /**
   * Меню.
   */
  readonly Menus = new MenuControlsContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Menus.configureServices();
  }
}
