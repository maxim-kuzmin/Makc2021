// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageService } from './Pages/DummyMain/Item/DummyMainItemPageService';
import { DummyMainItemPageStore } from './Pages/DummyMain/Item/DummyMainItemPageStore';
import { DummyMainItemPageGetQueryHandler } from './Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryHandler';
import { DummyMainListPageService } from './Pages/DummyMain/List/DummyMainListPageService';
import { DummyMainListPageStore } from './Pages/DummyMain/List/DummyMainListPageStore';
import { DummyMainListPageGetQueryHandler } from './Pages/DummyMain/List/Queries/Get/DummyMainListPageGetQueryHandler';
import { Service } from './Service';

/**
 * Модуль.
 */
export class Module {
  private _getQueryHandlerOfDummyMainItemPageGetter?: () => DummyMainItemPageGetQueryHandler;
  private _getQueryHandlerOfDummyMainListPageGetter?: () => DummyMainListPageGetQueryHandler;
  private _serviceGetter?: () => Service;
  private _serviceOfDummyMainItemPageGetter?: () => DummyMainItemPageService;
  private _serviceOfDummyMainListPageGetter?: () => DummyMainListPageService;
  private _storeOfDummyMainItemPageGetter?: () => DummyMainItemPageStore;
  private _storeOfDummyMainListPageGetter?: () => DummyMainListPageStore;

  /**
   * Сервис.
   */
  public get service() {
    return this._serviceGetter?.call(this) as Service;
  }

  /**
   * Обработчик запроса на получение страницы сущности "DummyMain".
   */
  public get getQueryHandlerOfDummyMainItemPage() {
    return this._getQueryHandlerOfDummyMainItemPageGetter?.call(
      this
    ) as DummyMainItemPageGetQueryHandler;
  }

  /**
   * Обработчик запроса на получение страницы сущности "DummyMain". Получатель.
   */
  public set getQueryHandlerOfDummyMainItemPageGetter(
    value: () => DummyMainItemPageGetQueryHandler
  ) {
    this._getQueryHandlerOfDummyMainItemPageGetter = value;
  }

  /**
   * Обработчик запроса на получение страницы сущностей "DummyMain".
   */
  public get getQueryHandlerOfDummyMainListPage() {
    return this._getQueryHandlerOfDummyMainListPageGetter?.call(
      this
    ) as DummyMainListPageGetQueryHandler;
  }

  /**
   * Обработчик запроса на получение страницы сущностей "DummyMain". Получатель.
   */
  public set getQueryHandlerOfDummyMainListPageGetter(
    value: () => DummyMainListPageGetQueryHandler
  ) {
    this._getQueryHandlerOfDummyMainListPageGetter = value;
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
   * Сервис страницы сущностей "DummyMain".
   */
  public get serviceOfDummyMainListPage() {
    return this._serviceOfDummyMainListPageGetter?.call(
      this
    ) as DummyMainListPageService;
  }

  /**
   * Сервис страницы сущностей "DummyMain". Получатель.
   */
  public set serviceOfDummyMainListPageGetter(
    value: () => DummyMainListPageService
  ) {
    this._serviceOfDummyMainListPageGetter = value;
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

  /**
   * Хранилище страницы сущностей "DummyMain".
   */
  public get storeOfDummyMainListPage() {
    return this._storeOfDummyMainListPageGetter?.call(
      this
    ) as DummyMainListPageStore;
  }

  /**
   * Хранилище страницы сущностей "DummyMain". Получатель.
   */
  public set storeOfDummyMainListPageGetter(
    value: () => DummyMainListPageStore
  ) {
    this._storeOfDummyMainListPageGetter = value;
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
