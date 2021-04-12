// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Настройки конфигурации.
 */
export interface ConfigSettings {
  /**
   * URL API.
   */
  apiUrl: string;
}

/**
 * Создать настройки конфигурации.
 * @returns Настройки конфигурации.
 */
export function createConfigSettings() {
  return { apiUrl: '' } as ConfigSettings;
}
