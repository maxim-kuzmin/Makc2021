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
  const result = {
    apiUrl: 'http://localhost:8081/api/'
  } as AppSettings;

  if (process.env.NODE_ENV === 'development') {
    result.apiUrl = 'http://localhost:5000/api/'
  }

  return result;
}
