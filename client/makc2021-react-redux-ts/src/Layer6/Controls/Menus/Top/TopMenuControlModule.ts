// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { TopMenuControlResource } from './TopMenuControlResource';

/**
 * Модуль элемента управления "Верхнее меню".
 */
export class TopMenuControlModule {
  private _resourceGetter?: (
    localizationService: LocalizationService
  ) => TopMenuControlResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (localizationService: LocalizationService) => TopMenuControlResource
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
    ) as TopMenuControlResource;
  }

  private static _instance = new TopMenuControlModule();

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
