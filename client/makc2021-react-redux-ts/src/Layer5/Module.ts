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
  public get service() {
    return this._serviceGetter?.call(this) as Service;
  }

  /**
   * Сервис. Получатель.
   */
  public set serviceGetter(value: () => Service) {
    this._serviceGetter = value;
  }

  private static _instance = new Module();

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
