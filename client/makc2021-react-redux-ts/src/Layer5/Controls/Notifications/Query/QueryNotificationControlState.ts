// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryResult } from 'src/Layer1/Query/QueryResult';

/**
 * Состояние элемента управления "Извещение запроса".
 */
export interface QueryNotificationControlState {
  /**
   * Карта результата запроса по коду.
   */
  mapOfQueryResultByCode: Map<string, QueryResult>;
}

/**
 * Создать состояние элемента управления "Извещение запроса".
 * @returns Состояние элемента управления "Извещение запроса".
 */
export function createQueryNotificationControlState() {
  return {
    mapOfQueryResultByCode: new Map<string, QueryResult>()
  };
}
