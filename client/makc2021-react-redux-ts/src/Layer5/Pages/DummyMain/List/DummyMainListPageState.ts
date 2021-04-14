// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createQueryResultWithOutput,
  QueryResultWithOutput
} from 'src/Layer1/Query/QueryResultWithOutput';
import { DummyMainListPageGetQueryOutput } from './Queries/Get/DummyMainListPageGetQueryOutput';

/**
 * Состояние страницы сущностей "DummyMain".
 */
export interface DummyMainListPageState {
  /**
   * Результат запроса на получение.
   */
  getQueryResult: QueryResultWithOutput<DummyMainListPageGetQueryOutput>;

  /**
   * Признак нахождения в ожидании.
   */
  isWaiting: boolean;
}

/**
 * Создать состояние страницы сущностей "DummyMain".
 * @returns Состояние страницы сущностей "DummyMain".
 */
export function createDummyMainListPageState() {
  return {
    getQueryResult: createQueryResultWithOutput<DummyMainListPageGetQueryOutput>(),
    isWaiting: false
  } as DummyMainListPageState;
}
