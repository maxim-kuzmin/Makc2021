// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { GlobalWaitingControlStore } from './GlobalWaitingControlStore';

/**
 * Модуль элемента управления "Глобальное ожидание".
 */
export class GlobalWaitingControlModule {
  private _storeGetter?: () => GlobalWaitingControlStore;

  /**
   * Хранилище.
   */
  public get store() {
    return this._storeGetter?.call(this) as GlobalWaitingControlStore;
  }

  /**
   * Хранилище. Получатель.
   */
  public set storeGetter(value: () => GlobalWaitingControlStore) {
    this._storeGetter = value;
  }
}
