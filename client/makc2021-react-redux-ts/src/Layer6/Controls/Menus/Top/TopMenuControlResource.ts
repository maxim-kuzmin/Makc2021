// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';

/**
 * Ресурс элемента управления "Верхнее меню".
 */
export class TopMenuControlResource {
  /**
   * Конструктор.
   * @param _appLocalizationService Сервис локализации.
   */
  constructor(private _appLocalizationService: LocalizationService) {}

  /**
   * Получить заголовок ссылки на страницу контактов.
   * @returns Заголовок.
   */
  getAppContactsPageLinkTitle() {
    return this._appLocalizationService.getString('Контакты');
  }

  /**
   * Получить заголовок ссылки на страницу сущности "DummyMain".
   * @returns Заголовок.
   */
  getAppDummyMainItemPageLinkTitle() {
    return this._appLocalizationService.getString('Элемент');
  }

  /**
   * Получить заголовок ссылки на страницу сущностей "DummyMain".
   * @returns Заголовок.
   */
  getAppDummyMainListPageLinkTitle() {
    return this._appLocalizationService.getString('Список');
  }

  /**
   * Получить заголовок ссылки на главную страницу.
   * @returns Заголовок.
   */
  getAppIndexPageLinkTitle() {
    return this._appLocalizationService.getString('Главная');
  }
}
