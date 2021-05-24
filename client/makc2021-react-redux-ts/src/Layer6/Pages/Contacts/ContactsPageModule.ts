// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { ContactsPageResource } from './ContactsPageResource';

/**
 * Модуль страницы контактов.
 */
export class ContactsPageModule {
  private _resourceGetter?: (
    localizationService: LocalizationService
  ) => ContactsPageResource;

  /**
   * Ресурс. Получатель.
   */
  public set resourceGetter(
    value: (localizationService: LocalizationService) => ContactsPageResource
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
    ) as ContactsPageResource;
  }
}
