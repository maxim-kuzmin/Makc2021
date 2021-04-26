// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DummyMainItemPageResource } from './DummyMainItemPageResource';

/**
 * Модуль страницы сущности "DummyMain".
 */
export class DummyMainItemPageModule {
  private _resourceGetter?: (
    localizationService: LocalizationService
  ) => DummyMainItemPageResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (
      localizationService: LocalizationService
    ) => DummyMainItemPageResource
  ) {
    this._resourceGetter = value;
  }

  /**
   * Создать ресурс.
   * @param localizationService Сервис локализации.
   * @returns Ресурс.
   */
  public createResource(localizationService: LocalizationService) {
    return this._resourceGetter?.call(
      this,
      localizationService
    ) as DummyMainItemPageResource;
  }

  private static _instance = new DummyMainItemPageModule();

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
