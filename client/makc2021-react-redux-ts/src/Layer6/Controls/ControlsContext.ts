// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ErrorControlsContext } from './Errors/ErrorControlsContext';
import { MenuControlsContext } from './Menus/MenuControlsContext';
import { TableControlsContext } from './Tables/TableControlsContext';

/**
 * Контекст элементов управления.
 */
export class ControlsContext {
  /**
   * Ошибки.
   */
  readonly Errors = new ErrorControlsContext();

  /**
   * Меню.
   */
  readonly Menus = new MenuControlsContext();

  /**
   * Таблицы.
   */
  readonly Tables = new TableControlsContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Errors.configureServices();
    this.Menus.configureServices();
    this.Tables.configureServices();
  }
}
