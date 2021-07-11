// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { FocusBehaviourStore } from './FocusBehaviourStore';

/**
 * Модуль поведения фокуса.
 */
export class FocusBehaviourModule {
  private _storeGetter?: () => FocusBehaviourStore;

  /**
   * Хранилище.
   */
  public get store() {
    return this._storeGetter?.call(this) as FocusBehaviourStore;
  }

  /**
   * Хранилище. Получатель.
   */
  public set storeGetter(value: () => FocusBehaviourStore) {
    this._storeGetter = value;
  }
}
