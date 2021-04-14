// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryHelper } from './QueryHelper';
import { QueryResult } from './QueryResult';

/**
 * Обработчик запроса.
 */
export abstract class QueryHandler {
  private _title?: string;

  /**
   * Код запроса.
   */
  protected queryCode = QueryHelper.createQueryCode();

  /**
   * Конструктор.
   * @param _queryName Имя запроса.
   */
  constructor(private _queryName: string) {}

  /**
   * Обработать ошибку запроса.
   * @param Ошибка.
   */
  onError(error?: Error) {
    const queryResult = this.getQueryResult();

    let { errorMessages } = queryResult;

    if (!errorMessages) {
      errorMessages = queryResult.errorMessages = [];
    }

    if (error) {
      errorMessages.push('Server is not responding');
    }

    const errorMessage = errorMessages.join(' ');

    console.error(`${this._title}${errorMessage}`, queryResult, error);
  }

  /**
   * Сделать в начале запроса.
   * @param queryCode Код запроса.
   */
  protected doOnStart(queryCode?: string) {
    if (queryCode) {
      this.queryCode = queryCode;
    }

    this._title = `${this._queryName}. Query code: ${this.queryCode}. `;

    console.log(`${this._title}Start`, this.getQueryInput());
  }

  /**
   * Сделать в случае успешного выполнения запроса.
   */
  protected doOnSuccess() {
    const { isOk } = this.getQueryResult();

    if (isOk) {
      console.log(`${this._title}Success`, this.getQueryResult());
    } else {
      this.onError();
    }
  }

  /**
   * Получить входные данные запроса.
   * @returns Входные данные запроса.
   */
  protected abstract getQueryInput(): any;

  /**
   * Получить результат выполнения запроса.
   * @returns Результат выполнения запроса.
   */
  protected abstract getQueryResult(): QueryResult;
}
