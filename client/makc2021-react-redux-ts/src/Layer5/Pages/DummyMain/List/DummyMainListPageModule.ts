// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainListPageGetQueryHandler } from './Queries/Get/DummyMainListPageGetQueryHandler';
import { DummyMainListPageService } from './DummyMainListPageService';
import { DummyMainListPageStore } from './DummyMainListPageStore';

/**
 * Модуль страницы сущностей "DummyMain".
 */
export class DummyMainListPageModule {
  private _getQueryHandlerGetter?: () => DummyMainListPageGetQueryHandler;
  private _serviceGetter?: () => DummyMainListPageService;
  private _storeGetter?: () => DummyMainListPageStore;

  /**
   * Обработчик запроса на получение.
   */
  get getQueryHandler() {
    return this._getQueryHandlerGetter?.call(
      this
    ) as DummyMainListPageGetQueryHandler;
  }

  /**
   * Обработчик запроса на получение. Получатель.
   */
  set getQueryHandlerGetter(value: () => DummyMainListPageGetQueryHandler) {
    this._getQueryHandlerGetter = value;
  }

  /**
   * Сервис.
   */
  get service() {
    return this._serviceGetter?.call(this) as DummyMainListPageService;
  }

  /**
   * Сервис. Получатель.
   */
  set serviceGetter(value: () => DummyMainListPageService) {
    this._serviceGetter = value;
  }

  /**
   * Хранилище.
   */
  get store() {
    return this._storeGetter?.call(this) as DummyMainListPageStore;
  }

  /**
   * Хранилище. Получатель.
   */
  set storeGetter(value: () => DummyMainListPageStore) {
    this._storeGetter = value;
  }
}
