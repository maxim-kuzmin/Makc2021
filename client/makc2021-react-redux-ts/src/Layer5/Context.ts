// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { Context as Layer1Context } from 'src/Layer1/Context';
import { Module } from './Module';
import { PagesContext } from './Pages/PagesContext';
import { Service } from './Service';

/**
 * Контекст.
 */
export class Context {
  private _module = new Module();

  /**
   * Страницы.
   */
  readonly Pages = new PagesContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   * @param apiUrl URL API.
   */
  configureServices(contextOfLayer1: Layer1Context, apiUrl: string) {
    const service = new Lazy<Service>(() => new Service(apiUrl));

    this._module.serviceGetter = () => {
      return service.value;
    };

    this.Pages.configureServices(this, contextOfLayer1);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
