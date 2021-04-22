// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { QueryErrorControlResource } from './Controls/Errors/Query/QueryErrorControlResource';
import { TopMenuControlResource } from './Controls/Menus/Top/TopMenuControlResource';

/**
 * Модуль.
 */
export class Module {
  private _resourceOfQueryErrorControlGetter?: (
    localizationService: LocalizationService
  ) => QueryErrorControlResource;

  private _resourceOfTopMenuControlGetter?: (
    localizationService: LocalizationService
  ) => TopMenuControlResource;

  /**
   * Ресурс элемента управления "Ошибка запроса". Получатель.
   */
  public set resourceOfQueryErrorControlGetter(
    value: (
      localizationService: LocalizationService
    ) => QueryErrorControlResource
  ) {
    this._resourceOfQueryErrorControlGetter = value;
  }

  /**
   * Ресурс элемента управления "Верхнее меню". Получатель.
   */
  public set resourceOfTopMenuControlGetter(
    value: (localizationService: LocalizationService) => TopMenuControlResource
  ) {
    this._resourceOfTopMenuControlGetter = value;
  }

  /**
   * Создать ресурс элемента управления "Ошибка запроса".
   * @param localizationService Сервис локализации.
   * @returns Ресурс элемента управления "Ошибка запроса".
   */
  public createResourceOfQueryErrorControl(
    localizationService: LocalizationService
  ) {
    return this._resourceOfQueryErrorControlGetter?.call(
      this,
      localizationService
    ) as QueryErrorControlResource;
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
