// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Сервис.
 */
export class Service {
  /**
   * Конструктор.
   * @param _apiUrl URL API.
   */
  constructor(private _apiUrl: string) {}

  /**
   * Создать URL API.
   * @param suffix Суффикс.
   * @returns URL API.
   */
  createApiUrl(suffix: string): string {
    return `${this._apiUrl}${suffix}`;
  }
}
