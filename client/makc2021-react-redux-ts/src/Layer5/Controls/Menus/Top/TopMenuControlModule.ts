// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TopMenuControlStore } from './TopMenuControlStore';

/**
 * Модуль элемента управления "Верхнее меню".
 */
export class TopMenuControlModule {
  private _storeGetter?: () => TopMenuControlStore;

  /**
   * Хранилище.
   */
  public get store() {
    return this._storeGetter?.call(this) as TopMenuControlStore;
  }

  /**
   * Хранилище. Получатель.
   */
  public set storeGetter(value: () => TopMenuControlStore) {
    this._storeGetter = value;
  }
}
