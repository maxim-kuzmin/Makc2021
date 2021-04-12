// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Настройки приложения.
 */
export interface AppSettings {
  /**
   * URL API
   */
  apiUrl: string;
}

/**
 * Создать настройки приложения.
 * @returns Настройки приложения.
 */
export function createAppSettings() {
  return {
    apiUrl: 'http://localhost:5000/api/'
  } as AppSettings;
}
