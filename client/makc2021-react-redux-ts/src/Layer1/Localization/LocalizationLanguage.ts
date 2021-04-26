// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { i18n } from 'i18next';

/**
 * Язык локализации.
 */
export class LocalizationLanguage {
  /**
   * Текущий.
   */
  get current() {
    return this._i18n.language;
  }

  /**
   * Конструктор.
   * @param _i18n Интернационализация.
   */
  constructor(private _i18n: i18n) {}

  /**
   * Изменить.
   * @param language Язык.
   */
  change(language: string) {
    this._i18n.changeLanguage(language);
  }
}
