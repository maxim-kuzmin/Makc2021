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
   * Получить заголовок для ссылки на страницу контактов.
   * @returns Заголовок.
   */
  getLinkTitleForContactsItemPage() {
    return this._appLocalizationService.getString('Контакты');
  }

  /**
   * Получить заголовок для ссылки на страницу сущности "DummyMain".
   * @returns Заголовок.
   */
  getLinkTitleForDummyMainItemPage() {
    return this._appLocalizationService.getString('Элемент');
  }

  /**
   * Получить заголовок для ссылки на страницу сущностей "DummyMain".
   * @returns Заголовок.
   */
  getLinkTitleForDummyMainListPage() {
    return this._appLocalizationService.getString('Список');
  }
}
