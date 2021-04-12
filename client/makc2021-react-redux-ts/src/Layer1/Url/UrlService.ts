// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { parse, stringifyUrl } from 'query-string';
import { UrlParts } from './UrlParts';

/**
 * Сервис URL.
 */
export class UrlService {
  /**
   * Создать URL.
   * @param parts Части.
   * @returns URL.
   */
  createUrl(parts: UrlParts): string {
    return stringifyUrl({
      url: parts.path,
      query: parts.query,
      fragmentIdentifier: parts.fragment
    });
  }

  /**
   * Разобрать строку запроса.
   * @param search Строка запроса.
   * @returns Объект, свойства которого содержат значения параметров.
   */
  parseSearch(search: string): any {
    return parse(search);
  }
}
