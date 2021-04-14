// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Части URL.
 */
export interface UrlParts {
  /**
   * Хэш.
   */
  hash?: string;

  /**
   * Параметры.
   */
  params?: any;

  /**
   * Путь.
   */
  path: string;

  /**
   * Строка запроса.
   */
  search?: any;
}

/**
 * Создать части URL.
 * @returns Части URL.
 */
export function createUrlParts() {
  return { path: '' } as UrlParts;
}
