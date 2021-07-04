// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс элемента управления "Извещение запроса".
 */
export class QueryNotificationControlResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок ошибки.
   * @param queryCode Код запроса.
   * @returns Заголовок.
   */
  getTitleOfError(queryCode: string) {
    return this._appLocalizationService.getString(
      'Запрос {{queryCode}} выполнен с ошибками',
      { queryCode }
    );
  }

  /**
   * Получить заголовок успеха.
   * @param queryCode Код запроса.
   * @returns Заголовок.
   */
  getTitleOfSuccess(queryCode: string) {
    return this._appLocalizationService.getString(
      'Запрос {{queryCode}} выполнен успешно',
      { queryCode }
    );
  }

  /**
   * Получить заголовок предупреждения.
   * @param queryCode Код запроса.
   * @returns Заголовок.
   */
  getTitleOfWarning(queryCode: string) {
    return this._appLocalizationService.getString(
      'Запрос {{queryCode}} выполнен с предупреждениями',
      { queryCode }
    );
  }
}
