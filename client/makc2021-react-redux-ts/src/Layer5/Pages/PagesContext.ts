// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { Context as Layer5Context } from 'src/Layer5/Context';
import { DummyMainPagesContext } from './DummyMain/DummyMainPagesContext';

/**
 * Контекст страниц.
 */
export class PagesContext {
  /**
   * Сущность "DummyMain".
   */
  readonly DummyMain = new DummyMainPagesContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer5 Контекст слоя "Layer5".
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(
    contextOfLayer5: Layer5Context,
    contextOfLayer1: Layer1Context
  ) {
    this.DummyMain.configureServices(contextOfLayer5, contextOfLayer1);
  }
}
