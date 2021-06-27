// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { ErrorMessageControlsContext } from './Error/ErrorMessageControlsContext';
import { SuccessMessageControlsContext } from './Success/SuccessMessageControlsContext';

/**
 * Контекст элементов управления "Сообщение".
 */
export class MessageControlsContext {
  /**
   * Ошибка.
   */
  readonly Error = new ErrorMessageControlsContext();

  /**
   * Успех.
   */
  readonly Success = new SuccessMessageControlsContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Error.configureServices(contextOfLayer1);
    this.Success.configureServices(contextOfLayer1);
  }
}
