// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { DefaultTableControlContext } from './Default/DefaultTableControlContext';

/**
 * Контекст элементов управления "Таблица".
 */
export class TableControlsContext {
  /**
   * По умолчанию.
   */
  readonly Default = new DefaultTableControlContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Default.configureServices(contextOfLayer1);
  }
}
