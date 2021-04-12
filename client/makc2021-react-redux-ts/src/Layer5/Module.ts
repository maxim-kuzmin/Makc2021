// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { CommonModule } from 'src/Layer1/Common/CommonModule';
import { ConfigSettings, createConfigSettings } from './Config/ConfigSettings';
import { Service } from './Service';

class Module extends CommonModule {
  private _configSettings?: ConfigSettings;
  private _service?: Service;

  constructor() {
    super('Layer5');
  }

  /**
   * Настройки конфигурации.
   */
  public get configSettings() {
    this.throwErrorIfModuleIsNotConfigured();

    return this._configSettings as ConfigSettings;
  }

  /**
   * Сервис.
   */
  public get service() {
    this.throwErrorIfModuleIsNotConfigured();

    return this._service as Service;
  }

  /**
   * Конфигурировать.
   * @param url URL.
   */
  configure(url: string) {
    this._configSettings = createConfigSettings();

    this._configSettings.apiUrl = url;

    this._service = new Service(this._configSettings);

    this.completeConfiguration();
  }
}

/**
 * Модуль слоя "Layer5".
 */
export const appLayer5Module = new Module();
