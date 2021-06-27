// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageGetQueryHandler } from './Queries/Get/DummyMainItemPageGetQueryHandler';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { DummyMainItemPageStore } from './DummyMainItemPageStore';
import { DummyMainItemPageSaveQueryHandler } from './Queries/Save/DummyMainItemPageSaveQueryHandler';

/**
 * Модуль страницы сущности "DummyMain".
 */
export class DummyMainItemPageModule {
  private _getQueryHandlerGetter?: () => DummyMainItemPageGetQueryHandler;
  private _saveQueryHandlerGetter?: () => DummyMainItemPageSaveQueryHandler;
  private _serviceGetter?: () => DummyMainItemPageService;
  private _storeGetter?: () => DummyMainItemPageStore;

  /**
   * Обработчик запроса на получение.
   */
  get getQueryHandler() {
    return this._getQueryHandlerGetter?.call(
      this
    ) as DummyMainItemPageGetQueryHandler;
  }

  /**
   * Обработчик запроса на получение. Получатель.
   */
  set getQueryHandlerGetter(value: () => DummyMainItemPageGetQueryHandler) {
    this._getQueryHandlerGetter = value;
  }

  /**
   * Обработчик запроса на сохранение.
   */
  public get saveQueryHandler() {
    return this._saveQueryHandlerGetter?.call(
      this
    ) as DummyMainItemPageSaveQueryHandler;
  }

  /**
   * Обработчик запроса на сохранение. Получатель.
   */
  public set saveQueryHandlerGetter(
    value: () => DummyMainItemPageSaveQueryHandler
  ) {
    this._saveQueryHandlerGetter = value;
  }

  /**
   * Сервис.
   */
  get service() {
    return this._serviceGetter?.call(this) as DummyMainItemPageService;
  }

  /**
   * Сервис страницы сущности "DummyMain". Получатель.
   */
  set serviceGetter(value: () => DummyMainItemPageService) {
    this._serviceGetter = value;
  }

  /**
   * Хранилище.
   */
  get store() {
    return this._storeGetter?.call(this) as DummyMainItemPageStore;
  }

  /**
   * Хранилище. Получатель.
   */
  set storeGetter(value: () => DummyMainItemPageStore) {
    this._storeGetter = value;
  }
}
