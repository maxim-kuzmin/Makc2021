// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { httpClient } from 'src/Layer1/Query/Http/HttpClient';
import {
  QueryResultWithOutput,
  createQueryResultWithOutput
} from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';

/**
 * Получить.
 * @param input Входные данные.
 * @returns Обещание получения результата с выходными данными.
 */
export async function get(
  input: DummyMainItemPageGetQueryInput
): Promise<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> {
  let result: QueryResultWithOutput<DummyMainItemPageGetQueryOutput>;

  const url = `http://localhost:5000/api/pages/dummy-main/item/${input.item.entityId}`;

  try {
    if (input.item.entityId > 0) {
      result = await httpClient.get(url);
    } else {
      result = createQueryResultWithOutput<DummyMainItemPageGetQueryOutput>();

      result.errorMessages.push(`Не указан идентификатор`);
    }
  } catch (error) {
    console.error(`MAKC: ${url}`, error);

    result = createQueryResultWithOutput<DummyMainItemPageGetQueryOutput>();

    result.errorMessages.push(`Нет связи с сервером по адресу: ${url}`);
  }

  return result;
}
