// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  QueryResultWithOutput,
  createQueryResultWithOutput
} from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';
import { HttpService } from 'src/Layer1/Http/HttpService';
import { Service } from 'src/Layer5/Service';

/**
 * Сервис страницы сущности "DummyMain".
 */
export class DummyMainItemPageService {
  /**
   * Конструктор.
   * @param _httpService Сервис HTTP.
   * @param _service Сервис.
   */
  constructor(private _httpService: HttpService, private _service: Service) {}

  /**
   * Получить.
   * @param input Входные данные.
   * @returns Обещание получения результата с выходными данными.
   */
  async get(
    input: DummyMainItemPageGetQueryInput
  ): Promise<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> {
    let result: QueryResultWithOutput<DummyMainItemPageGetQueryOutput>;

    const url = this._service.createApiUrl(
      `pages/dummy-main/item/${input.item.entityId}`
    );

    try {
      if (input.item.entityId > 0) {
        result = await this._httpService.get(url);
      } else {
        result = createQueryResultWithOutput<DummyMainItemPageGetQueryOutput>();

        result.errorMessages.push('Не указан идентификатор');
      }
    } catch (error) {
      console.error(`MAKC: ${url}`, error);

      result = createQueryResultWithOutput<DummyMainItemPageGetQueryOutput>();

      result.errorMessages.push(`Нет связи с сервером по адресу: ${url}`);
    }

    return result;
  }
}
