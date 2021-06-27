// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс элемента управления "Сообщение об успехе запроса".
 */
export class QuerySuccessMessageControlResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок.
   * @param queryCode Код запроса.
   * @returns Заголовок.
   */
  getTitle(queryCode: string) {
    return this._appLocalizationService.getString(
      'Запрос {{queryCode}} выполнен успешно',
      { queryCode }
    );
  }
}
