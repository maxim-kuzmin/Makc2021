// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { Context as Layer1Context } from 'src/Layer1/Context';
import { QuerySuccessMessageControlModule } from './QuerySuccessMessageControlModule';
import { QuerySuccessMessageControlResource } from './QuerySuccessMessageControlResource';

/**
 * Контекст элемента управления "Сообщение об успехе запроса".
 */
export class QuerySuccessMessageControlContext {
  private _module = new QuerySuccessMessageControlModule();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this._module.resourceGetter = (functionToTranslate: TFunction) =>
      new QuerySuccessMessageControlResource(
        contextOfLayer1
          .getModule()
          .createLocalizationService(functionToTranslate)
      );
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
