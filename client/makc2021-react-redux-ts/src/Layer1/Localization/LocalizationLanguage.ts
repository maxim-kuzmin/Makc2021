// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import i18next, { i18n } from 'i18next';
import { parse } from 'query-string';
import { initReactI18next } from 'react-i18next';
import Backend from 'i18next-http-backend';

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
   * @param lng Язык.
   */
  change(lng: string) {
    this._i18n.changeLanguage(lng);

    window.localStorage.setItem(lngKey, lng);
  }
}

const lngKey = 'lng';

/**
 * Настроить язык.
 */
export function configureLanguage() {
  const search = parse(window.location.search);

  const supportedLngs = ['en', 'ru'];

  let lng = '';

  if (search.lng) {
    const lngFromSearch = String(search.lng);

    if (supportedLngs.some((x) => x === lngFromSearch)) {
      lng = lngFromSearch;
    }
  } else {
    const lngItem = window.localStorage.getItem(lngKey);

    if (lngItem) {
      const lngFromLocalStorage = String(lngItem);

      if (supportedLngs.some((x) => x === lngFromLocalStorage)) {
        lng = lngFromLocalStorage;
      }
    }
  }

  if (!lng) {
    lng = supportedLngs[0];
  }

  window.localStorage.setItem(lngKey, lng);

  i18next
    .use(Backend)
    .use(initReactI18next)
    .init({
      backend: {
        loadPath: '/ResourceFiles/{{ns}}.{{lng}}.json'
      },
      supportedLngs,
      lng,
      fallbackLng: false,
      interpolation: {
        escapeValue: false
      },
      // allow keys to be phrases having `:`, `.`
      nsSeparator: false,
      keySeparator: false,
      debug: process.env.NODE_ENV === 'development'
    });
}
