// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryResult } from './QueryResult';

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
  return ({
    isOk: false,
    errorMessages: [],
    output: null,
    queryCode: '',
    successMessages: [],
    warningMessages: []
  } as unknown) as QueryResultWithOutput<TOutput>;
}
