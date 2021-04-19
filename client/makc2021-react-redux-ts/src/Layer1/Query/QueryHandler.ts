// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryHelper } from './QueryHelper';
import { QueryResult } from './QueryResult';

/**
 * Обработчик запроса.
 */
export abstract class QueryHandler {
  private _queryCode?: string;
  private _title?: string;

  /**
   * Код запроса.
   */
  protected get queryCode() {
    return this._queryCode as string;
  }

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
    if (error) {
      this.resetQueryResult();
    }

    let errorMessage = 'Unknown error';

    const queryResult = this.getQueryResult();

    if (error) {
      if (error.message) {
        errorMessage = error.message;
      }

      queryResult.errorMessages.push(errorMessage);
    } else {
      const { errorMessages } = queryResult;

      if (errorMessages && errorMessages.length > 0) {
        errorMessage = errorMessages.join(' ');
      }
    }

    console.error(`${this._title}${errorMessage}`, queryResult, error);
  }

  /**
   * Сделать в начале запроса.
   * @param queryCode Код запроса.
   */
  protected doOnStart(queryCode?: string) {
    this._queryCode = queryCode ?? QueryHelper.createQueryCode();

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

  /**
   * Переустановить результат запроса.
   */
  protected abstract resetQueryResult(): void;
}
