// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { HttpService } from './Http/HttpService';
import { UrlService } from './Url/UrlService';

export class Module {
  private _httpServiceGetter?: () => HttpService;
  private _urlServiceGetter?: () => UrlService;

  /**
   * Сервис HTTP.
   */
  public get httpService() {
    return this._httpServiceGetter?.call(this) as HttpService;
  }

  /**
   * Сервис HTTP. Получатель.
   */
  public set httpServiceGetter(value: () => HttpService) {
    this._httpServiceGetter = value;
  }

  /**
   * Сервис URL.
   */
  public get urlService() {
    return this._urlServiceGetter?.call(this) as UrlService;
  }

  /**
   * Сервис URL. Получатель.
   */
  public set urlServiceGetter(value: () => UrlService) {
    this._urlServiceGetter = value;
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
