// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { MenuControlsContext } from './Menus/MenuControlsContext';
import { MessageControlsContext } from './Messages/MessageControlsContext';
import { NotificationControlsContext } from './Notifications/NotificationControlsContext';
import { TableControlsContext } from './Tables/TableControlsContext';

/**
 * Контекст элементов управления.
 */
export class ControlsContext {
  /**
   * Меню.
   */
  readonly Menus = new MenuControlsContext();

  /**
   * Сообщения.
   */
  readonly Messages = new MessageControlsContext();

  /**
   * Извещения.
   */
  readonly Notification = new NotificationControlsContext();

  /**
   * Таблицы.
   */
  readonly Tables = new TableControlsContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Menus.configureServices(contextOfLayer1);
    this.Messages.configureServices(contextOfLayer1);
    this.Notification.configureServices(contextOfLayer1);
    this.Tables.configureServices(contextOfLayer1);
  }
}
