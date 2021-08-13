// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryHandler } from '../QueryHandler';
import { QueryResult } from '../QueryResult';
import {
  createQueryResultWithOutput,
  QueryResultWithOutput
} from '../QueryResultWithOutput';

/**
 * Обработчик запроса с входными и выходными данными.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export abstract class QueryWithInputAndOutputHandler<
  TQueryOutput
> extends QueryHandler {
  /**
   * Результат выполнения запроса.
   */
  private _queryResult?: QueryResultWithOutput<TQueryOutput>;

  /**
   * Результат выполнения запроса.
   */
  get queryResult() {
    return this._queryResult as QueryResultWithOutput<TQueryOutput>;
  }

  /**
   * Обработать начало запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryCode?: string) {
    this.doOnStart(queryCode);
  }

  /**
   * Обработать успешное выполнение запроса.
   * @param queryResult Результат выполнения запроса.
   */
  onSuccess(queryResult: QueryResultWithOutput<TQueryOutput>) {
    this._queryResult = queryResult;

    this.doOnSuccess();
  }

  /** @inheritdoc */
  protected getQueryInput() {
    return null;
  }

  /** @inheritdoc */
  protected getQueryResult() {
    return this.queryResult as QueryResult;
  }

  /** @inheritdoc */
  protected resetQueryResult() {
    this._queryResult = createQueryResultWithOutput<TQueryOutput>(
      this.queryCode
    );
  }
}
