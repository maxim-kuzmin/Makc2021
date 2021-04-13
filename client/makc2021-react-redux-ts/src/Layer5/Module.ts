// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Service } from './Service';
import { DummyMainItemPageService } from './Pages/DummyMain/Item/DummyMainItemPageService';
import { DummyMainItemPageStore } from './Pages/DummyMain/Item/DummyMainItemPageStore';

/**
 * Модуль.
 */
export class Module {
  private _serviceGetter?: () => Service;
  private _serviceOfDummyMainItemPageGetter?: () => DummyMainItemPageService;
  private _storeOfDummyMainItemPageGetter?: () => DummyMainItemPageStore;

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

  /**
   * Сервис страницы сущности "DummyMain".
   */
  public get serviceOfDummyMainItemPage() {
    return this._serviceOfDummyMainItemPageGetter?.call(
      this
    ) as DummyMainItemPageService;
  }

  /**
   * Сервис страницы сущности "DummyMain". Получатель.
   */
  public set serviceOfDummyMainItemPageGetter(
    value: () => DummyMainItemPageService
  ) {
    this._serviceOfDummyMainItemPageGetter = value;
  }

  /**
   * Хранилище страницы сущности "DummyMain".
   */
  public get storeOfDummyMainItemPage() {
    return this._storeOfDummyMainItemPageGetter?.call(
      this
    ) as DummyMainItemPageStore;
  }

  /**
   * Хранилище страницы сущности "DummyMain". Получатель.
   */
  public set storeOfDummyMainItemPageGetter(
    value: () => DummyMainItemPageStore
  ) {
    this._storeOfDummyMainItemPageGetter = value;
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
