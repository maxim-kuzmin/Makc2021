// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DummyMainListPageModule } from './DummyMainListPageModule';
import { DummyMainListPageResource } from './DummyMainListPageResource';

/**
 * Контекст страницы сущностей "DummyMain".
 */
export class DummyMainListPageContext {
  private _module = new DummyMainListPageModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this._module.resourceGetter = (localizationService: LocalizationService) =>
      new DummyMainListPageResource(localizationService);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
