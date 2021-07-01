// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryResult } from 'src/Layer1/Query/QueryResult';

/**
 * Состояние элемента управления "Извещение запроса".
 */
export interface QueryNotificationControlState {
  /**
   * Результат запроса.
   */
  queryResult: QueryResult;
}
