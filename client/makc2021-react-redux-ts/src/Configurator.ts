// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context as Layer1Context } from './Layer1/Context';
import { Context as Layer5Context } from './Layer5/Context';
import { Context as Layer6Context } from './Layer6/Context';

/**
 * Конфигуратор.
 */
export namespace Configurator {
  /**
   * Слой "Layer1".
   */
  export const Layer1 = new Layer1Context();

  /**
   * Слой "Layer5".
   */
  export const Layer5 = new Layer5Context();

  /**
   * Слой "Layer6".
   */
  export const Layer6 = new Layer6Context();
}
