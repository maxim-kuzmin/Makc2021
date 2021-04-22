// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import i18next, { TFunction } from 'i18next';
import { initReactI18next } from 'react-i18next';
import Backend from 'i18next-http-backend';

/**
 * Сервис локализации.
 */
export class LocalizationService {
  /**
   * Конструктор.
   * @param functionToTranslate Функция перевода.
   */
  constructor(private functionToTranslate: TFunction) {}

  /**
   * Получить строку.
   * @param key Ключ.
   * @param options Опции.
   * @returns Строка.
   */
  getString(key: string, options?: any) {
    return this.functionToTranslate.call(this, key, options);
  }

  /**
   * Начать.
   * @param language Язык
   */
  static start(language: 'en' | 'ru') {
    i18next
      .use(Backend)
      .use(initReactI18next)
      .init({
        backend: {
          loadPath: '/locales/{{lng}}/{{ns}}.json'
        },
        supportedLngs: ['en', 'ru'],
        lng: language,
        fallbackLng: false,
        interpolation: {
          escapeValue: false
        },
        debug: process.env.NODE_ENV === 'development'
        // // allow keys to be phrases having `:`, `.`
        // nsSeparator: false,
        // keySeparator: false,
      });
  }
}
