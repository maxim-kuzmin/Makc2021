// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
import { Context as Layer5Context } from 'src/Layer5/Context';
import { DummyMainItemPageContext } from './Item/DummyMainItemPageContext';
import { DummyMainListPageContext } from './List/DummyMainListPageContext';

/**
 * Контекст страниц сущности "DummyMain".
 */
export class DummyMainPagesContext {
  /**
   * Элемент.
   */
  readonly Item = new DummyMainItemPageContext();

  /**
   * Список.
   */
  readonly List = new DummyMainListPageContext();

  /**
   * Настроить сервисы.
   * @param contextOfLayer5 Контекст слоя "Layer5".
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(
    contextOfLayer5: Layer5Context,
    contextOfLayer1: Layer1Context
  ) {
    this.Item.configureServices(contextOfLayer5, contextOfLayer1);
    this.List.configureServices(contextOfLayer5, contextOfLayer1);
  }
}
