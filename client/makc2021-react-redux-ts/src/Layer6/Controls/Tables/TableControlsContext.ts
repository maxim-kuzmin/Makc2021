// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DefaultTableControlContext } from './Default/DefaultTableControlContext';

/**
 * Контекст элементов управления "Таблица".
 */
export class TableControlsContext {
  /**
   * По умолчанию.
   */
  readonly Default = new DefaultTableControlContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Default.configureServices();
  }
}
