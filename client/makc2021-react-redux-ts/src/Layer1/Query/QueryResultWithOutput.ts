// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createQueryResult, QueryResult } from './QueryResult';

/**
 * Результат запроса с выходными данными.
 * @template TOutput Тип выходных данных.
 */
export interface QueryResultWithOutput<TOutput> extends QueryResult {
  /**
   * Выходные данные.
   */
  output: TOutput;
}

/**
 * Создать результат запроса.
 * @template TOutput Тип выходных данных.
 * @param queryCode Код запроса.
 * @returns Результат запроса.
 */
export function createQueryResultWithOutput<TOutput>(queryCode?: string) {
  return {
    ...createQueryResult(queryCode)
  } as QueryResultWithOutput<TOutput>;
}
