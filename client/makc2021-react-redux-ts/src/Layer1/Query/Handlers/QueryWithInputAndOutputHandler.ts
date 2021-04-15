// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryHandler } from '../QueryHandler';
import { QueryResult } from '../QueryResult';
import {
  createQueryResultWithOutput,
  QueryResultWithOutput
} from '../QueryResultWithOutput';

/**
 * Обработчик запроса с входными и выходными данными.
 * @template TQueryInput Тип входных данных запроса.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export abstract class QueryWithInputAndOutputHandler<
  TQueryInput,
  TQueryOutput
> extends QueryHandler {
  private _queryInput?: TQueryInput;

  /**
   * Результат выполнения запроса.
   */
  private _queryResult?: QueryResultWithOutput<TQueryOutput>;

  /**
   * Входные данные запроса.
   */
  get queryInput() {
    return this._queryInput as TQueryInput;
  }

  /**
   * Результат выполнения запроса.
   */
  get queryResult() {
    const result = this._queryResult as QueryResultWithOutput<TQueryOutput>;

    this._queryResult = undefined;

    return result;
  }

  /**
   * Обработать начало запроса.
   * @param input Входные данные.
   * @param queryCode Код запроса.
   */
  onStart(queryInput: TQueryInput, queryCode?: string) {
    this._queryInput = queryInput;

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
  protected getQueryInput(): any {
    return this.queryInput;
  }

  /** @inheritdoc */
  protected getQueryResult(): QueryResult {
    if (!this._queryResult) {
      this._queryResult = this.createQueryResult();
    }

    return this._queryResult as QueryResult;
  }

  private createQueryResult() {
    const result = createQueryResultWithOutput<TQueryOutput>();

    result.queryCode = this.queryCode;

    return result;
  }
}
