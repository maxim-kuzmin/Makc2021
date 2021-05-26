// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { TopMenuControlModule } from './TopMenuControlModule';
import { TopMenuControlResource } from './TopMenuControlResource';

/**
 * Контекст элемента управления "Верхнее меню".
 */
export class TopMenuControlContext {
  private _module = new TopMenuControlModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this._module.resourceGetter = (localizationService: LocalizationService) =>
      new TopMenuControlResource(localizationService);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
