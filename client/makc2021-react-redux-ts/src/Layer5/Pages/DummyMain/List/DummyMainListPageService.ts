// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainListPageGetQueryInput } from './Queries/Get/DummyMainListPageGetQueryInput';
import { DummyMainListPageGetQueryOutput } from './Queries/Get/DummyMainListPageGetQueryOutput';
import { DummyMainListPageGetQueryHandler } from './Queries/Get/DummyMainListPageGetQueryHandler';

/**
 * Сервис страницы сущностей "DummyMain".
 */
export class DummyMainListPageService {
  /**
   * Конструктор.
   * @param _appService Сервис.
   * @param _appUrlService Сервис URL.
   * @param _appGetQueryHandler Обработчик запроса на получение.
   */
  constructor(private _appGetQueryHandler: DummyMainListPageGetQueryHandler) {}

  /**
   * Получить.
   * @param input Входные данные.
   * @returns Обещание получения результата с выходными данными.
   */
  async get(
    input: DummyMainListPageGetQueryInput
  ): Promise<QueryResultWithOutput<DummyMainListPageGetQueryOutput>> {
    const queryHandler = this._appGetQueryHandler;

    try {
      queryHandler.onStart(input);

      const queryResult = await queryHandler.executeQuery();

      queryHandler.onSuccess(queryResult);
    } catch (error) {
      queryHandler.onError(error);
    }

    return queryHandler.queryResult;
  }
}
