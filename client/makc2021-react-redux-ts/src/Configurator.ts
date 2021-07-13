// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import i18next from 'i18next';
import { parse } from 'query-string';
import { initReactI18next } from 'react-i18next';
import Backend from 'i18next-http-backend';
import { enableMapSet } from 'immer';
import { useTranslation } from 'react-i18next';
import { createAppSettings } from './AppSettings';
import { defaultContextValue } from './Context';

/**
 * Конфигуратор.
 */
export namespace Configurator {
  /**
   * Настроить сервисы.
   */
  export function configureServices() {
    enableMapSet();

    const search = parse(window.location.search);

    const supportedLngs = ['en', 'ru'];

    const lngKey = 'lng';

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

  /**
   * Получить значение контекста.
   * @returns Значение контекста.
   */
  export function getContextValue() {
    return defaultContextValue;
  }

  /**
   * Использовать сервисы.
   */
  export function useServices() {
    const { i18n } = useTranslation();

    const contextValue = getContextValue();

    const appSettings = createAppSettings();

    contextValue.Layer1.configureServices(i18n);

    contextValue.Layer5.configureServices(
      defaultContextValue.Layer1,
      appSettings.apiUrl
    );

    contextValue.Layer6.configureServices(defaultContextValue.Layer1);
  }
}
