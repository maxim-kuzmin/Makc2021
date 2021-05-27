// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import i18next from 'i18next';
import { initReactI18next } from 'react-i18next';
import Backend from 'i18next-http-backend';
import { useTranslation } from 'react-i18next';
import { createAppSettings } from './AppSettings';
import { Context as Layer1Context } from './Layer1/Context';
import { Context as Layer5Context } from './Layer5/Context';
import { Context as Layer6Context } from './Layer6/Context';

/**
 * Конфигуратор.
 */
export namespace Configurator {
  /**
   * Слой "Layer1".
   */
  export const Layer1 = new Layer1Context();

  /**
   * Слой "Layer5".
   */
  export const Layer5 = new Layer5Context();

  /**
   * Слой "Layer6".
   */
  export const Layer6 = new Layer6Context();

  /**
   * Настроить сервисы.
   */
  export function configureServices() {
    const currentLanguage = 'en';

    i18next
      .use(Backend)
      .use(initReactI18next)
      .init({
        backend: {
          loadPath: '/ResourceFiles/{{ns}}.{{lng}}.json'
        },
        supportedLngs: ['en', 'ru'],
        lng: currentLanguage,
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
   * Использовать сервисы.
   */
  export function useServices() {
    const { i18n } = useTranslation();

    const appSettings = createAppSettings();

    Layer1.configureServices(i18n);
    Layer5.configureServices(Layer1, appSettings.apiUrl);
    Layer6.configureServices(Layer1);
  }
}
