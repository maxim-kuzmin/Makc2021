// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';
import { DummyMainItemPageGetQueryHandler } from './Queries/Get/DummyMainItemPageGetQueryHandler';
import { DummyMainItemPageSaveQueryOutput } from './Queries/Save/DummyMainItemPageSaveQueryOutput';
import { DummyMainItemPageSaveQueryInput } from './Queries/Save/DummyMainItemPageSaveQueryInput';
import { DummyMainItemPageSaveQueryHandler } from './Queries/Save/DummyMainItemPageSaveQueryHandler';

/**
 * Сервис страницы сущности "DummyMain".
 */
export class DummyMainItemPageService {
  /**
   * Конструктор.
   * @param _appGetQueryHandler Обработчик запроса на получение.
   * @param _appSaveQueryHandler Обработчик запроса на сохранение.
   */
  constructor(
    private _appGetQueryHandler: DummyMainItemPageGetQueryHandler,
    private _appSaveQueryHandler: DummyMainItemPageSaveQueryHandler
  ) {}

  /**
   * Получить.
   * @param input Входные данные.
   * @returns Обещание получения результата с выходными данными.
   */
  async get(
    input: DummyMainItemPageGetQueryInput
  ): Promise<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> {
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

  /**
   * Сохранить.
   * @param input Входные данные.
   * @returns Обещание получения результата с выходными данными.
   */
  async save(
    input: DummyMainItemPageSaveQueryInput
  ): Promise<QueryResultWithOutput<DummyMainItemPageSaveQueryOutput>> {
    const queryHandler = this._appSaveQueryHandler;

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
