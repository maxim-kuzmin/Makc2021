// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DummyMainItemPageModule } from './DummyMainItemPageModule';
import { DummyMainItemPageResource } from './DummyMainItemPageResource';

/**
 * Контекст страницы сущности "DummyMain".
 */
export class DummyMainItemPageContext {
  private _module = new DummyMainItemPageModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this._module.resourceGetter = (localizationService: LocalizationService) =>
      new DummyMainItemPageResource(localizationService);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
