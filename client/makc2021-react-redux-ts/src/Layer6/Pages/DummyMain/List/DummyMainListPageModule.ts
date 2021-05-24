// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DummyMainListPageResource } from './DummyMainListPageResource';

/**
 * Модуль страницы сущностей "DummyMain".
 */
export class DummyMainListPageModule {
  private _resourceGetter?: (
    localizationService: LocalizationService
  ) => DummyMainListPageResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (
      localizationService: LocalizationService
    ) => DummyMainListPageResource
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
    ) as DummyMainListPageResource;
  }
}
