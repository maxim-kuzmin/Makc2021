// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс страницы контактов.
 */
export class ContactsPageResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок поля "Author".
   * @returns Заголовок.
   */
  getAuthorFieldTitle() {
    return this._appLocalizationService.getString('Author');
  }

  /**
   * Получить значение поля "Author".
   * @returns Значение.
   */
  getAuthorFieldValue() {
    return this._appLocalizationService.getString('Максим Кузьмин');
  }

  /**
   * Получить заголовок поля "E-mail".
   * @returns Заголовок.
   */
  getEmailFieldTitle() {
    return this._appLocalizationService.getString('E-mail');
  }
}
