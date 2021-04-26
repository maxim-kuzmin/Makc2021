// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс страницы сущностей "DummyMain".
 */
export class DummyMainListPageResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок столбца "ID".
   * @returns Заголовок.
   */
  getIDColumnTitle() {
    return this._appLocalizationService.getString('ID');
  }

  /**
   * Получить заголовок столбца "Имя".
   * @returns Заголовок.
   */
  getNameColumnTitle() {
    return this._appLocalizationService.getString('Имя');
  }

  /**
   * Получить заголовок ссылки "Просмотреть".
   * @returns Заполнитель.
   */
  getViewLinkTitle() {
    return this._appLocalizationService.getString('Просмотреть');
  }
}
