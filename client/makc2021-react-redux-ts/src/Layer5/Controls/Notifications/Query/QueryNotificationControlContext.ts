// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { QueryNotificationControlModule } from './QueryNotificationControlModule';
import { QueryNotificationControlStore } from './QueryNotificationControlStore';

/**
 * Контекст элемента управления "Извещение запроса".
 */
export class QueryNotificationControlContext {
  private _module = new QueryNotificationControlModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    const instanceOfStore = new Lazy<QueryNotificationControlStore>(
      () => new QueryNotificationControlStore()
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
