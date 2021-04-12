// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { CommonModule } from './Common/CommonModule';
import { HttpService } from './Http/HttpService';
import { UrlService } from './Url/UrlService';

class Module extends CommonModule {
  private _httpService?: HttpService;
  private _urlServive?: UrlService;

  constructor() {
    super('Layer1');
  }

  /**
   * Сервис HTTP.
   */
  public get httpServive() {
    this.throwErrorIfModuleIsNotConfigured();

    return this._httpService as HttpService;
  }

  /**
   * Сервис URL.
   */
  public get urlServive() {
    this.throwErrorIfModuleIsNotConfigured();

    return this._urlServive as UrlService;
  }

  /**
   * Конфигурировать.
   */
  configure() {
    this._httpService = new HttpService();

    this._urlServive = new UrlService();

    this.completeConfiguration();
  }
}

/**
 * Модуль слоя "Layer1".
 */
export const appLayer1Module = new Module();
