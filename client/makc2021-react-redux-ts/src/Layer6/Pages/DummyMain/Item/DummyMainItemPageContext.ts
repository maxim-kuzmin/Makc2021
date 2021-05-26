// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TFunction } from 'i18next';
import { Context as Layer1Context } from 'src/Layer1/Context';
import { DummyMainItemPageModule } from './DummyMainItemPageModule';
import { DummyMainItemPageResource } from './DummyMainItemPageResource';

/**
 * Контекст страницы сущности "DummyMain".
 */
export class DummyMainItemPageContext {
  private _module = new DummyMainItemPageModule();

  /**
   * Настроить сервисы.
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this._module.resourceGetter = (functionToTranslate: TFunction) =>
      new DummyMainItemPageResource(
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
