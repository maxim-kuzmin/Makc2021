// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { HttpService } from './Http/HttpService';
import { UrlService } from './Url/UrlService';

export class Module {
  private _httpService = new HttpService();
  private _urlService = new UrlService();

  /**
   * Сервис HTTP.
   */
  public get httpService() {
    return this._httpService;
  }

  /**
   * Сервис URL.
   */
  public get urlService() {
    return this._urlService;
  }

  private static _instance: Module;

  /**
   * Настроить.
   */
  static configure() {
    this._instance = new Module();
  }

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
