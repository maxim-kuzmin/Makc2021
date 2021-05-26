// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from 'src/Layer1/Context';
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
   * @param contextOfLayer1 Контекст слоя "Layer1".
   */
  configureServices(contextOfLayer1: Layer1Context) {
    this.Item.configureServices(contextOfLayer1);
    this.List.configureServices(contextOfLayer1);
  }
}
