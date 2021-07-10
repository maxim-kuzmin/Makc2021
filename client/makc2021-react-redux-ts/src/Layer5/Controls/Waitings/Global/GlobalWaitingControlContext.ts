// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { GlobalWaitingControlModule } from './GlobalWaitingControlModule';
import { GlobalWaitingControlStore } from './GlobalWaitingControlStore';

/**
 * Контекст элемента управления "Глобальное ожидание".
 */
export class GlobalWaitingControlContext {
  private _module = new GlobalWaitingControlModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    const instanceOfStore = new Lazy<GlobalWaitingControlStore>(
      () => new GlobalWaitingControlStore()
    );
    this._module.storeGetter = () => instanceOfStore.value;
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
