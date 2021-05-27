// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';

/**
 * Сервис локализации.
 */
export class LocalizationService {
  /**
   * Конструктор.
   * @param functionToTranslate Функция перевода.
   */
  constructor(private functionToTranslate: TFunction) {}

  /**
   * Получить строку.
   * @param key Ключ.
   * @param options Опции.
   * @returns Строка.
   */
  getString(key: string, options?: any) {
    return this.functionToTranslate.call(this, key, options) as string;
  }
}
