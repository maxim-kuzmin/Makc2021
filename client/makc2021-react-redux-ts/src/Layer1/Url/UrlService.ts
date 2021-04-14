// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { parse, stringifyUrl } from 'query-string';
import { generatePath } from 'react-router';
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
    const { hash: fragmentIdentifier, params, path, search: query } = parts;

    const url = params ? generatePath(path, params) : path;

    return stringifyUrl({
      url,
      query,
      fragmentIdentifier
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
