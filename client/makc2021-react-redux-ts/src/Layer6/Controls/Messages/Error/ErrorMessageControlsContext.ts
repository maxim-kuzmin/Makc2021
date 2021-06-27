// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { QueryErrorMessageControlContext } from './Query/QueryErrorMessageControlContext';

/**
 * Контекст элементов управления "Сообщение об ошибке".
 */
export class ErrorMessageControlsContext {
  /**
   * Запрос.
   */
  readonly Query = new QueryErrorMessageControlContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Query.configureServices(contextOfLayer1);
  }
}
