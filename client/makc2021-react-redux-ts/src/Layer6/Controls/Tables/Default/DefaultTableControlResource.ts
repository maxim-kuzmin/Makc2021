// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс элемента управления "Таблица по умолчанию".
 */
export class DefaultTableControlResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок поля "Страница".
   * @returns Заголовок.
   */
  getPageFieldTitle() {
    return this._appLocalizationService.getString('Страница');
  }

  /**
   * Получить значение поля "Страница".
   * @param pageNumber Номер страницы.
   * @param pageCount Число страниц.
   * @returns Значение.
   */
  getPageFieldValue(pageNumber: number, pageCount: number) {
    return this._appLocalizationService.getString(
      '{{pageNumber}} из {{pageCount}}',
      { pageNumber, pageCount }
    );
  }

  /**
   * Получить заголовок поля "Перейти на страницу".
   * @returns Заголовок.
   */
  getGoToPageFieldTitle() {
    return this._appLocalizationService.getString('Перейти на страницу');
  }

  /**
   * Получить заголовок поля "Показать".
   * @returns Заголовок.
   */
  getShowFieldTitle() {
    return this._appLocalizationService.getString('Показать');
  }
}
