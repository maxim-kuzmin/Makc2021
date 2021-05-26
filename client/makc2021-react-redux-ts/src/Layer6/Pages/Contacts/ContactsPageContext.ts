// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { ContactsPageModule } from './ContactsPageModule';
import { ContactsPageResource } from './ContactsPageResource';

/**
 * Контекст страницы контактов.
 */
export class ContactsPageContext {
  private _module = new ContactsPageModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this._module.resourceGetter = (localizationService: LocalizationService) =>
      new ContactsPageResource(localizationService);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
