// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryErrorControlModule } from './QueryErrorControlModule';

/**
 * Контекст элемента управления "Ошибка запроса".
 */
export class QueryErrorControlContext {
  /**
   * Модуль.
   */
  readonly module = new QueryErrorControlModule();
}
