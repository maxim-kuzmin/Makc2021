// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryNotificationControlStore } from './QueryNotificationControlStore';

/**
 * Модуль элемента управления "Извещение запроса".
 */
export class QueryNotificationControlModule {
  private _storeGetter?: () => QueryNotificationControlStore;

  /**
   * Хранилище.
   */
  public get store() {
    return this._storeGetter?.call(this) as QueryNotificationControlStore;
  }

  /**
   * Хранилище. Получатель.
   */
  public set storeGetter(value: () => QueryNotificationControlStore) {
    this._storeGetter = value;
  }
}
