// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageGetQueryHandler } from './Queries/Get/DummyMainItemPageGetQueryHandler';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { DummyMainItemPageStore } from './DummyMainItemPageStore';

/**
 * Модуль страницы сущности "DummyMain".
 */
export class DummyMainItemPageModule {
  private _getQueryHandlerGetter?: () => DummyMainItemPageGetQueryHandler;
  private _serviceGetter?: () => DummyMainItemPageService;
  private _storeGetter?: () => DummyMainItemPageStore;

  /**
   * Обработчик запроса на получение.
   */
  public get getQueryHandler() {
    return this._getQueryHandlerGetter?.call(
      this
    ) as DummyMainItemPageGetQueryHandler;
  }

  /**
   * Обработчик запроса на получение. Получатель.
   */
  public set getQueryHandlerGetter(
    value: () => DummyMainItemPageGetQueryHandler
  ) {
    this._getQueryHandlerGetter = value;
  }

  /**
   * Сервис.
   */
  public get service() {
    return this._serviceGetter?.call(this) as DummyMainItemPageService;
  }

  /**
   * Сервис страницы сущности "DummyMain". Получатель.
   */
  public set serviceGetter(value: () => DummyMainItemPageService) {
    this._serviceGetter = value;
  }

  /**
   * Хранилище.
   */
  public get store() {
    return this._storeGetter?.call(this) as DummyMainItemPageStore;
  }

  /**
   * Хранилище. Получатель.
   */
  public set storeGetter(value: () => DummyMainItemPageStore) {
    this._storeGetter = value;
  }

  private static _instance = new DummyMainItemPageModule();

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
