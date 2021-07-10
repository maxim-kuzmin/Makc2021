// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { MenuControlsContext } from './Menus/MenuControlsContext';
import { NotificationControlsContext } from './Notifications/NotificationControlsContext';
import { WaitingControlsContext } from './Waitings/WaitingControlsContext';

/**
 * Контекст элементов управления.
 */
export class ControlsContext {
  /**
   * Меню.
   */
  readonly Menus = new MenuControlsContext();

  /**
   * Извещения.
   */
  readonly Notifications = new NotificationControlsContext();

  /**
   * Ожидания.
   */
  readonly Waitings = new WaitingControlsContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Menus.configureServices();
    this.Notifications.configureServices();
    this.Waitings.configureServices();
  }
}
