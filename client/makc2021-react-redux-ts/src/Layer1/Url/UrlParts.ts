// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Части URL.
 */
export interface UrlParts {
  /**
   * Путь.
   */
  path: string;

  /**
   * Запрос.
   */
  query?: any;

  /**
   * Фрагмент.
   */
  fragment?: string;
}

/**
 * Создать части URL.
 * @returns Части URL.
 */
export function createUrlParts() {
  return { path: '' } as UrlParts;
}
