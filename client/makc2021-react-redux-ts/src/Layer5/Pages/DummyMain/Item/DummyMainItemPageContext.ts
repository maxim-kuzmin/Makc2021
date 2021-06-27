// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { Context as Layer1Context } from 'src/Layer1/Context';
import { Context as Layer5Context } from 'src/Layer5/Context';
import { DummyMainItemPageModule } from './DummyMainItemPageModule';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { DummyMainItemPageStore } from './DummyMainItemPageStore';
import { DummyMainItemPageGetQueryHandler } from './Queries/Get/DummyMainItemPageGetQueryHandler';
import { DummyMainItemPageSaveQueryHandler } from './Queries/Save/DummyMainItemPageSaveQueryHandler';

/**
 * Контекст страницы сущности "DummyMain".
 */
export class DummyMainItemPageContext {
  private _module = new DummyMainItemPageModule();

  /**
   * Настроить сервисы.
   * @param contextOfLayer5 Контекст слоя "Layer5".
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(
    contextOfLayer5: Layer5Context,
    contextOfLayer1: Layer1Context
  ) {
    this._module.getQueryHandlerGetter = () => {
      return new DummyMainItemPageGetQueryHandler(
        contextOfLayer1.getModule().httpService,
        contextOfLayer5.getModule().service,
        contextOfLayer1.getModule().urlService
      );
    };

    this._module.saveQueryHandlerGetter = () => {
      return new DummyMainItemPageSaveQueryHandler(
        contextOfLayer1.getModule().httpService,
        contextOfLayer5.getModule().service,
        contextOfLayer1.getModule().urlService
      );
    };

    const instanceOfService = new Lazy<DummyMainItemPageService>(
      () =>
        new DummyMainItemPageService(
          this._module.getQueryHandler,
          this._module.saveQueryHandler
        )
    );
    this._module.serviceGetter = () => instanceOfService.value;

    const instanceOfStore = new Lazy<DummyMainItemPageStore>(
      () =>
        new DummyMainItemPageStore(
          this._module.service,
          contextOfLayer1.getModule().timingFactory
        )
    );
    this._module.storeGetter = () => instanceOfStore.value;
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
