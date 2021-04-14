// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryHelper } from './QueryHelper';

/**
 * Результат запроса.
 */
export interface QueryResult {
  /**
   * Признак успешности выполнения.
   */
  isOk: boolean;

  /**
   * Сообщения об ошибках.
   */
  errorMessages: string[];

  /**
   * Код запроса.
   */
  queryCode: string;

  /**
   * Сообщения об успехах.
   */
  successMessages: string[];

  /**
   * Сообщения о предупреждениях.
   */
  warningMessages: string[];
}

/**
 * Создать результат запроса.
 * @returns Результат запроса.
 */
export function createQueryResult() {
  return {
    isOk: false,
    errorMessages: [],
    queryCode: QueryHelper.createQueryCode(),
    successMessages: [],
    warningMessages: []
  } as QueryResult;
}
