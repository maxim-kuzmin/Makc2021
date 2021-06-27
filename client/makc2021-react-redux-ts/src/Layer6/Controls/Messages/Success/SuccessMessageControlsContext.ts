// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { QuerySuccessMessageControlContext } from './Query/QuerySuccessMessageControlContext';

/**
 * Контекст элементов управления "Сообщение об успехе".
 */
export class SuccessMessageControlsContext {
  /**
   * Запрос.
   */
  readonly Query = new QuerySuccessMessageControlContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Query.configureServices(contextOfLayer1);
  }
}
