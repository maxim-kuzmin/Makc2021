// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { QueryErrorControlResource } from './QueryErrorControlResource';

/**
 * Модуль элемента управления "Ошибка запроса".
 */
export class QueryErrorControlModule {
  private _resourceGetter?: (
    localizationService: LocalizationService
  ) => QueryErrorControlResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (
      localizationService: LocalizationService
    ) => QueryErrorControlResource
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
    ) as QueryErrorControlResource;
  }
}
