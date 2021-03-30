// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createQueryResult, QueryResult } from './QueryResult';

/**
 * Результат запроса с выходными данными.
 * @param <TOutput> Тип выходных данных.
 */
export interface QueryResultWithOutput<TOutput> extends QueryResult {
  /**
   * Выходные данные.
   */
  output: TOutput;
}

/**
 * Создать результат запроса.
 * @param <TOutput> Тип выходных данных.
 * @returns Результат запроса.
 */
export function createQueryResultWithOutput<
  TOutput
>(): QueryResultWithOutput<TOutput> {
  return {
    ...createQueryResult()
  } as QueryResultWithOutput<TOutput>;
}
