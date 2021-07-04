// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
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
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Query.configureServices(contextOfLayer1);
  }
}
