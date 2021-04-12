// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ConfigSettings } from './Config/ConfigSettings';

export class Service {
  /**
   * Конструктор.
   * @param _configSettings Настройки конфигурации.
   */
  constructor(private _configSettings: ConfigSettings) {}

  /**
   * Создать URL API.
   * @param suffix Суффикс.
   * @returns URL API.
   */
  createApiUrl(suffix: string): string {
    return `${this._configSettings.apiUrl}${suffix}`;
  }
}
