// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { httpClient } from 'src/Layer1/Query/Http/HttpClient';
import {
  QueryResultWithOutput,
  createQueryResultWithOutput
} from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';

export async function get(
  input: DummyMainItemPageGetQueryInput
): Promise<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> {
  let result: QueryResultWithOutput<DummyMainItemPageGetQueryOutput>;

  const url = `/api/pages/dummy-main/item/${input.item.entityId}`;

  try {
    result = await httpClient.get(url);
  } catch (error) {
    console.error(`URL ${url}`, error);

    result = createQueryResultWithOutput<DummyMainItemPageGetQueryOutput>();

    result.errorMessages.push(error.message);
  }

  return result;
}
