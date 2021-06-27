// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { Context as Layer1Context } from 'src/Layer1/Context';
import { Lazy } from 'src/Layer1/Lazy';
import { TopMenuControlModule } from './TopMenuControlModule';
import { TopMenuControlResource } from './TopMenuControlResource';
import { TopMenuControlService } from './TopMenuControlService';

/**
 * Контекст элемента управления "Верхнее меню".
 */
export class TopMenuControlContext {
  private _module = new TopMenuControlModule();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this._module.resourceGetter = (functionToTranslate: TFunction) =>
      new TopMenuControlResource(
        contextOfLayer1
          .getModule()
          .createLocalizationService(functionToTranslate)
      );

    const instanceOfService = new Lazy<TopMenuControlService>(
      () => new TopMenuControlService()
    );
    this._module.serviceGetter = () => instanceOfService.value;
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
