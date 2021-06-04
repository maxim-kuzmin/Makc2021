// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { v4 as uuidv4 } from 'uuid';

/**
 * Помощник запроса.
 */
export class QueryHelper {
  /**
   * Создать код запроса.
   * @returns Код запроса.
   */
  static createQueryCode() {
    return uuidv4().replace(/-/, '').toUpperCase(); //uuidv4().replaceAll('-', '').toUpperCase();
  }
}
