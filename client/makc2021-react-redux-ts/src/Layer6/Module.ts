// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { TopMenuControlResource } from './Controls/Menus/Top/TopMenuControlResource';

/**
 * Модуль.
 */
export class Module {
  private _resourceOfTopMenuControlGetter?: (
    localizationService: LocalizationService
  ) => TopMenuControlResource;

  /**
   * Ресурс элемента управления "Верхнее меню". Получатель.
   */
  public set resourceOfTopMenuControlGetter(
    value: (localizationService: LocalizationService) => TopMenuControlResource
  ) {
    this._resourceOfTopMenuControlGetter = value;
  }

  /**
   * Создать ресурс элемента управления "Верхнее меню".
   * @param localizationService Сервис локализации.
   * @returns Ресурс элемента управления "Верхнее меню".
   */
  public createResourceOfTopMenuControl(
    localizationService: LocalizationService
  ) {
    return this._resourceOfTopMenuControlGetter?.call(
      this,
      localizationService
    ) as TopMenuControlResource;
  }

  private static _instance = new Module();

  /**
   * Получить.
   * @returns Экземпляр.
   */
  static get() {
    return this._instance;
  }
}
