// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Service } from './Service';

/**
 * Модуль.
 */
export class Module {
  private _serviceGetter?: () => Service;

  /**
   * Сервис.
   */
  get service() {
    return this._serviceGetter?.call(this) as Service;
  }

  /**
   * Сервис. Получатель.
   */
  set serviceGetter(value: () => Service) {
    this._serviceGetter = value;
  }
}
