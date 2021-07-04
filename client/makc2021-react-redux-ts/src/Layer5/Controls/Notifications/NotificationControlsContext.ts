// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryNotificationControlContext } from './Query/QueryNotificationControlContext';

/**
 * Контекст элементов управления "Извещение".
 */
export class NotificationControlsContext {
  /**
   * Запрос.
   */
  readonly Query = new QueryNotificationControlContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Query.configureServices();
  }
}
