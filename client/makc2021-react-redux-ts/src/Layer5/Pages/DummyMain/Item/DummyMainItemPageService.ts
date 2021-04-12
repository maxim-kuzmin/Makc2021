// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { appLayer1Module } from 'src/Layer1/Module';
import {
  QueryResultWithOutput,
  createQueryResultWithOutput
} from 'src/Layer1/Query/QueryResultWithOutput';
import { appLayer5Module } from 'src/Layer5/Module';
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

  const url = appLayer5Module.service.createApiUrl(
    `pages/dummy-main/item/${input.item.entityId}`
  );

  try {
    if (input.item.entityId > 0) {
      result = await appLayer1Module.httpServive.get(url);
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
