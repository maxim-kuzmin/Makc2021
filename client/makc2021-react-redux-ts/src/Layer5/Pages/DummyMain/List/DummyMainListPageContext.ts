// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { Context as Layer1Context } from 'src/Layer1/Context';
import { Context as Layer5Context } from 'src/Layer5/Context';
import { DummyMainListPageModule } from './DummyMainListPageModule';
import { DummyMainListPageService } from './DummyMainListPageService';
import { DummyMainListPageStore } from './DummyMainListPageStore';
import { DummyMainListPageGetQueryHandler } from './Queries/Get/DummyMainListPageGetQueryHandler';

/**
 * Контекст страницы сущностей "DummyMain".
 */
export class DummyMainListPageContext {
  private _module = new DummyMainListPageModule();

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
      return new DummyMainListPageGetQueryHandler(
        contextOfLayer1.getModule().httpService,
        contextOfLayer5.getModule().service,
        contextOfLayer1.getModule().urlService
      );
    };

    const instanceOfService = new Lazy<DummyMainListPageService>(
      () => new DummyMainListPageService(this._module.getQueryHandler)
    );
    this._module.serviceGetter = () => instanceOfService.value;

    const instanceOfStore = new Lazy<DummyMainListPageStore>(
      () =>
        new DummyMainListPageStore(
          this._module.service,
          contextOfLayer5.Controls.Waitings.Global.getModule().store,
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
