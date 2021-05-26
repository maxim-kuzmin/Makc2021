// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DefaultTableControlModule } from './DefaultTableControlModule';
import { DefaultTableControlResource } from './DefaultTableControlResource';

/**
 * Контекст элемента управления "Таблица по умолчанию".
 */
export class DefaultTableControlContext {
  private _module = new DefaultTableControlModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this._module.resourceGetter = (localizationService: LocalizationService) =>
      new DefaultTableControlResource(localizationService);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
