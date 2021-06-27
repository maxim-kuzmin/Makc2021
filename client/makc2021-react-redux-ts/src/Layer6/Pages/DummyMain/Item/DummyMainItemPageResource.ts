// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс страницы сущности "DummyMain".
 */
export class DummyMainItemPageResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок кнопки "Очистить".
   * @returns Заголовок.
   */
  getClearButtonTitle() {
    return this._appLocalizationService.getString('Очистить');
  }

  /**
   * Получить заголовок поля "ID".
   * @returns Заголовок.
   */
  getIDFieldTitle() {
    return this._appLocalizationService.getString('ID');
  }

  /**
   * Получить заголовок поля "Имя".
   * @returns Заголовок.
   */
  getNameFieldTitle() {
    return this._appLocalizationService.getString('Имя');
  }

  /**
   * Получить заполнитель поля "Имя".
   * @returns Заполнитель.
   */
  getNameFieldPlaceholder() {
    return this._appLocalizationService.getString('Введите имя');
  }

  /**
   * Получить заголовок кнопки "Сохранить".
   * @returns Заголовок.
   */
  getSaveButtonTitle() {
    return this._appLocalizationService.getString('Сохранить');
  }
}
