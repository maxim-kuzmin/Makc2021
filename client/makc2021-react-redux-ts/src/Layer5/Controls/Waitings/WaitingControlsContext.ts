// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { GlobalWaitingControlContext } from './Global/GlobalWaitingControlContext';

/**
 * Контекст элементов управления "Ожидание".
 */
export class WaitingControlsContext {
  /**
   * Верхнее.
   */
  readonly Global = new GlobalWaitingControlContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Global.configureServices();
  }
}
