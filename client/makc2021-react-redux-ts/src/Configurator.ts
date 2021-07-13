// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { enableMapSet } from 'immer';
import { useTranslation } from 'react-i18next';
import { configureLanguage } from './Layer1/Localization/LocalizationLanguage';
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

    configureLanguage();
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
