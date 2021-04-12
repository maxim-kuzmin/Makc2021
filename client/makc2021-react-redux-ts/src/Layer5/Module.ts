// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageService } from './Pages/DummyMain/Item/DummyMainItemPageService';
import { Service } from './Service';
import { HttpService } from 'src/Layer1/Http/HttpService';
import { DummyMainItemPageStore } from './Pages/DummyMain/Item/DummyMainItemPageStore';

/**
 * Модуль.
 */
export class Module {
  private _service: Service;
  private _serviceOfDummyMainItemPage: DummyMainItemPageService;
  private _storeOfDummyMainItemPage: DummyMainItemPageStore;

  private constructor(apiUrl: string, httpService: HttpService) {
    this._service = new Service(apiUrl);

    this._serviceOfDummyMainItemPage = new DummyMainItemPageService(
      httpService,
      this.service
    );

    this._storeOfDummyMainItemPage = new DummyMainItemPageStore(
      this.serviceOfDummyMainItemPage
    );
  }

  /**
   * Сервис.
   */
  public get service() {
    return this._service;
  }

  /**
   * Сервис страницы сущности "DummyMain".
   */
  public get serviceOfDummyMainItemPage() {
    return this._serviceOfDummyMainItemPage;
  }

  /**
   * Срез страницы сущности "DummyMain".
   */
  public get sliceOfDummyMainItemPage() {
    return this._storeOfDummyMainItemPage;
  }

  private static _instance: Module;

  /**
   * Настроить.
   */
  static configure(apiUrl: string, httpService: HttpService) {
    this._instance = new Module(apiUrl, httpService);
  }

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
