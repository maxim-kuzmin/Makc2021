// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { QueryErrorControlModule } from './QueryErrorControlModule';
import { QueryErrorControlResource } from './QueryErrorControlResource';

/**
 * Контекст элемента управления "Ошибка запроса".
 */
export class QueryErrorControlContext {
  private _module = new QueryErrorControlModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this._module.resourceGetter = (localizationService: LocalizationService) =>
      new QueryErrorControlResource(localizationService);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
