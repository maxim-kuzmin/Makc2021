// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import i18next from 'i18next';
import { initReactI18next } from 'react-i18next';
import Backend from 'i18next-http-backend';

/**
 * Сервис локализации.
 */
export class LocalizationService {
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
