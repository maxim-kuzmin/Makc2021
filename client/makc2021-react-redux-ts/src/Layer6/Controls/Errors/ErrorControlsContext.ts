// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryErrorControlContext } from './Query/QueryErrorControlContext';

/**
 * Контекст элементов управления "Ошибка".
 */
export class ErrorControlsContext {
  /**
   * Запрос.
   */
  readonly Query = new QueryErrorControlContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Query.configureServices();
  }
}
