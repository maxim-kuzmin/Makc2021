// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DefaultTableControlResource } from './DefaultTableControlResource';

/**
 * Модуль элемента управления "Таблица по умолчанию".
 */
export class DefaultTableControlModule {
  private _resourceGetter?: (
    localizationService: LocalizationService
  ) => DefaultTableControlResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (
      localizationService: LocalizationService
    ) => DefaultTableControlResource
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
    ) as DefaultTableControlResource;
  }

  private static _instance = new DefaultTableControlModule();

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
